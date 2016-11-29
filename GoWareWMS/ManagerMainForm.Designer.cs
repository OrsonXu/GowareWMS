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
            this.dataGridView_manager = new System.Windows.Forms.DataGridView();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_history = new System.Windows.Forms.RadioButton();
            this.radioButton_inventory = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox_alter = new System.Windows.Forms.GroupBox();
            this.textBox_alter_fee = new System.Windows.Forms.TextBox();
            this.ulabel_changed_fee = new System.Windows.Forms.Label();
            this.label_current_fee = new System.Windows.Forms.Label();
            this.ulabel_current_fee = new System.Windows.Forms.Label();
            this.label_alter_name = new System.Windows.Forms.Label();
            this.manage_comboBox = new System.Windows.Forms.ComboBox();
            this.groupBox_add = new System.Windows.Forms.GroupBox();
            this.textBox_add_fee = new System.Windows.Forms.TextBox();
            this.textBox_add_name = new System.Windows.Forms.TextBox();
            this.label_add_fee = new System.Windows.Forms.Label();
            this.label_add_name = new System.Windows.Forms.Label();
            this.manage_btn_confirm = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton_category = new System.Windows.Forms.RadioButton();
            this.radioButton_warehouse = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_alter = new System.Windows.Forms.RadioButton();
            this.radioButton_add = new System.Windows.Forms.RadioButton();
            this.groupBox_add_address = new System.Windows.Forms.GroupBox();
            this.textBox_street = new System.Windows.Forms.TextBox();
            this.textBox_city = new System.Windows.Forms.TextBox();
            this.textBox_country = new System.Windows.Forms.TextBox();
            this.label_street = new System.Windows.Forms.Label();
            this.label_city = new System.Windows.Forms.Label();
            this.label_country = new System.Windows.Forms.Label();
            this.label_tel = new System.Windows.Forms.Label();
            this.textBox_tel = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_manager)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox_alter.SuspendLayout();
            this.groupBox_add.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox_add_address.SuspendLayout();
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
            this.tabPage1.Controls.Add(this.dataGridView_manager);
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
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(707, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView_manager
            // 
            this.dataGridView_manager.AllowUserToAddRows = false;
            this.dataGridView_manager.AllowUserToDeleteRows = false;
            this.dataGridView_manager.AllowUserToResizeColumns = false;
            this.dataGridView_manager.AllowUserToResizeRows = false;
            this.dataGridView_manager.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_manager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_manager.Location = new System.Drawing.Point(24, 100);
            this.dataGridView_manager.MultiSelect = false;
            this.dataGridView_manager.Name = "dataGridView_manager";
            this.dataGridView_manager.ReadOnly = true;
            this.dataGridView_manager.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_manager.Size = new System.Drawing.Size(654, 236);
            this.dataGridView_manager.TabIndex = 11;
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
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.radioButton_history);
            this.groupBox1.Controls.Add(this.radioButton_inventory);
            this.groupBox1.Location = new System.Drawing.Point(419, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 118);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // radioButton_history
            // 
            this.radioButton_history.AutoSize = true;
            this.radioButton_history.Location = new System.Drawing.Point(27, 53);
            this.radioButton_history.Name = "radioButton_history";
            this.radioButton_history.Size = new System.Drawing.Size(57, 17);
            this.radioButton_history.TabIndex = 1;
            this.radioButton_history.TabStop = true;
            this.radioButton_history.Text = "History";
            this.radioButton_history.UseVisualStyleBackColor = true;
            this.radioButton_history.CheckedChanged += new System.EventHandler(this.radioButton_history_CheckedChanged);
            // 
            // radioButton_inventory
            // 
            this.radioButton_inventory.AutoSize = true;
            this.radioButton_inventory.Location = new System.Drawing.Point(27, 30);
            this.radioButton_inventory.Name = "radioButton_inventory";
            this.radioButton_inventory.Size = new System.Drawing.Size(69, 17);
            this.radioButton_inventory.TabIndex = 0;
            this.radioButton_inventory.TabStop = true;
            this.radioButton_inventory.Text = "Inventory";
            this.radioButton_inventory.UseVisualStyleBackColor = true;
            this.radioButton_inventory.CheckedChanged += new System.EventHandler(this.radioButton_inventory_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox_add_address);
            this.tabPage2.Controls.Add(this.groupBox_alter);
            this.tabPage2.Controls.Add(this.groupBox_add);
            this.tabPage2.Controls.Add(this.manage_btn_confirm);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(707, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manage";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox_alter
            // 
            this.groupBox_alter.AutoSize = true;
            this.groupBox_alter.Controls.Add(this.textBox_alter_fee);
            this.groupBox_alter.Controls.Add(this.ulabel_changed_fee);
            this.groupBox_alter.Controls.Add(this.label_current_fee);
            this.groupBox_alter.Controls.Add(this.ulabel_current_fee);
            this.groupBox_alter.Controls.Add(this.label_alter_name);
            this.groupBox_alter.Controls.Add(this.manage_comboBox);
            this.groupBox_alter.Location = new System.Drawing.Point(250, 177);
            this.groupBox_alter.Name = "groupBox_alter";
            this.groupBox_alter.Size = new System.Drawing.Size(201, 139);
            this.groupBox_alter.TabIndex = 4;
            this.groupBox_alter.TabStop = false;
            this.groupBox_alter.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_alter_Paint);
            // 
            // textBox_alter_fee
            // 
            this.textBox_alter_fee.Location = new System.Drawing.Point(74, 100);
            this.textBox_alter_fee.Name = "textBox_alter_fee";
            this.textBox_alter_fee.Size = new System.Drawing.Size(120, 20);
            this.textBox_alter_fee.TabIndex = 5;
            // 
            // ulabel_changed_fee
            // 
            this.ulabel_changed_fee.AutoSize = true;
            this.ulabel_changed_fee.Location = new System.Drawing.Point(26, 95);
            this.ulabel_changed_fee.Name = "ulabel_changed_fee";
            this.ulabel_changed_fee.Size = new System.Drawing.Size(31, 26);
            this.ulabel_changed_fee.TabIndex = 4;
            this.ulabel_changed_fee.Text = "New\r\nFee :";
            // 
            // label_current_fee
            // 
            this.label_current_fee.AutoSize = true;
            this.label_current_fee.Location = new System.Drawing.Point(73, 69);
            this.label_current_fee.Name = "label_current_fee";
            this.label_current_fee.Size = new System.Drawing.Size(35, 13);
            this.label_current_fee.TabIndex = 3;
            this.label_current_fee.Text = "label1";
            // 
            // ulabel_current_fee
            // 
            this.ulabel_current_fee.AutoSize = true;
            this.ulabel_current_fee.Location = new System.Drawing.Point(26, 60);
            this.ulabel_current_fee.Name = "ulabel_current_fee";
            this.ulabel_current_fee.Size = new System.Drawing.Size(41, 26);
            this.ulabel_current_fee.TabIndex = 2;
            this.ulabel_current_fee.Text = "Current\r\nFee :";
            // 
            // label_alter_name
            // 
            this.label_alter_name.AutoSize = true;
            this.label_alter_name.Location = new System.Drawing.Point(27, 36);
            this.label_alter_name.Name = "label_alter_name";
            this.label_alter_name.Size = new System.Drawing.Size(41, 13);
            this.label_alter_name.TabIndex = 1;
            this.label_alter_name.Text = "Name :";
            // 
            // manage_comboBox
            // 
            this.manage_comboBox.FormattingEnabled = true;
            this.manage_comboBox.Location = new System.Drawing.Point(74, 33);
            this.manage_comboBox.Name = "manage_comboBox";
            this.manage_comboBox.Size = new System.Drawing.Size(121, 21);
            this.manage_comboBox.TabIndex = 0;
            // 
            // groupBox_add
            // 
            this.groupBox_add.AutoSize = true;
            this.groupBox_add.Controls.Add(this.textBox_add_fee);
            this.groupBox_add.Controls.Add(this.textBox_add_name);
            this.groupBox_add.Controls.Add(this.label_add_fee);
            this.groupBox_add.Controls.Add(this.label_add_name);
            this.groupBox_add.Location = new System.Drawing.Point(250, 53);
            this.groupBox_add.Name = "groupBox_add";
            this.groupBox_add.Size = new System.Drawing.Size(200, 82);
            this.groupBox_add.TabIndex = 3;
            this.groupBox_add.TabStop = false;
            this.groupBox_add.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_add_Paint);
            // 
            // textBox_add_fee
            // 
            this.textBox_add_fee.Location = new System.Drawing.Point(74, 43);
            this.textBox_add_fee.Name = "textBox_add_fee";
            this.textBox_add_fee.Size = new System.Drawing.Size(120, 20);
            this.textBox_add_fee.TabIndex = 3;
            // 
            // textBox_add_name
            // 
            this.textBox_add_name.Location = new System.Drawing.Point(74, 17);
            this.textBox_add_name.Name = "textBox_add_name";
            this.textBox_add_name.Size = new System.Drawing.Size(120, 20);
            this.textBox_add_name.TabIndex = 2;
            // 
            // label_add_fee
            // 
            this.label_add_fee.AutoSize = true;
            this.label_add_fee.Location = new System.Drawing.Point(26, 46);
            this.label_add_fee.Name = "label_add_fee";
            this.label_add_fee.Size = new System.Drawing.Size(31, 13);
            this.label_add_fee.TabIndex = 1;
            this.label_add_fee.Text = "Fee :";
            // 
            // label_add_name
            // 
            this.label_add_name.AutoSize = true;
            this.label_add_name.Location = new System.Drawing.Point(26, 20);
            this.label_add_name.Name = "label_add_name";
            this.label_add_name.Size = new System.Drawing.Size(41, 13);
            this.label_add_name.TabIndex = 0;
            this.label_add_name.Text = "Name :";
            // 
            // manage_btn_confirm
            // 
            this.manage_btn_confirm.Location = new System.Drawing.Point(504, 158);
            this.manage_btn_confirm.Name = "manage_btn_confirm";
            this.manage_btn_confirm.Size = new System.Drawing.Size(75, 23);
            this.manage_btn_confirm.TabIndex = 2;
            this.manage_btn_confirm.Text = "Confirm";
            this.manage_btn_confirm.UseVisualStyleBackColor = true;
            this.manage_btn_confirm.Click += new System.EventHandler(this.manage_btn_confirm_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.radioButton_category);
            this.groupBox3.Controls.Add(this.radioButton_warehouse);
            this.groupBox3.Location = new System.Drawing.Point(104, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(115, 103);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox3_Paint);
            // 
            // radioButton_category
            // 
            this.radioButton_category.AutoSize = true;
            this.radioButton_category.Location = new System.Drawing.Point(29, 67);
            this.radioButton_category.Name = "radioButton_category";
            this.radioButton_category.Size = new System.Drawing.Size(67, 17);
            this.radioButton_category.TabIndex = 1;
            this.radioButton_category.TabStop = true;
            this.radioButton_category.Text = "Category";
            this.radioButton_category.UseVisualStyleBackColor = true;
            this.radioButton_category.CheckedChanged += new System.EventHandler(this.radioButton_category_CheckedChanged);
            // 
            // radioButton_warehouse
            // 
            this.radioButton_warehouse.AutoSize = true;
            this.radioButton_warehouse.Location = new System.Drawing.Point(29, 32);
            this.radioButton_warehouse.Name = "radioButton_warehouse";
            this.radioButton_warehouse.Size = new System.Drawing.Size(80, 17);
            this.radioButton_warehouse.TabIndex = 0;
            this.radioButton_warehouse.TabStop = true;
            this.radioButton_warehouse.Text = "Warehouse";
            this.radioButton_warehouse.UseVisualStyleBackColor = true;
            this.radioButton_warehouse.CheckedChanged += new System.EventHandler(this.radioButton_warehouse_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.radioButton_alter);
            this.groupBox2.Controls.Add(this.radioButton_add);
            this.groupBox2.Location = new System.Drawing.Point(30, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(88, 103);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint_1);
            // 
            // radioButton_alter
            // 
            this.radioButton_alter.AutoSize = true;
            this.radioButton_alter.Location = new System.Drawing.Point(30, 67);
            this.radioButton_alter.Name = "radioButton_alter";
            this.radioButton_alter.Size = new System.Drawing.Size(46, 17);
            this.radioButton_alter.TabIndex = 1;
            this.radioButton_alter.TabStop = true;
            this.radioButton_alter.Text = "Alter";
            this.radioButton_alter.UseVisualStyleBackColor = true;
            this.radioButton_alter.CheckedChanged += new System.EventHandler(this.radioButton_alter_CheckedChanged);
            // 
            // radioButton_add
            // 
            this.radioButton_add.AutoSize = true;
            this.radioButton_add.Location = new System.Drawing.Point(30, 32);
            this.radioButton_add.Name = "radioButton_add";
            this.radioButton_add.Size = new System.Drawing.Size(44, 17);
            this.radioButton_add.TabIndex = 0;
            this.radioButton_add.TabStop = true;
            this.radioButton_add.Text = "Add";
            this.radioButton_add.UseVisualStyleBackColor = true;
            this.radioButton_add.CheckedChanged += new System.EventHandler(this.radioButton_add_CheckedChanged);
            // 
            // groupBox_add_address
            // 
            this.groupBox_add_address.Controls.Add(this.textBox_tel);
            this.groupBox_add_address.Controls.Add(this.label_tel);
            this.groupBox_add_address.Controls.Add(this.label_country);
            this.groupBox_add_address.Controls.Add(this.label_city);
            this.groupBox_add_address.Controls.Add(this.label_street);
            this.groupBox_add_address.Controls.Add(this.textBox_country);
            this.groupBox_add_address.Controls.Add(this.textBox_city);
            this.groupBox_add_address.Controls.Add(this.textBox_street);
            this.groupBox_add_address.Location = new System.Drawing.Point(475, 28);
            this.groupBox_add_address.Name = "groupBox_add_address";
            this.groupBox_add_address.Size = new System.Drawing.Size(200, 124);
            this.groupBox_add_address.TabIndex = 5;
            this.groupBox_add_address.TabStop = false;
            this.groupBox_add_address.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_add_address_Paint);
            // 
            // textBox_street
            // 
            this.textBox_street.Location = new System.Drawing.Point(64, 18);
            this.textBox_street.Name = "textBox_street";
            this.textBox_street.Size = new System.Drawing.Size(120, 20);
            this.textBox_street.TabIndex = 0;
            // 
            // textBox_city
            // 
            this.textBox_city.Location = new System.Drawing.Point(64, 44);
            this.textBox_city.Name = "textBox_city";
            this.textBox_city.Size = new System.Drawing.Size(120, 20);
            this.textBox_city.TabIndex = 1;
            // 
            // textBox_country
            // 
            this.textBox_country.Location = new System.Drawing.Point(64, 70);
            this.textBox_country.Name = "textBox_country";
            this.textBox_country.Size = new System.Drawing.Size(120, 20);
            this.textBox_country.TabIndex = 2;
            // 
            // label_street
            // 
            this.label_street.AutoSize = true;
            this.label_street.Location = new System.Drawing.Point(9, 21);
            this.label_street.Name = "label_street";
            this.label_street.Size = new System.Drawing.Size(41, 13);
            this.label_street.TabIndex = 3;
            this.label_street.Text = "Street :";
            // 
            // label_city
            // 
            this.label_city.AutoSize = true;
            this.label_city.Location = new System.Drawing.Point(9, 47);
            this.label_city.Name = "label_city";
            this.label_city.Size = new System.Drawing.Size(30, 13);
            this.label_city.TabIndex = 4;
            this.label_city.Text = "City :";
            // 
            // label_country
            // 
            this.label_country.AutoSize = true;
            this.label_country.Location = new System.Drawing.Point(9, 73);
            this.label_country.Name = "label_country";
            this.label_country.Size = new System.Drawing.Size(49, 13);
            this.label_country.TabIndex = 5;
            this.label_country.Text = "Country :";
            // 
            // label_tel
            // 
            this.label_tel.AutoSize = true;
            this.label_tel.Location = new System.Drawing.Point(9, 101);
            this.label_tel.Name = "label_tel";
            this.label_tel.Size = new System.Drawing.Size(33, 13);
            this.label_tel.TabIndex = 6;
            this.label_tel.Text = "TEL :";
            // 
            // textBox_tel
            // 
            this.textBox_tel.Location = new System.Drawing.Point(64, 98);
            this.textBox_tel.Name = "textBox_tel";
            this.textBox_tel.Size = new System.Drawing.Size(120, 20);
            this.textBox_tel.TabIndex = 7;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_manager)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox_alter.ResumeLayout(false);
            this.groupBox_alter.PerformLayout();
            this.groupBox_add.ResumeLayout(false);
            this.groupBox_add.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox_add_address.ResumeLayout(false);
            this.groupBox_add_address.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView_manager;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_history;
        private System.Windows.Forms.RadioButton radioButton_inventory;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton_category;
        private System.Windows.Forms.RadioButton radioButton_warehouse;
        private System.Windows.Forms.RadioButton radioButton_alter;
        private System.Windows.Forms.RadioButton radioButton_add;
        private System.Windows.Forms.GroupBox groupBox_add;
        private System.Windows.Forms.TextBox textBox_add_fee;
        private System.Windows.Forms.TextBox textBox_add_name;
        private System.Windows.Forms.Label label_add_fee;
        private System.Windows.Forms.Label label_add_name;
        private System.Windows.Forms.Button manage_btn_confirm;
        private System.Windows.Forms.GroupBox groupBox_alter;
        private System.Windows.Forms.TextBox textBox_alter_fee;
        private System.Windows.Forms.Label ulabel_changed_fee;
        private System.Windows.Forms.Label label_current_fee;
        private System.Windows.Forms.Label ulabel_current_fee;
        private System.Windows.Forms.Label label_alter_name;
        private System.Windows.Forms.ComboBox manage_comboBox;
        private System.Windows.Forms.GroupBox groupBox_add_address;
        private System.Windows.Forms.TextBox textBox_tel;
        private System.Windows.Forms.Label label_tel;
        private System.Windows.Forms.Label label_country;
        private System.Windows.Forms.Label label_city;
        private System.Windows.Forms.Label label_street;
        private System.Windows.Forms.TextBox textBox_country;
        private System.Windows.Forms.TextBox textBox_city;
        private System.Windows.Forms.TextBox textBox_street;

    }
}