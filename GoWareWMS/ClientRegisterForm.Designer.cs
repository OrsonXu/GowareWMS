namespace GoWareWMS
{
    partial class ClientRegisterForm
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
            this.groupBox_type = new System.Windows.Forms.GroupBox();
            this.radioButton_corporate = new System.Windows.Forms.RadioButton();
            this.radioButton_personal = new System.Windows.Forms.RadioButton();
            this.groupBox_personal = new System.Windows.Forms.GroupBox();
            this.label_sex = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_middle_name = new System.Windows.Forms.Label();
            this.label_first_name = new System.Windows.Forms.Label();
            this.textBox_lastname = new System.Windows.Forms.TextBox();
            this.groupBox_personal_sex = new System.Windows.Forms.GroupBox();
            this.radioButton_sex_f = new System.Windows.Forms.RadioButton();
            this.radioButton_sex_m = new System.Windows.Forms.RadioButton();
            this.textBox_middlename = new System.Windows.Forms.TextBox();
            this.textBox_firstname = new System.Windows.Forms.TextBox();
            this.groupBox_corporate = new System.Windows.Forms.GroupBox();
            this.label_company_name = new System.Windows.Forms.Label();
            this.textBox_companyname = new System.Windows.Forms.TextBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.groupBox_both = new System.Windows.Forms.GroupBox();
            this.btn_register = new System.Windows.Forms.Button();
            this.groupBox_type.SuspendLayout();
            this.groupBox_personal.SuspendLayout();
            this.groupBox_personal_sex.SuspendLayout();
            this.groupBox_corporate.SuspendLayout();
            this.groupBox_both.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_type
            // 
            this.groupBox_type.Controls.Add(this.radioButton_corporate);
            this.groupBox_type.Controls.Add(this.radioButton_personal);
            this.groupBox_type.Location = new System.Drawing.Point(204, 2);
            this.groupBox_type.Name = "groupBox_type";
            this.groupBox_type.Size = new System.Drawing.Size(187, 44);
            this.groupBox_type.TabIndex = 0;
            this.groupBox_type.TabStop = false;
            this.groupBox_type.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_type_Paint);
            // 
            // radioButton_corporate
            // 
            this.radioButton_corporate.AutoSize = true;
            this.radioButton_corporate.Location = new System.Drawing.Point(112, 20);
            this.radioButton_corporate.Name = "radioButton_corporate";
            this.radioButton_corporate.Size = new System.Drawing.Size(71, 17);
            this.radioButton_corporate.TabIndex = 1;
            this.radioButton_corporate.TabStop = true;
            this.radioButton_corporate.Text = "Corporate";
            this.radioButton_corporate.UseVisualStyleBackColor = true;
            this.radioButton_corporate.Click += new System.EventHandler(this.radioButton_corporate_Click);
            // 
            // radioButton_personal
            // 
            this.radioButton_personal.AutoSize = true;
            this.radioButton_personal.Location = new System.Drawing.Point(40, 20);
            this.radioButton_personal.Name = "radioButton_personal";
            this.radioButton_personal.Size = new System.Drawing.Size(66, 17);
            this.radioButton_personal.TabIndex = 0;
            this.radioButton_personal.TabStop = true;
            this.radioButton_personal.Text = "Personal";
            this.radioButton_personal.UseVisualStyleBackColor = true;
            this.radioButton_personal.Click += new System.EventHandler(this.radioButton_personal_Click);
            // 
            // groupBox_personal
            // 
            this.groupBox_personal.Controls.Add(this.label_sex);
            this.groupBox_personal.Controls.Add(this.label1);
            this.groupBox_personal.Controls.Add(this.label_middle_name);
            this.groupBox_personal.Controls.Add(this.label_first_name);
            this.groupBox_personal.Controls.Add(this.textBox_lastname);
            this.groupBox_personal.Controls.Add(this.groupBox_personal_sex);
            this.groupBox_personal.Controls.Add(this.textBox_middlename);
            this.groupBox_personal.Controls.Add(this.textBox_firstname);
            this.groupBox_personal.Location = new System.Drawing.Point(189, 133);
            this.groupBox_personal.Name = "groupBox_personal";
            this.groupBox_personal.Size = new System.Drawing.Size(250, 132);
            this.groupBox_personal.TabIndex = 1;
            this.groupBox_personal.TabStop = false;
            this.groupBox_personal.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_personal_Paint);
            // 
            // label_sex
            // 
            this.label_sex.AutoSize = true;
            this.label_sex.Location = new System.Drawing.Point(47, 106);
            this.label_sex.Name = "label_sex";
            this.label_sex.Size = new System.Drawing.Size(35, 13);
            this.label_sex.TabIndex = 7;
            this.label_sex.Text = "Sex* :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Last Name* :";
            // 
            // label_middle_name
            // 
            this.label_middle_name.AutoSize = true;
            this.label_middle_name.Location = new System.Drawing.Point(7, 51);
            this.label_middle_name.Name = "label_middle_name";
            this.label_middle_name.Size = new System.Drawing.Size(75, 13);
            this.label_middle_name.TabIndex = 5;
            this.label_middle_name.Text = "Middle Name :";
            // 
            // label_first_name
            // 
            this.label_first_name.AutoSize = true;
            this.label_first_name.Location = new System.Drawing.Point(15, 22);
            this.label_first_name.Name = "label_first_name";
            this.label_first_name.Size = new System.Drawing.Size(67, 13);
            this.label_first_name.TabIndex = 4;
            this.label_first_name.Text = "First Name* :";
            // 
            // textBox_lastname
            // 
            this.textBox_lastname.Location = new System.Drawing.Point(98, 77);
            this.textBox_lastname.Name = "textBox_lastname";
            this.textBox_lastname.Size = new System.Drawing.Size(100, 20);
            this.textBox_lastname.TabIndex = 2;
            // 
            // groupBox_personal_sex
            // 
            this.groupBox_personal_sex.Controls.Add(this.radioButton_sex_f);
            this.groupBox_personal_sex.Controls.Add(this.radioButton_sex_m);
            this.groupBox_personal_sex.Location = new System.Drawing.Point(114, 87);
            this.groupBox_personal_sex.Name = "groupBox_personal_sex";
            this.groupBox_personal_sex.Size = new System.Drawing.Size(87, 40);
            this.groupBox_personal_sex.TabIndex = 3;
            this.groupBox_personal_sex.TabStop = false;
            this.groupBox_personal_sex.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_personal_sex_Paint);
            // 
            // radioButton_sex_f
            // 
            this.radioButton_sex_f.AutoSize = true;
            this.radioButton_sex_f.Location = new System.Drawing.Point(39, 17);
            this.radioButton_sex_f.Name = "radioButton_sex_f";
            this.radioButton_sex_f.Size = new System.Drawing.Size(31, 17);
            this.radioButton_sex_f.TabIndex = 1;
            this.radioButton_sex_f.TabStop = true;
            this.radioButton_sex_f.Text = "F";
            this.radioButton_sex_f.UseVisualStyleBackColor = true;
            this.radioButton_sex_f.Click += new System.EventHandler(this.radioButton_sex_f_Click);
            // 
            // radioButton_sex_m
            // 
            this.radioButton_sex_m.AutoSize = true;
            this.radioButton_sex_m.Location = new System.Drawing.Point(7, 17);
            this.radioButton_sex_m.Name = "radioButton_sex_m";
            this.radioButton_sex_m.Size = new System.Drawing.Size(34, 17);
            this.radioButton_sex_m.TabIndex = 0;
            this.radioButton_sex_m.TabStop = true;
            this.radioButton_sex_m.Text = "M";
            this.radioButton_sex_m.UseVisualStyleBackColor = true;
            this.radioButton_sex_m.Click += new System.EventHandler(this.radioButton_sex_m_Click);
            // 
            // textBox_middlename
            // 
            this.textBox_middlename.Location = new System.Drawing.Point(98, 48);
            this.textBox_middlename.Name = "textBox_middlename";
            this.textBox_middlename.Size = new System.Drawing.Size(100, 20);
            this.textBox_middlename.TabIndex = 1;
            // 
            // textBox_firstname
            // 
            this.textBox_firstname.Location = new System.Drawing.Point(98, 19);
            this.textBox_firstname.Name = "textBox_firstname";
            this.textBox_firstname.Size = new System.Drawing.Size(100, 20);
            this.textBox_firstname.TabIndex = 0;
            // 
            // groupBox_corporate
            // 
            this.groupBox_corporate.Controls.Add(this.label_company_name);
            this.groupBox_corporate.Controls.Add(this.textBox_companyname);
            this.groupBox_corporate.Location = new System.Drawing.Point(139, 133);
            this.groupBox_corporate.Name = "groupBox_corporate";
            this.groupBox_corporate.Size = new System.Drawing.Size(265, 51);
            this.groupBox_corporate.TabIndex = 2;
            this.groupBox_corporate.TabStop = false;
            this.groupBox_corporate.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_corporate_Paint);
            // 
            // label_company_name
            // 
            this.label_company_name.AutoSize = true;
            this.label_company_name.Location = new System.Drawing.Point(42, 22);
            this.label_company_name.Name = "label_company_name";
            this.label_company_name.Size = new System.Drawing.Size(92, 13);
            this.label_company_name.TabIndex = 1;
            this.label_company_name.Text = "Company Name* :";
            // 
            // textBox_companyname
            // 
            this.textBox_companyname.Location = new System.Drawing.Point(148, 19);
            this.textBox_companyname.Name = "textBox_companyname";
            this.textBox_companyname.Size = new System.Drawing.Size(100, 20);
            this.textBox_companyname.TabIndex = 0;
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(83, 18);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(100, 20);
            this.textBox_username.TabIndex = 3;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(83, 45);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(100, 20);
            this.textBox_password.TabIndex = 4;
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(83, 72);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(100, 20);
            this.textBox_email.TabIndex = 5;
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Location = new System.Drawing.Point(4, 21);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(65, 13);
            this.label_username.TabIndex = 6;
            this.label_username.Text = "Username* :";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(4, 48);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(63, 13);
            this.label_password.TabIndex = 7;
            this.label_password.Text = "Password* :";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(25, 75);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(42, 13);
            this.label_email.TabIndex = 8;
            this.label_email.Text = "Email* :";
            // 
            // groupBox_both
            // 
            this.groupBox_both.Controls.Add(this.textBox_password);
            this.groupBox_both.Controls.Add(this.label_email);
            this.groupBox_both.Controls.Add(this.textBox_username);
            this.groupBox_both.Controls.Add(this.label_password);
            this.groupBox_both.Controls.Add(this.textBox_email);
            this.groupBox_both.Controls.Add(this.label_username);
            this.groupBox_both.Location = new System.Drawing.Point(204, 52);
            this.groupBox_both.Name = "groupBox_both";
            this.groupBox_both.Size = new System.Drawing.Size(200, 100);
            this.groupBox_both.TabIndex = 9;
            this.groupBox_both.TabStop = false;
            this.groupBox_both.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_both_Paint);
            // 
            // btn_register
            // 
            this.btn_register.Location = new System.Drawing.Point(269, 281);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(75, 23);
            this.btn_register.TabIndex = 10;
            this.btn_register.Text = "Register";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // ClientRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(638, 325);
            this.Controls.Add(this.groupBox_type);
            this.Controls.Add(this.groupBox_both);
            this.Controls.Add(this.groupBox_corporate);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.groupBox_personal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientRegisterForm";
            this.Text = "ClientRegisterForm";
            this.groupBox_type.ResumeLayout(false);
            this.groupBox_type.PerformLayout();
            this.groupBox_personal.ResumeLayout(false);
            this.groupBox_personal.PerformLayout();
            this.groupBox_personal_sex.ResumeLayout(false);
            this.groupBox_personal_sex.PerformLayout();
            this.groupBox_corporate.ResumeLayout(false);
            this.groupBox_corporate.PerformLayout();
            this.groupBox_both.ResumeLayout(false);
            this.groupBox_both.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_type;
        private System.Windows.Forms.RadioButton radioButton_corporate;
        private System.Windows.Forms.RadioButton radioButton_personal;
        private System.Windows.Forms.GroupBox groupBox_personal;
        private System.Windows.Forms.GroupBox groupBox_corporate;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.GroupBox groupBox_personal_sex;
        private System.Windows.Forms.RadioButton radioButton_sex_m;
        private System.Windows.Forms.TextBox textBox_lastname;
        private System.Windows.Forms.TextBox textBox_middlename;
        private System.Windows.Forms.TextBox textBox_firstname;
        private System.Windows.Forms.Label label_middle_name;
        private System.Windows.Forms.Label label_first_name;
        private System.Windows.Forms.RadioButton radioButton_sex_f;
        private System.Windows.Forms.Label label_sex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_company_name;
        private System.Windows.Forms.TextBox textBox_companyname;
        private System.Windows.Forms.GroupBox groupBox_both;
        private System.Windows.Forms.Button btn_register;
    }
}