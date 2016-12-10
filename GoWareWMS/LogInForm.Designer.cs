namespace GoWareWMS
{
    partial class LogInForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_client_register = new System.Windows.Forms.Button();
            this.title_client = new System.Windows.Forms.Label();
            this.btn_client_login = new System.Windows.Forms.Button();
            this.textBox_pwd_client = new System.Windows.Forms.TextBox();
            this.textBox_username_client = new System.Windows.Forms.TextBox();
            this.label_pwd_client = new System.Windows.Forms.Label();
            this.label_username_client = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_manager_register = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_manager_login = new System.Windows.Forms.Button();
            this.textBox_pwd_manager = new System.Windows.Forms.TextBox();
            this.textBox_username_manager = new System.Windows.Forms.TextBox();
            this.label_pwd_manager = new System.Windows.Forms.Label();
            this.label_username_manager = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(609, 309);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_client_register);
            this.tabPage1.Controls.Add(this.title_client);
            this.tabPage1.Controls.Add(this.btn_client_login);
            this.tabPage1.Controls.Add(this.textBox_pwd_client);
            this.tabPage1.Controls.Add(this.textBox_username_client);
            this.tabPage1.Controls.Add(this.label_pwd_client);
            this.tabPage1.Controls.Add(this.label_username_client);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(601, 283);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Client Login";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_client_register
            // 
            this.btn_client_register.Location = new System.Drawing.Point(271, 201);
            this.btn_client_register.Name = "btn_client_register";
            this.btn_client_register.Size = new System.Drawing.Size(87, 23);
            this.btn_client_register.TabIndex = 6;
            this.btn_client_register.Text = "Register";
            this.btn_client_register.UseVisualStyleBackColor = true;
            this.btn_client_register.Click += new System.EventHandler(this.btn_client_register_Click);
            // 
            // title_client
            // 
            this.title_client.AutoSize = true;
            this.title_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_client.Location = new System.Drawing.Point(180, 20);
            this.title_client.Name = "title_client";
            this.title_client.Size = new System.Drawing.Size(206, 25);
            this.title_client.TabIndex = 5;
            this.title_client.Text = "Welcome to Goware";
            // 
            // btn_client_login
            // 
            this.btn_client_login.Location = new System.Drawing.Point(271, 160);
            this.btn_client_login.Name = "btn_client_login";
            this.btn_client_login.Size = new System.Drawing.Size(87, 23);
            this.btn_client_login.TabIndex = 4;
            this.btn_client_login.Text = "Login";
            this.btn_client_login.UseVisualStyleBackColor = true;
            this.btn_client_login.Click += new System.EventHandler(this.btn_client_login_Click);
            // 
            // textBox_pwd_client
            // 
            this.textBox_pwd_client.Location = new System.Drawing.Point(257, 115);
            this.textBox_pwd_client.Name = "textBox_pwd_client";
            this.textBox_pwd_client.PasswordChar = '*';
            this.textBox_pwd_client.Size = new System.Drawing.Size(116, 20);
            this.textBox_pwd_client.TabIndex = 3;
            // 
            // textBox_username_client
            // 
            this.textBox_username_client.Location = new System.Drawing.Point(257, 80);
            this.textBox_username_client.Name = "textBox_username_client";
            this.textBox_username_client.Size = new System.Drawing.Size(116, 20);
            this.textBox_username_client.TabIndex = 2;
            // 
            // label_pwd_client
            // 
            this.label_pwd_client.AutoSize = true;
            this.label_pwd_client.Location = new System.Drawing.Point(175, 118);
            this.label_pwd_client.Name = "label_pwd_client";
            this.label_pwd_client.Size = new System.Drawing.Size(53, 13);
            this.label_pwd_client.TabIndex = 1;
            this.label_pwd_client.Text = "Password";
            // 
            // label_username_client
            // 
            this.label_username_client.AutoSize = true;
            this.label_username_client.Location = new System.Drawing.Point(175, 83);
            this.label_username_client.Name = "label_username_client";
            this.label_username_client.Size = new System.Drawing.Size(55, 13);
            this.label_username_client.TabIndex = 0;
            this.label_username_client.Text = "Username";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_manager_register);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btn_manager_login);
            this.tabPage2.Controls.Add(this.textBox_pwd_manager);
            this.tabPage2.Controls.Add(this.textBox_username_manager);
            this.tabPage2.Controls.Add(this.label_pwd_manager);
            this.tabPage2.Controls.Add(this.label_username_manager);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(601, 283);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manager Login";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_manager_register
            // 
            this.btn_manager_register.Location = new System.Drawing.Point(271, 201);
            this.btn_manager_register.Name = "btn_manager_register";
            this.btn_manager_register.Size = new System.Drawing.Size(87, 23);
            this.btn_manager_register.TabIndex = 6;
            this.btn_manager_register.Text = "Register";
            this.btn_manager_register.UseVisualStyleBackColor = true;
            this.btn_manager_register.Click += new System.EventHandler(this.btn_manager_register_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(220, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Goware WMS";
            // 
            // btn_manager_login
            // 
            this.btn_manager_login.Location = new System.Drawing.Point(271, 160);
            this.btn_manager_login.Name = "btn_manager_login";
            this.btn_manager_login.Size = new System.Drawing.Size(87, 23);
            this.btn_manager_login.TabIndex = 4;
            this.btn_manager_login.Text = "Login";
            this.btn_manager_login.UseVisualStyleBackColor = true;
            this.btn_manager_login.Click += new System.EventHandler(this.btn_manager_login_Click);
            // 
            // textBox_pwd_manager
            // 
            this.textBox_pwd_manager.Location = new System.Drawing.Point(257, 115);
            this.textBox_pwd_manager.Name = "textBox_pwd_manager";
            this.textBox_pwd_manager.PasswordChar = '*';
            this.textBox_pwd_manager.Size = new System.Drawing.Size(116, 20);
            this.textBox_pwd_manager.TabIndex = 3;
            // 
            // textBox_username_manager
            // 
            this.textBox_username_manager.Location = new System.Drawing.Point(257, 80);
            this.textBox_username_manager.Name = "textBox_username_manager";
            this.textBox_username_manager.Size = new System.Drawing.Size(116, 20);
            this.textBox_username_manager.TabIndex = 2;
            // 
            // label_pwd_manager
            // 
            this.label_pwd_manager.AutoSize = true;
            this.label_pwd_manager.Location = new System.Drawing.Point(175, 118);
            this.label_pwd_manager.Name = "label_pwd_manager";
            this.label_pwd_manager.Size = new System.Drawing.Size(53, 13);
            this.label_pwd_manager.TabIndex = 1;
            this.label_pwd_manager.Text = "Password";
            // 
            // label_username_manager
            // 
            this.label_username_manager.AutoSize = true;
            this.label_username_manager.Location = new System.Drawing.Point(175, 83);
            this.label_username_manager.Name = "label_username_manager";
            this.label_username_manager.Size = new System.Drawing.Size(55, 13);
            this.label_username_manager.TabIndex = 0;
            this.label_username_manager.Text = "Username";
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 309);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogInForm";
            this.Text = "Login - Goware";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_manager_login;
        private System.Windows.Forms.TextBox textBox_pwd_manager;
        private System.Windows.Forms.TextBox textBox_username_manager;
        private System.Windows.Forms.Label label_pwd_manager;
        private System.Windows.Forms.Label label_username_manager;
        private System.Windows.Forms.Button btn_client_login;
        private System.Windows.Forms.TextBox textBox_pwd_client;
        private System.Windows.Forms.TextBox textBox_username_client;
        private System.Windows.Forms.Label label_pwd_client;
        private System.Windows.Forms.Label label_username_client;
        private System.Windows.Forms.Label title_client;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_client_register;
        private System.Windows.Forms.Button btn_manager_register;
    }
}

