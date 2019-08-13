using GmailForm.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GmailForm
{
    public partial class Form1 : Form
    {
        private static int start_flag = 0;
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = label1;
            start_flag = 0;
        }
        
        private void Confirm_button_Click(object sender, EventArgs e)
        {

            string server_address = server_address_box.Text.ToString();
            string _server_user = srever_user_box.Text.ToString();
            string _server_pass = server_password_box.Text.ToString();
            //string _email_subject = mail_subject_box.Text.ToString();
            string _time_interval = TimeBox.Text.ToString();

            if (server_address == "" || _server_user == "" || _server_pass == "" || _time_interval == "")
            {
                MessageBox.Show("Please insert correct data");
                return;
            }
            if (start_flag == 0)
            {
                start_flag = 1;
                this.confirm_button.Text = "STOP";
                this.dialog_label.Text = "PDF parsing started. If you want to stop, please press STOP button.";
                Add_Order order_manager = new Add_Order();
                Add_Order.Main_Parser(server_address, _server_user, _server_pass, _time_interval);

                server_password_box.Enabled = false;
                server_address_box.Enabled = false;
                srever_user_box.Enabled = false;
                TimeBox.Enabled = false;
            }
            else
            {
                start_flag = 0;
                this.confirm_button.Text = "START";
                this.dialog_label.Text = "";
                Add_Order order_manager = new Add_Order();
                Add_Order.Stop_Parser();

                server_password_box.Enabled = true;
                server_address_box.Enabled = true;
                srever_user_box.Enabled = true;
                TimeBox.Enabled = true;
            }
        }
    }
}
