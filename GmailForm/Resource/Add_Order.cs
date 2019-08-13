using Design.Resource;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Message = Google.Apis.Gmail.v1.Data.Message;

namespace GmailForm.Resource
{
    class Add_Order
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json
        static string[] Scopes = { GmailService.Scope.GmailReadonly, GmailService.Scope.GmailLabels, GmailService.Scope.GmailCompose, GmailService.Scope.GmailModify };
        static string ApplicationName = "Gmail API .NET Quickstart";
        static List<string> fileList = new List<string>();
        static List<Message> preb_message = new List<Message>();
        static GmailService service = new GmailService();
        private static System.Timers.Timer aTimer;

        private static string server;
        private static string user;
        private static string pass;
        private static string time_interval;
        private static int row_num;

        static string file_root = "downloads";
        static string file_dir = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString(), file_root);
        private static string txt_file_name = "order_history.txt";

        static void OnTimedEvent(object source, ElapsedEventArgs e)
        {

            fileList = new List<string>();

            List<Message> msg = ListMessages(service, "me", "is:unread");
            // List<Message> unreadmessages = Expect(preb_message, all_messages);
            //preb_message = all_messages;

            foreach (Message msgItem in msg)
            {
                GetAttachments(service, "me", msgItem.Id, file_dir);
            }

            //foreach (Message msg in unreadmessages)
            //{
            //    atach_state = GetAttachments(service, "me", msg.Id, file_dir);
            //}


            foreach (string item in fileList)
            {
                string pdf_string = ExtractTextFromPdf(item);
                List<Order> orderList = new List<Order>();
                orderList = GetArray(pdf_string);

                foreach (Order orderItem in orderList)
                {

                    string connString = "Data Source=" + server + ";" +
                                        "User id=" + user + ";" +
                                        "Password=" + pass + ";";
                    string cmdString = " INSERT INTO [PedidosMetatecnics].[dbo].[MiniPedido]  (Fecha, Direct, Referencia, Modelo, ArchivoCliente, NumColores, Cantidad, FechaActualizacion, Articulo, FechaEnvioCliente) " +
                            " OUTPUT INSERTED.ID_MiniPedido " +
                        "VALUES (@Fecha, @Direct, @reference, @model, @visual, @numColors, @quantity, @now_date, @model_color, @shippingDate)";
                    string[] date_string_list = orderItem.shipping_date.Split('/');
                    string datestring = date_string_list[1] + "/" + date_string_list[0] + "/" + date_string_list[2];
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        string oString = "Select ID_MiniPedido from [PedidosMetatecnics].[dbo].[MiniPedido] where Fecha=@Fecha and Direct=@Direct and Referencia=@Referencia " +
                            "and Modelo=@Modelo and ArchivoCliente=@ArchivoCliente and NumColores=@NumColores and Cantidad=@Cantidad" +
                            " and Articulo=@Articulo";
                        SqlCommand oCmd = new SqlCommand(oString, conn);
                        oCmd.Parameters.AddWithValue("@Direct", orderItem.direct);
                        oCmd.Parameters.AddWithValue("@Referencia", orderItem.reference);
                        oCmd.Parameters.AddWithValue("@Modelo", orderItem.model);
                        oCmd.Parameters.AddWithValue("@ArchivoCliente", orderItem.visual);
                        oCmd.Parameters.AddWithValue("@NumColores", orderItem.printing_color.Count());
                        oCmd.Parameters.AddWithValue("@Cantidad", orderItem.unit);
                        oCmd.Parameters.AddWithValue("@Articulo", orderItem.model_color);
                        oCmd.Parameters.AddWithValue("@Fecha", DateTime.Parse(datestring));
                        string search_id = null;
                        conn.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                search_id = oReader["ID_MiniPedido"].ToString();
                            }

                            conn.Close();
                        }


                        if (search_id == null)
                        {
                            search_id = null;
                            conn.Open();

                            using (SqlCommand comm = new SqlCommand())
                            {
                                comm.Connection = conn;
                                comm.CommandText = cmdString;
                                comm.Parameters.AddWithValue("@Fecha", DateTime.Parse(datestring));
                                comm.Parameters.AddWithValue("@Direct", orderItem.direct);
                                comm.Parameters.AddWithValue("@reference", orderItem.reference);
                                comm.Parameters.AddWithValue("@model", orderItem.model);
                                comm.Parameters.AddWithValue("@visual", orderItem.visual);
                                comm.Parameters.AddWithValue("@numColors", orderItem.printing_color.Count());
                                comm.Parameters.AddWithValue("@quantity", orderItem.unit);
                                comm.Parameters.AddWithValue("@now_date", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"));
                                comm.Parameters.AddWithValue("@model_color", orderItem.model_color);
                                comm.Parameters.AddWithValue("@shippingDate", DateTime.Parse(DateTime.Now.ToString()));
                                try
                                {
                                    row_num = (int)comm.ExecuteScalar();
                                    conn.Close();

                                    foreach (string color in orderItem.printing_color)
                                    {
                                        string cmd_color_string = " INSERT INTO [PedidosMetatecnics].[dbo].[MiniPedidoColores]  (ID_MiniPedido, Color, FechaActualizacion) " +
                                        "VALUES (@order_id, @color, @readingDate)";

                                        using (SqlConnection conn2 = new SqlConnection(connString))
                                        {
                                            using (SqlCommand comm2 = new SqlCommand())
                                            {
                                                comm2.Connection = conn2;
                                                comm2.CommandText = cmd_color_string;
                                                comm2.Parameters.AddWithValue("@order_id", row_num.ToString());
                                                comm2.Parameters.AddWithValue("@color", color);
                                                comm2.Parameters.AddWithValue("@readingDate", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"));
                                                try
                                                {
                                                    conn2.Open();
                                                    comm2.ExecuteScalar();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    System.Console.Write("false");
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (SqlException ex)
                                {
                                    System.Console.Write("false");
                                }
                            }
                        }

                    }


                }
            }
        }

        static private List<Message> Expect(List<Message> old_list, List<Message> new_list)
        {
            List<Message> tempList = new List<Message>();

            if (old_list.Count() < new_list.Count())
            {
                for (int i = 0; i < new_list.Count(); i++)
                {
                    if (i >= old_list.Count())
                    {
                        tempList.Add(new_list[new_list.Count() - i - 1]);
                    }
                }
            }
            return tempList;
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            //aTimer = new System.Timers.Timer(10000);
            aTimer = new System.Timers.Timer(Convert.ToDouble(time_interval) * 60 * 1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            //aTimer.AutoReset = true;
            //aTimer.Enabled = true;
            aTimer.Start();
        }



        private static void Init()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }



           // UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
           //new ClientSecrets
           //{
           //    ClientId = "927846911187-rlv29umu9t8c95am436v8d1i5spo582g.apps.googleusercontent.com",
           //    ClientSecret = "nKR2PPhFLxYkHJ8HMku6fHWB"
           //},
           //new[] { GmailService.Scope.GmailModify },
           //"user",
           //CancellationToken.None).Result;

           // // Create Gmail API service.
           // var service = new GmailService(new BaseClientService.Initializer()
           // {
           //     HttpClientInitializer = credential,
           //     ApplicationName = ApplicationName,
           // });


            // Create Gmail API service.
            service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public static void Main_Parser(string server_address, string server_user, string server_pass, string time)
        {
            server = server_address;
            user = server_user;
            pass = server_pass;
            time_interval = time;
            //mail_subject = subject;
            Init();

            SetTimer();
        }

        public static void Stop_Parser()
        {
            aTimer.Stop();
            List<string> fileList = new List<string>();
        }


        public static List<Order> GetArray(string file_content)
        {
            List<Order> orderList = new List<Order>();

            string shippingDate = Between(file_content, "Date livraison à Céret", "Date de livraison Client").Trim();
            string reference = Between(file_content, "Référence :", "Fournisseur").Trim();
            bool direct = file_content.Contains("DIRECT");


            string model = "";
            string visual = "";
            string units = "";
            string modelColor = "";
            List<string> printingColors = new List<string>();

            string model_string = Between(file_content, "Quantité Couleur", "Date livraison à Céret");
            string[] model_lines = model_string.Trim().Split('\n');

            for (int i = 0; i < model_lines.Length; i++)
            {

                if (If_model_row(model_lines[i]))
                {
                    string[] row_arr = model_lines[i].Split(' ');
                    for (int j = 0; j < row_arr.Length; j++)
                    {
                        if (int.TryParse(row_arr[row_arr.Length - 1 - j].Trim(), out int n))
                        {
                            units = row_arr[row_arr.Length - 1 - j];
                            break;
                        }
                    }

                    string[] model_line_array = model_lines[i].Split(new string[] { units }, StringSplitOptions.None);
                    model = model_line_array[0].Trim();
                    modelColor = model_line_array[1].Trim();

                    if (i + 1 == model_lines.Length || If_model_row(model_lines[i + 1]))
                    {
                        Order order = new Order
                        {
                            shipping_date = shippingDate,
                            reference = reference,
                            direct = direct,
                            unit = units,
                            model = model,
                            visual = visual,
                            model_color = modelColor,
                            printing_color = printingColors
                        };
                        orderList.Add(order);
                        printingColors = new List<string>();
                        visual = "";
                    }
                }
                if (If_visual_row(model_lines[i]))
                {
                    visual = model_lines[i].Replace("Visuel :", "").Trim();
                    if (i + 1 == model_lines.Length || If_model_row(model_lines[i + 1]))
                    {
                        Order order = new Order
                        {
                            shipping_date = shippingDate,
                            reference = reference,
                            direct = direct,
                            unit = units,
                            model = model,
                            visual = visual,
                            model_color = modelColor,
                            printing_color = printingColors
                        };
                        orderList.Add(order);
                        printingColors = new List<string>();
                        visual = "";
                    }
                }
                if (If_printingColor_row(model_lines[i]))
                {

                    string printing_color_temp_row = model_lines[i].Replace("Impression couleur ", "").Trim();
                    string[] printingColor_item = printing_color_temp_row.Split(' ');

                    string temp_str = null;



                    try
                    {
                        for (int j = 0; j < printingColor_item.Length; j++)
                        {
                            if (j > 0)
                            {
                                temp_str += " " + printingColor_item[j];
                            }
                        }
                        printingColors.Add(temp_str.Trim());
                    }
                    catch
                    {
                        printingColors.Add("");
                    }




                    if (i + 1 == model_lines.Length || If_model_row(model_lines[i + 1]))
                    {
                        Order order = new Order
                        {
                            shipping_date = shippingDate,
                            reference = reference,
                            direct = direct,
                            unit = units,
                            model = model,
                            visual = visual,
                            model_color = modelColor,
                            printing_color = printingColors
                        };
                        orderList.Add(order);
                        printingColors = new List<string>();
                        visual = "";
                    }
                }
            }
            return orderList;
        }

        private static bool If_visual_row(string str)
        {
            return str.Contains("Visuel :");
        }

        private static bool If_model_row(string str)
        {
            if (!str.Contains("Visuel :") && !str.Contains("Impression couleur"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool If_printingColor_row(string str)
        {
            if (str.Contains("Impression couleur"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static string ExtractTextFromPdf(string path)
        {
            using (PdfReader reader = new PdfReader(path))
            {
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }


                return text.ToString();
            }
        }

        public static byte[] FromBase64ForUrlString(string base64ForUrlInput)
        {
            int padChars = (base64ForUrlInput.Length % 4) == 0 ? 0 : (4 - (base64ForUrlInput.Length % 4));
            StringBuilder result = new StringBuilder(base64ForUrlInput, base64ForUrlInput.Length + padChars);
            result.Append(String.Empty.PadRight(padChars, '='));
            result.Replace('-', '+');
            result.Replace('_', '/');
            return Convert.FromBase64String(result.ToString());
        }

        public static bool GetAttachments(GmailService service, String userId, String messageId, String outputDir)
        {
   

            //string txt_file_dir = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString(), txt_file_name);
            //string textContent = File.ReadAllText(txt_file_dir);


            //string createText = "Hello and Welcome" + Environment.NewLine;
            //File.WriteAllText(path, createText);

            //Console.WriteLine("An error occurred: " + e.Message);

            //try
            //{
            //    return service.Users.Messages.Modify(mods, userId, messageId).Execute();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("An error occurred: " + e.Message);
            //}

            string txt_file_dir = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString(), txt_file_name);
           
            string createText = null;
            try
            {
                Message message = service.Users.Messages.Get(userId, messageId).Execute();
                IList<MessagePart> parts = message.Payload.Parts;


                foreach (MessagePart part in parts)
                {
                    if (!String.IsNullOrEmpty(part.Filename))
                    {
                        String attId = part.Body.AttachmentId;
                        MessagePartBody attachPart = service.Users.Messages.Attachments.Get(userId, messageId, attId).Execute();

                        // Converting from RFC 4648 base64 to base64url encoding
                        // see http://en.wikipedia.org/wiki/Base64#Implementations_and_history
                        String attachData = attachPart.Data.Replace('-', '+');
                        attachData = attachData.Replace('_', '/');

                        byte[] data = Convert.FromBase64String(attachData);

                        if (Path.GetExtension(part.Filename) == ".pdf" && part.Filename.Contains("bon-fournisseur"))
                        {
                            string readText = File.ReadAllText(txt_file_dir);
                            createText = readText;
                            string[] fileListContent = readText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                            string filePath = Path.Combine(outputDir, part.Filename);
                            string order_name = part.Filename.Replace("bon-fournisseur-", "").Replace(".pdf", "").Trim();
                            bool order_check_flag = false;
                            foreach (string t_item in fileListContent)
                            {
                                if (t_item == order_name)
                                {
                                    order_check_flag = true;
                                }
                            }


                            if(!order_check_flag)
                            {
                                // Download pdf file
                                File.WriteAllBytes(filePath, data);
                                fileList.Add(filePath);

                                // Change Unread label

                                // Add new order line in file
                                createText = readText + order_name + Environment.NewLine;
                            }



                            File.WriteAllText(txt_file_dir, createText);
                            DeleteLabel(service, "me", "UNREAD", messageId);
                        }
                    }
                }
                //File.WriteAllText(txt_file_dir, createText);

                //return fileList;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
                //return null;
            }

            return true;
        }

        public static string Between(string Text, string FirstString, string LastString)
        {

            string STR = Text;

            string STRFirst = FirstString;

            string STRLast = LastString;

            string FinalString;


            int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;

            int Pos2 = STR.IndexOf(LastString);

            FinalString = STR.Substring(Pos1, Pos2 - Pos1);

            return FinalString;
        }

        private static List<Message> ListMessages(GmailService service, String userId, String query)
        {
            List<Message> result = new List<Message>();
            UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List(userId);
            request.Q = query;

            do
            {
                try
                {
                    ListMessagesResponse response = request.Execute();
                    result.AddRange(response.Messages);
                    request.PageToken = response.NextPageToken;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            } while (!String.IsNullOrEmpty(request.PageToken));

            return result;
        }

        public static void DeleteLabel(GmailService service, String userId, String labelId, String messageId)
        {
            try
            {
                //service.Users.Labels.Delete(userId, labelId).Execute();
                ModifyMessageRequest mods = new ModifyMessageRequest();
                mods.AddLabelIds = null;
                mods.RemoveLabelIds = new List<string> { "UNREAD" };
                service.Users.Messages.Modify(mods, userId, messageId).Execute();

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }


        public static Message ModifyMessage(GmailService service, String userId, String messageId, List<String> labelsToRemove)
        {
            ModifyMessageRequest mods = new ModifyMessageRequest();
            mods.RemoveLabelIds = labelsToRemove;

            try
            {
                return service.Users.Messages.Modify(mods, userId, messageId).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            return null;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
