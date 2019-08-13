namespace GmailForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.server_password_box = new System.Windows.Forms.TextBox();
            this.srever_user_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.server_address_box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TimeBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.confirm_button = new System.Windows.Forms.Button();
            this.dialog_label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.server_password_box);
            this.groupBox1.Controls.Add(this.srever_user_box);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.server_address_box);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(575, 149);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Information";
            // 
            // server_password_box
            // 
            this.server_password_box.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.server_password_box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.server_password_box.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.server_password_box.Location = new System.Drawing.Point(398, 101);
            this.server_password_box.Name = "server_password_box";
            this.server_password_box.Size = new System.Drawing.Size(166, 23);
            this.server_password_box.TabIndex = 1;
            this.server_password_box.Text = "G2st4r!0182";
            this.server_password_box.UseSystemPasswordChar = true;
            // 
            // srever_user_box
            // 
            this.srever_user_box.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.srever_user_box.Location = new System.Drawing.Point(87, 101);
            this.srever_user_box.Name = "srever_user_box";
            this.srever_user_box.Size = new System.Drawing.Size(166, 23);
            this.srever_user_box.TabIndex = 1;
            this.srever_user_box.Text = "sa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(322, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password";
            // 
            // server_address_box
            // 
            this.server_address_box.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.server_address_box.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.server_address_box.Location = new System.Drawing.Point(87, 49);
            this.server_address_box.Name = "server_address_box";
            this.server_address_box.Size = new System.Drawing.Size(477, 23);
            this.server_address_box.TabIndex = 1;
            this.server_address_box.Text = "SERVIDOR\\SERVMETATECNICS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "User";
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TimeBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.confirm_button);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.groupBox2.Location = new System.Drawing.Point(5, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Perfermence Setting";
            // 
            // TimeBox
            // 
            this.TimeBox.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.TimeBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TimeBox.Location = new System.Drawing.Point(147, 43);
            this.TimeBox.Name = "TimeBox";
            this.TimeBox.Size = new System.Drawing.Size(248, 23);
            this.TimeBox.TabIndex = 2;
            this.TimeBox.Text = "5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Time Interval(min)";
            // 
            // confirm_button
            // 
            this.confirm_button.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.confirm_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirm_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.confirm_button.Location = new System.Drawing.Point(426, 37);
            this.confirm_button.Name = "confirm_button";
            this.confirm_button.Size = new System.Drawing.Size(138, 33);
            this.confirm_button.TabIndex = 7;
            this.confirm_button.Text = "Start";
            this.confirm_button.UseVisualStyleBackColor = false;
            this.confirm_button.Click += new System.EventHandler(this.Confirm_button_Click);
            // 
            // dialog_label
            // 
            this.dialog_label.AutoSize = true;
            this.dialog_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialog_label.Location = new System.Drawing.Point(82, 406);
            this.dialog_label.Name = "dialog_label";
            this.dialog_label.Size = new System.Drawing.Size(0, 21);
            this.dialog_label.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 269);
            this.Controls.Add(this.dialog_label);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Gmail Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox server_password_box;
        private System.Windows.Forms.TextBox srever_user_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox server_address_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button confirm_button;
        private System.Windows.Forms.TextBox TimeBox;
        private System.Windows.Forms.Label dialog_label;
    }
}

