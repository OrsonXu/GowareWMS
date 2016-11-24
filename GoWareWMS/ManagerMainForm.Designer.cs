namespace GoWareWMS
{
    partial class ManagerMainForm
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_client)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(715, 378);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkedListBox1);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(707, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manage";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Inventory",
            "History"});
            this.checkedListBox1.Location = new System.Drawing.Point(520, 48);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(74, 30);
            this.checkedListBox1.TabIndex = 12;
            // 
            // ManagerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 378);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManagerMainForm";
            this.Text = "ManagerMainForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_client)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView_client;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Label view_label_InvNO;
        private System.Windows.Forms.TextBox view_textBox_InvNO;
        private System.Windows.Forms.ComboBox view_comboBox_warehouse;
        private System.Windows.Forms.Label view_label_warehouse;
        private System.Windows.Forms.Label view_label_dateBefore;
        private System.Windows.Forms.Label view_label_dateAfter;
        private System.Windows.Forms.Label view_label_category;
        private System.Windows.Forms.DateTimePicker dateTimePicker_before;
        private System.Windows.Forms.DateTimePicker dateTimePicker_after;
        private System.Windows.Forms.ComboBox view_comboBox_category;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}