namespace GoWareWMS
{
    partial class ClientMainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView_client = new System.Windows.Forms.DataGridView();
            this.button_search = new System.Windows.Forms.Button();
            this.view_label_InvNO = new System.Windows.Forms.Label();
            this.view_textBox_InvNO = new System.Windows.Forms.TextBox();
            this.view_comboBox_warehouse = new System.Windows.Forms.ComboBox();
            this.view_label_warehouse = new System.Windows.Forms.Label();
            this.view_label_dateBefore = new System.Windows.Forms.Label();
            this.view_label_dateAfter = new System.Windows.Forms.Label();
            this.view_label_category = new System.Windows.Forms.Label();
            this.dateTimePicker_before = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_after = new System.Windows.Forms.DateTimePicker();
            this.view_comboBox_category = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkin_btn_checkin = new System.Windows.Forms.Button();
            this.checkin_comboBox_warehouse = new System.Windows.Forms.ComboBox();
            this.checkin_comboBox_category = new System.Windows.Forms.ComboBox();
            this.checkin_label_warehouse = new System.Windows.Forms.Label();
            this.checkin_label_description = new System.Windows.Forms.Label();
            this.checkin_label_category = new System.Windows.Forms.Label();
            this.checkin_textBox_description = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkout_btn_checkout = new System.Windows.Forms.Button();
            this.checkout_textBox_invNO = new System.Windows.Forms.TextBox();
            this.checkout_label_invNO = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_client)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(715, 378);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView_client);
            this.tabPage1.Controls.Add(this.button_search);
            this.tabPage1.Controls.Add(this.view_label_InvNO);
            this.tabPage1.Controls.Add(this.view_textBox_InvNO);
            this.tabPage1.Controls.Add(this.view_comboBox_warehouse);
            this.tabPage1.Controls.Add(this.view_label_warehouse);
            this.tabPage1.Controls.Add(this.view_label_dateBefore);
            this.tabPage1.Controls.Add(this.view_label_dateAfter);
            this.tabPage1.Controls.Add(this.view_label_category);
            this.tabPage1.Controls.Add(this.dateTimePicker_before);
            this.tabPage1.Controls.Add(this.dateTimePicker_after);
            this.tabPage1.Controls.Add(this.view_comboBox_category);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(707, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView_client
            // 
            this.dataGridView_client.AllowUserToAddRows = false;
            this.dataGridView_client.AllowUserToDeleteRows = false;
            this.dataGridView_client.AllowUserToResizeColumns = false;
            this.dataGridView_client.AllowUserToResizeRows = false;
            this.dataGridView_client.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_client.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_client.Location = new System.Drawing.Point(24, 100);
            this.dataGridView_client.MultiSelect = false;
            this.dataGridView_client.Name = "dataGridView_client";
            this.dataGridView_client.ReadOnly = true;
            this.dataGridView_client.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_client.Size = new System.Drawing.Size(654, 236);
            this.dataGridView_client.TabIndex = 11;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(603, 54);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 10;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // view_label_InvNO
            // 
            this.view_label_InvNO.AutoSize = true;
            this.view_label_InvNO.Location = new System.Drawing.Point(21, 57);
            this.view_label_InvNO.Name = "view_label_InvNO";
            this.view_label_InvNO.Size = new System.Drawing.Size(41, 13);
            this.view_label_InvNO.TabIndex = 9;
            this.view_label_InvNO.Text = "Inv NO";
            // 
            // view_textBox_InvNO
            // 
            this.view_textBox_InvNO.Location = new System.Drawing.Point(85, 54);
            this.view_textBox_InvNO.Name = "view_textBox_InvNO";
            this.view_textBox_InvNO.Size = new System.Drawing.Size(294, 20);
            this.view_textBox_InvNO.TabIndex = 8;
            // 
            // view_comboBox_warehouse
            // 
            this.view_comboBox_warehouse.FormattingEnabled = true;
            this.view_comboBox_warehouse.Location = new System.Drawing.Point(85, 16);
            this.view_comboBox_warehouse.Name = "view_comboBox_warehouse";
            this.view_comboBox_warehouse.Size = new System.Drawing.Size(87, 21);
            this.view_comboBox_warehouse.TabIndex = 7;
            // 
            // view_label_warehouse
            // 
            this.view_label_warehouse.AutoSize = true;
            this.view_label_warehouse.Location = new System.Drawing.Point(21, 19);
            this.view_label_warehouse.Name = "view_label_warehouse";
            this.view_label_warehouse.Size = new System.Drawing.Size(62, 13);
            this.view_label_warehouse.TabIndex = 6;
            this.view_label_warehouse.Text = "Warehouse";
            // 
            // view_label_dateBefore
            // 
            this.view_label_dateBefore.AutoSize = true;
            this.view_label_dateBefore.Location = new System.Drawing.Point(518, 19);
            this.view_label_dateBefore.Name = "view_label_dateBefore";
            this.view_label_dateBefore.Size = new System.Drawing.Size(64, 13);
            this.view_label_dateBefore.TabIndex = 5;
            this.view_label_dateBefore.Text = "Date Before";
            // 
            // view_label_dateAfter
            // 
            this.view_label_dateAfter.AutoSize = true;
            this.view_label_dateAfter.Location = new System.Drawing.Point(354, 19);
            this.view_label_dateAfter.Name = "view_label_dateAfter";
            this.view_label_dateAfter.Size = new System.Drawing.Size(55, 13);
            this.view_label_dateAfter.TabIndex = 4;
            this.view_label_dateAfter.Text = "Date After";
            // 
            // view_label_category
            // 
            this.view_label_category.AutoSize = true;
            this.view_label_category.Location = new System.Drawing.Point(192, 19);
            this.view_label_category.Name = "view_label_category";
            this.view_label_category.Size = new System.Drawing.Size(49, 13);
            this.view_label_category.TabIndex = 3;
            this.view_label_category.Text = "Category";
            // 
            // dateTimePicker_before
            // 
            this.dateTimePicker_before.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_before.Location = new System.Drawing.Point(583, 16);
            this.dateTimePicker_before.Name = "dateTimePicker_before";
            this.dateTimePicker_before.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker_before.TabIndex = 2;
            // 
            // dateTimePicker_after
            // 
            this.dateTimePicker_after.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_after.Location = new System.Drawing.Point(412, 16);
            this.dateTimePicker_after.Name = "dateTimePicker_after";
            this.dateTimePicker_after.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker_after.TabIndex = 1;
            // 
            // view_comboBox_category
            // 
            this.view_comboBox_category.FormattingEnabled = true;
            this.view_comboBox_category.Location = new System.Drawing.Point(241, 16);
            this.view_comboBox_category.Name = "view_comboBox_category";
            this.view_comboBox_category.Size = new System.Drawing.Size(75, 21);
            this.view_comboBox_category.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkin_btn_checkin);
            this.tabPage2.Controls.Add(this.checkin_comboBox_warehouse);
            this.tabPage2.Controls.Add(this.checkin_comboBox_category);
            this.tabPage2.Controls.Add(this.checkin_label_warehouse);
            this.tabPage2.Controls.Add(this.checkin_label_description);
            this.tabPage2.Controls.Add(this.checkin_label_category);
            this.tabPage2.Controls.Add(this.checkin_textBox_description);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(707, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CheckIn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkin_btn_checkin
            // 
            this.checkin_btn_checkin.Location = new System.Drawing.Point(463, 99);
            this.checkin_btn_checkin.Name = "checkin_btn_checkin";
            this.checkin_btn_checkin.Size = new System.Drawing.Size(85, 103);
            this.checkin_btn_checkin.TabIndex = 6;
            this.checkin_btn_checkin.Text = "CheckIn";
            this.checkin_btn_checkin.UseVisualStyleBackColor = true;
            this.checkin_btn_checkin.Click += new System.EventHandler(this.checkin_btn_checkin_Click);
            // 
            // checkin_comboBox_warehouse
            // 
            this.checkin_comboBox_warehouse.FormattingEnabled = true;
            this.checkin_comboBox_warehouse.Location = new System.Drawing.Point(227, 253);
            this.checkin_comboBox_warehouse.Name = "checkin_comboBox_warehouse";
            this.checkin_comboBox_warehouse.Size = new System.Drawing.Size(121, 21);
            this.checkin_comboBox_warehouse.TabIndex = 5;
            // 
            // checkin_comboBox_category
            // 
            this.checkin_comboBox_category.FormattingEnabled = true;
            this.checkin_comboBox_category.Location = new System.Drawing.Point(227, 52);
            this.checkin_comboBox_category.Name = "checkin_comboBox_category";
            this.checkin_comboBox_category.Size = new System.Drawing.Size(121, 21);
            this.checkin_comboBox_category.TabIndex = 4;
            // 
            // checkin_label_warehouse
            // 
            this.checkin_label_warehouse.AutoSize = true;
            this.checkin_label_warehouse.Location = new System.Drawing.Point(121, 256);
            this.checkin_label_warehouse.Name = "checkin_label_warehouse";
            this.checkin_label_warehouse.Size = new System.Drawing.Size(62, 13);
            this.checkin_label_warehouse.TabIndex = 3;
            this.checkin_label_warehouse.Text = "Warehouse";
            // 
            // checkin_label_description
            // 
            this.checkin_label_description.AutoSize = true;
            this.checkin_label_description.Location = new System.Drawing.Point(121, 96);
            this.checkin_label_description.Name = "checkin_label_description";
            this.checkin_label_description.Size = new System.Drawing.Size(90, 26);
            this.checkin_label_description.TabIndex = 2;
            this.checkin_label_description.Text = "Description\r\n(<200 characters)";
            // 
            // checkin_label_category
            // 
            this.checkin_label_category.AutoSize = true;
            this.checkin_label_category.Location = new System.Drawing.Point(121, 55);
            this.checkin_label_category.Name = "checkin_label_category";
            this.checkin_label_category.Size = new System.Drawing.Size(49, 13);
            this.checkin_label_category.TabIndex = 1;
            this.checkin_label_category.Text = "Category";
            // 
            // checkin_textBox_description
            // 
            this.checkin_textBox_description.Location = new System.Drawing.Point(124, 141);
            this.checkin_textBox_description.Multiline = true;
            this.checkin_textBox_description.Name = "checkin_textBox_description";
            this.checkin_textBox_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.checkin_textBox_description.Size = new System.Drawing.Size(224, 79);
            this.checkin_textBox_description.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkout_btn_checkout);
            this.tabPage3.Controls.Add(this.checkout_textBox_invNO);
            this.tabPage3.Controls.Add(this.checkout_label_invNO);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(707, 352);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "CheckOut";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkout_btn_checkout
            // 
            this.checkout_btn_checkout.Location = new System.Drawing.Point(244, 160);
            this.checkout_btn_checkout.Name = "checkout_btn_checkout";
            this.checkout_btn_checkout.Size = new System.Drawing.Size(271, 47);
            this.checkout_btn_checkout.TabIndex = 2;
            this.checkout_btn_checkout.Text = "Check Out";
            this.checkout_btn_checkout.UseVisualStyleBackColor = true;
            this.checkout_btn_checkout.Click += new System.EventHandler(this.checkout_btn_checkout_Click);
            // 
            // checkout_textBox_invNO
            // 
            this.checkout_textBox_invNO.Location = new System.Drawing.Point(244, 93);
            this.checkout_textBox_invNO.Name = "checkout_textBox_invNO";
            this.checkout_textBox_invNO.Size = new System.Drawing.Size(271, 20);
            this.checkout_textBox_invNO.TabIndex = 1;
            // 
            // checkout_label_invNO
            // 
            this.checkout_label_invNO.AutoSize = true;
            this.checkout_label_invNO.Location = new System.Drawing.Point(181, 96);
            this.checkout_label_invNO.Name = "checkout_label_invNO";
            this.checkout_label_invNO.Size = new System.Drawing.Size(41, 13);
            this.checkout_label_invNO.TabIndex = 0;
            this.checkout_label_invNO.Text = "Inv NO";
            // 
            // ClientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 378);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientMainForm";
            this.Text = "Client - Goware";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientMainForm_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_client)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_after;
        private System.Windows.Forms.ComboBox view_comboBox_category;
        private System.Windows.Forms.DateTimePicker dateTimePicker_before;
        private System.Windows.Forms.Label view_label_dateAfter;
        private System.Windows.Forms.Label view_label_category;
        private System.Windows.Forms.Label view_label_dateBefore;
        private System.Windows.Forms.ComboBox view_comboBox_warehouse;
        private System.Windows.Forms.Label view_label_warehouse;
        private System.Windows.Forms.DataGridView dataGridView_client;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Label view_label_InvNO;
        private System.Windows.Forms.TextBox view_textBox_InvNO;
        private System.Windows.Forms.Label checkin_label_category;
        private System.Windows.Forms.TextBox checkin_textBox_description;
        private System.Windows.Forms.ComboBox checkin_comboBox_warehouse;
        private System.Windows.Forms.ComboBox checkin_comboBox_category;
        private System.Windows.Forms.Label checkin_label_warehouse;
        private System.Windows.Forms.Label checkin_label_description;
        private System.Windows.Forms.Button checkin_btn_checkin;
        private System.Windows.Forms.Label checkout_label_invNO;
        private System.Windows.Forms.Button checkout_btn_checkout;
        private System.Windows.Forms.TextBox checkout_textBox_invNO;

    }
}