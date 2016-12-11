using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace GoWareWMS
{
     
    public partial class ManagerMainForm : Form
    {
        private Manager manager;
        private DBConnect db_connect;

        private DataTable dt_warehouse_view;
        private DataColumn dc_warehouse_id_view;
        private DataColumn dc_warehouse_name_view;

        private DataTable dt_warehouse_manage;
        private DataColumn dc_warehouse_id_manage;
        private DataColumn dc_warehouse_name_manage;

        private DataTable dt_category_view;
        private DataColumn dc_category_id_view;
        private DataColumn dc_category_name_view;

        private DataTable dt_category_manage;
        private DataColumn dc_category_id_manage;
        private DataColumn dc_category_name_manage;

        private DataSet ds_search;
        private DataSet ds_manage;

        private string mysql_cmd_search_inventory_basic;
        private string mysql_cmd_search_history_basic;
        private string view_search_option;
        private string manage_option_add_alter_remove;
        private string manage_option_warehouse_category;

        public LogInForm logInForm { get; set; }

        public ManagerMainForm(Manager manager)
        {
            InitializeComponent();
            this.manager = manager;
            db_connect = new DBConnect();

            dt_warehouse_view = new DataTable();
            dc_warehouse_id_view = new DataColumn("id_warehouse", typeof(int));
            dc_warehouse_name_view = new DataColumn("name_warehouse", typeof(string));
            dt_warehouse_view.Columns.Add(dc_warehouse_id_view);
            dt_warehouse_view.Columns.Add(dc_warehouse_name_view);
            dt_category_view = new DataTable();
            dc_category_id_view = new DataColumn("id_category", typeof(int));
            dc_category_name_view = new DataColumn("name_category", typeof(string));
            dt_category_view.Columns.Add(dc_category_id_view);
            dt_category_view.Columns.Add(dc_category_name_view);

            dt_warehouse_manage = new DataTable();
            dc_warehouse_id_manage = new DataColumn("id_warehouse", typeof(int));
            dc_warehouse_name_manage = new DataColumn("name_warehouse", typeof(string));
            dt_warehouse_manage.Columns.Add(dc_warehouse_id_manage);
            dt_warehouse_manage.Columns.Add(dc_warehouse_name_manage);
            dt_category_manage = new DataTable();
            dc_category_id_manage = new DataColumn("id_category", typeof(int));
            dc_category_name_manage = new DataColumn("name_category", typeof(string));
            dt_category_manage.Columns.Add(dc_category_id_manage);
            dt_category_manage.Columns.Add(dc_category_name_manage);

            ds_search = new DataSet();
            ds_manage = new DataSet();

            dateTimePicker_after.CustomFormat = "yyyy-MM-dd";
            dateTimePicker_before.CustomFormat = "yyyy-MM-dd";

            mysql_cmd_search_inventory_basic = "SELECT inventory.id_inventory as InvID, "
                                    + "warehouse.name as Warehouse, "
                                    + "inventory.description as Description, "
                                    + "category.name as Category, "
                                    + "inventory.date_in as Date "
                                + "FROM inventory JOIN warehouse ON inventory.id_warehouse = warehouse.id_warehouse "
                                    + "JOIN category ON inventory.id_category = category.id_category ";

            mysql_cmd_search_history_basic = "SELECT history_info.id_inventory as InvID, "
                                    + "warehouse.name as Warehouse, "
                                    + "history_info.id_repository as RepoID, "
                                    + "history_info.description as Description, "
                                    + "category.name as Category, "
                                    + "DateInOut.DateIn as DateIn, "
                                    + "DateInOut.DateOut as DateOut, "
                                    + "history_info.payment as Payment "
                                    + "FROM history_info JOIN warehouse ON history_info.id_warehouse = warehouse.id_warehouse "
                                    + "JOIN category ON history_info.id_category = category.id_category "
                                    + "JOIN (SELECT a.id_inventory, a.date as DateIn, b.date as DateOut "
                                        + "FROM (SELECT * FROM history_status WHERE status = 'in') as a "
                                            + "LEFT JOIN (SELECT * FROM history_status WHERE status = 'out') as b "
                                            + "ON a.id_inventory = b.id_inventory) as DateInOut "
                                        + "ON history_info.id_inventory = DateInOut.id_inventory ";

            //SetComboWarehouseView(dt_warehouse_view);
            //SetComboCategoryView(dt_category_view);
            manage_option_add_alter_remove = "add";
            manage_option_warehouse_category = "category";

            UpdateComboBox();

            SetDefaultSearch(mysql_cmd_search_inventory_basic);
            SetManage(manage_option_warehouse_category);

            radioButton_inventory.Checked = true;

            view_textBox_InvNO.Clear();


            radioButton_add.Select();
            radioButton_category.Select();
            radioButton_add.Checked = true;
            radioButton_category.Checked = true;
            groupBox_add.Visible = true;
            groupBox_alter.Visible = false;
            groupBox_add_address.Visible = false;
        }

        public void SetDefaultSearch(string mysql_cmd)
        {
            if (db_connect.OpenConnection())
            {
                if (view_search_option == "history")
                {
                    mysql_cmd += "ORDER BY history_info.id_inventory ASC";
                }
                ds_search = new DataSet();
                MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(ds_search);
                dataGridView_view.DataSource = ds_search.Tables[0].DefaultView;
            }
            else
            {
                MessageBox.Show(db_connect.Message);
                return;
            }
            if (!db_connect.CloseConnection())
            {
                MessageBox.Show(db_connect.Message);
                return;
            }
        }

        private void SetManage(string option)
        {
            if (db_connect.OpenConnection())
            {
                string mysql_cmd = "SELECT * FROM " + option;
                MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                ds_manage = new DataSet();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(ds_manage);
                dataGridView_manage.DataSource = ds_manage.Tables[0].DefaultView;
            }
            else
            {
                MessageBox.Show(db_connect.Message);
                return;
            }
            if (!db_connect.CloseConnection())
            {
                MessageBox.Show(db_connect.Message);
                return;
            }
        }

        private void SetComboWarehouse(DataTable dt_warehouse)
        {
            if (db_connect.OpenConnection())
            {
                string mysql_cmd = "SELECT * FROM warehouse";
                MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    DataRow row = dt_warehouse.NewRow();
                    row = dt_warehouse.NewRow();
                    row[0] = dataReader["id_warehouse"].ToString();
                    row[1] = dataReader["name"].ToString();
                    dt_warehouse.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show(db_connect.Message);
                return;
            }
            if (!db_connect.CloseConnection())
            {
                MessageBox.Show(db_connect.Message);
                return;
            }
        }

        public void SetComboWarehouseView(DataTable dt_warehouse)
        {
            dt_warehouse.Clear();
            DataRow row = dt_warehouse.NewRow();
            row[0] = "0";
            row[1] = "All";
            dt_warehouse.Rows.Add(row);
            SetComboWarehouse(dt_warehouse);
            view_comboBox_warehouse.DisplayMember = "name_warehouse";
            view_comboBox_warehouse.ValueMember = "id_warehouse";
            view_comboBox_warehouse.DataSource = dt_warehouse;
        }

        public void SetComboWarehouseManege(DataTable dt_warehouse)
        {
            dt_warehouse.Clear();
            SetComboWarehouse(dt_warehouse);
            manage_comboBox.DataSource = null;
            manage_comboBox.DisplayMember = "name_warehouse";
            manage_comboBox.ValueMember = "id_warehouse";
            manage_comboBox.DataSource = dt_warehouse;
        }

        private void SetComboCategory(DataTable dt_category)
        {
            if (db_connect.OpenConnection())
            {
                string mysql_cmd = "SELECT * FROM category";
                MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    DataRow row = dt_category.NewRow();
                    row = dt_category.NewRow();
                    row[0] = dataReader["id_category"].ToString();
                    row[1] = dataReader["name"].ToString();
                    dt_category.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show(db_connect.Message);
            }
            if (!db_connect.CloseConnection())
            {
                MessageBox.Show(db_connect.Message);
            }
        }

        public void SetComboCategoryView(DataTable dt_category)
        {
            dt_category.Clear();
            DataRow row = dt_category.NewRow();
            row[0] = "0";
            row[1] = "All";
            dt_category.Rows.Add(row);
            SetComboCategory(dt_category);
            view_comboBox_category.DisplayMember = "name_category";
            view_comboBox_category.ValueMember = "id_category";
            view_comboBox_category.DataSource = dt_category;
        }

        public void SetComboCategoryManage(DataTable dt_category)
        {
            dt_category.Clear();
            SetComboCategory(dt_category);
            manage_comboBox.DataSource = null;            
            manage_comboBox.DisplayMember = "name_category";
            manage_comboBox.ValueMember = "id_category";
            manage_comboBox.DataSource = dt_category;
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {      
            e.Graphics.Clear(Color.White);
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }

        private void radioButton_inventory_CheckedChanged(object sender, EventArgs e)
        {
            view_search_option = "inventory";
            SetDefaultSearch(mysql_cmd_search_inventory_basic);
            ResetComboBoxDatePicker();
            view_textBox_InvNO.Clear();
        }

        private void radioButton_history_CheckedChanged(object sender, EventArgs e)
        {
            view_search_option = "history";
            SetDefaultSearch(mysql_cmd_search_history_basic);
            ResetComboBoxDatePicker();
            view_textBox_InvNO.Clear();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            ds_search = new DataSet();
            string invNO = view_textBox_InvNO.Text;
            if (invNO != "")
            {
                if (!checkTextAsNO(invNO))
                {
                    MessageBox.Show("Sorry! The Inv NO you entered is invalid!\n Please make sure all the characters are between 0 - 9!");
                    return;
                }
                // Search for the valid inv NO
                if (db_connect.OpenConnection())
                {
                    // Judge the mode of the search
                    string mysql_cmd;
                    if (view_search_option == "inventory")
                    {
                        mysql_cmd = mysql_cmd_search_inventory_basic
                                            + "WHERE inventory.id_inventory = @invID;";
                    }
                    else
                    {
                        mysql_cmd = mysql_cmd_search_history_basic
                                            + "WHERE history_info.id_inventory = @invID;";   
                    }
                    MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                    cmd.Parameters.AddWithValue("@invID", invNO);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    
                    dataAdapter.Fill(ds_search);
                    dataGridView_view.DataSource = ds_search.Tables[0].DefaultView;
                }
                else
                {
                    MessageBox.Show(db_connect.Message);
                    return;
                }
                if (!db_connect.CloseConnection())
                {
                    MessageBox.Show(db_connect.Message);
                    return;
                }
                ResetComboBoxDatePicker();
            }
            else
            {
                string id_warehouse = view_comboBox_warehouse.SelectedValue.ToString();
                string id_category = view_comboBox_category.SelectedValue.ToString();
                DateTime before = dateTimePicker_before.Value;
                DateTime after = dateTimePicker_after.Value;
                if (after > before.AddDays(1))
                {
                    MessageBox.Show("Sorry! The date you selected is invalid!");
                    return;
                }
                if (db_connect.OpenConnection())
                {
                    string mysql_cmd;
                    if (view_search_option == "inventory")
                    {
                        mysql_cmd = mysql_cmd_search_inventory_basic;
                        if (id_warehouse != "0")
                        {
                            mysql_cmd += "AND inventory.id_warehouse = @warehouseID ";
                        }
                        if (id_category != "0")
                        {
                            mysql_cmd += "AND inventory.id_category = @categoryID ";
                        }
                        mysql_cmd += "AND inventory.date_in >= @dateAfter AND inventory.date_in <= @dateBefore;";
                    }
                    else
                    {
                        mysql_cmd = mysql_cmd_search_history_basic;
                        if (id_warehouse != "0")
                        {
                            mysql_cmd += "AND history_info.id_warehouse = @warehouseID ";
                        }
                        if (id_category != "0")
                        {
                            mysql_cmd += "AND history_info.id_category = @categoryID ";
                        }
                        mysql_cmd += "AND DateInOut.DateOut >= @dateAfter AND DateInOut.DateIn <= @dateBefore;";
                    }
                    MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                    if (id_warehouse != "0")
                    {
                        cmd.Parameters.AddWithValue("@warehouseID", id_warehouse);
                    }
                    if (id_category != "0")
                    {
                        cmd.Parameters.AddWithValue("@categoryID", id_category);
                    }
                    cmd.Parameters.AddWithValue("@dateAfter", after.ToString("yyyy-MM-dd") + " 00:00:00");
                    cmd.Parameters.AddWithValue("@dateBefore", before.ToString("yyyy-MM-dd") + " 23:59:59");
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(ds_search);
                    dataGridView_view.DataSource = ds_search.Tables[0].DefaultView;
                }
                else
                {
                    MessageBox.Show(db_connect.Message);
                    return;
                }
                if (!db_connect.CloseConnection())
                {
                    MessageBox.Show(db_connect.Message);
                    return;
                }
            }
        }

        private void ResetComboBoxDatePicker()
        {
            view_comboBox_warehouse.Text = "All";
            view_comboBox_category.Text = "All";
            dateTimePicker_after.Value = DateTime.Today;
            dateTimePicker_before.Value = DateTime.Today;
        }

        private void groupBox2_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }

        private void groupBox_add_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }

        private void groupBox_alter_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }

        private void manage_btn_confirm_Click(object sender, EventArgs e)
        {
            string categoryID_other = "";
            string fee_other = "";
            // First get the origin ID and fee of category
            if (db_connect.OpenConnection())
            {
                string mysql_cmd = "SELECT * FROM category WHERE name = 'Other';";
                MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    fee_other = dataReader["fee"].ToString();
                    categoryID_other = dataReader["id_category"].ToString();
                }
                if (fee_other == "" || categoryID_other == "")
                {
                    MessageBox.Show("Database Category Error!");
                    return;
                }
            }
            else
            {
                MessageBox.Show(db_connect.Message);
            }
            if (!db_connect.CloseConnection())
            {
                MessageBox.Show(db_connect.Message);
            }
            // If the add is selected
            if (manage_option_add_alter_remove == "add")
            {
                string name = textBox_add_name.Text;
                string fee = textBox_add_fee.Text;
                if (!checkTextAsCharater(name))
                {
                    MessageBox.Show("Sorry, the name you entered is not valid!");
                    textBox_add_name.Clear();
                    return;
                }
                if (!checkTextAsInt(fee))
                {
                    MessageBox.Show("Sorry, the fee you entered has to be integer!");
                    textBox_add_fee.Clear();
                    return;
                }
                string mysql_cmd = "";
                // If the warehouse is selected
                if (manage_option_warehouse_category == "warehouse")
                {
                    string street = textBox_street.Text;
                    string city = textBox_city.Text;
                    string country = textBox_country.Text;
                    string tel = textBox_tel.Text;
                    if (!checkTextAsCharater(street))
                    {
                        MessageBox.Show("Sorry, the street you entered is invalid!");
                        textBox_street.Clear();
                        return;
                    }
                    if (!checkTextAsCharater(city))
                    {
                        MessageBox.Show("Sorry, the city you entered is invalid!");
                        textBox_city.Clear();
                        return;
                    }
                    if (!checkTextAsCharater(country))
                    {
                        MessageBox.Show("Sorry, the country you entered is invalid!");
                        textBox_country.Clear();
                        return;
                    }
                    if (!checkTextAsTEL(tel))
                    {
                        MessageBox.Show("Sorry, the telephone number you entered is invalid!");
                        textBox_tel.Clear();
                        return;
                    }
                    if (db_connect.OpenConnection())
                    {
                        mysql_cmd = "INSERT INTO `gowaredb`.`warehouse` "
                            + "(`name`, `fee`, `street`, `city`, `country`, `tel`) "
                            + "VALUES (@name,  @fee, @street, @city, @country, @tel);";
                        MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@fee", fee);
                        cmd.Parameters.AddWithValue("@street", street);
                        cmd.Parameters.AddWithValue("@city", city);
                        cmd.Parameters.AddWithValue("@country", country);
                        cmd.Parameters.AddWithValue("@tel", tel);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("New warehouse has been assigned!");
                            textBox_add_fee.Clear();
                            textBox_add_name.Clear();
                            textBox_street.Clear();
                            textBox_city.Clear();
                            textBox_country.Clear();
                            textBox_tel.Clear();
                            UpdateComboBox();
                        }
                        else
                        {
                            MessageBox.Show("Insert Error!");
                        }
                    }
                    else
                    {
                        MessageBox.Show(db_connect.Message);
                    }
                }
                // If the category is selected
                else
                {
                    MySqlCommand cmd;
                    if (db_connect.OpenConnection())
                    {
                        // Then change the current name of the Other and the fee
                        mysql_cmd = "UPDATE `gowaredb`.`category` SET `name`=@name, `fee`=@fee WHERE `id_category`=@categoryID;";
                        cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@fee", fee);
                        cmd.Parameters.AddWithValue("@categoryID", categoryID_other);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show(db_connect.Message);
                    }
                    if (!db_connect.CloseConnection())
                    {
                        MessageBox.Show(db_connect.Message);
                    }
                    if (db_connect.OpenConnection())
                    {
                        // Then insert the origin other as a new category
                        mysql_cmd = "INSERT INTO `gowaredb`.`category` (`name`, `fee`) VALUES ('Other', @fee_other);";
                        cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                        cmd.Parameters.AddWithValue("@fee_other", fee_other);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("New category has been assigned!");
                            textBox_add_name.Clear();
                            textBox_add_fee.Clear();
                            UpdateComboBox();
                        }
                        else
                        {
                            MessageBox.Show("Insert Error!");
                        }
                    }
                    else
                    {
                        MessageBox.Show(db_connect.Message);
                    }
                    if (!db_connect.CloseConnection())
                    {
                        MessageBox.Show(db_connect.Message);
                    }
                }
            }
            // If the alter is selected
            else if (manage_option_add_alter_remove == "alter")
            {
                string fee = textBox_alter_fee.Text;
                // If the warehouse is selected
                string ID = manage_comboBox.SelectedValue.ToString();
                // Change the new fee
                if (db_connect.OpenConnection())
                {
                    string mysql_cmd = "UPDATE `gowaredb`.`" + manage_option_warehouse_category + 
                        "` SET `fee`=@fee WHERE `id_" + manage_option_warehouse_category +"`=@ID";
                    MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                    cmd.Parameters.AddWithValue("@fee", fee);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update successfully!");
                    textBox_alter_fee.Clear();
                }
                else
                {
                    MessageBox.Show(db_connect.Message);
                }
                if (!db_connect.CloseConnection())
                {
                    MessageBox.Show(db_connect.Message);
                }
            }
            // If remove is selected
            else
            {
                string ID = manage_comboBox.SelectedValue.ToString();
                if (ID == categoryID_other)
                {
                    MessageBox.Show("Sorry! The type 'Other' cannot be removed!");
                    return;
                }
                if (db_connect.OpenConnection())
                {
                    string mysql_cmd = "DELETE FROM `gowaredb`.`" + manage_option_warehouse_category
                        + "` WHERE `id_" + manage_option_warehouse_category + "`=@ID;";
                    MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Remove successfully!");
                    UpdateComboBox();
                }
                else
                {
                    MessageBox.Show(db_connect.Message);
                }
                if (!db_connect.CloseConnection())
                {
                    MessageBox.Show(db_connect.Message);
                }
            }
            if (!db_connect.CloseConnection())
            {
                MessageBox.Show(db_connect.Message);
            }
            SetManage(manage_option_warehouse_category);
        }

        private void UpdateComboBox()
        {
            SetComboCategoryView(dt_category_view);
            SetComboWarehouseView(dt_warehouse_view);
            this.manage_comboBox.SelectedIndexChanged -= new System.EventHandler(this.manage_comboBox_SelectedIndexChanged);
            if (manage_option_warehouse_category == "warehouse")
            {
                SetComboWarehouseManege(dt_warehouse_manage);
            }
            else
            {
                SetComboCategoryManage(dt_category_manage);
            }
            this.manage_comboBox.SelectedIndexChanged += new System.EventHandler(this.manage_comboBox_SelectedIndexChanged);
            manage_comboBox.SelectedIndex = 1;
            manage_comboBox.SelectedIndex = 0;
        }

        private bool checkTextAsNO(string text)
        {
            if (text.Length == 0)
            {
                return false;
            }
            foreach (char c in text)
            {
                int n = (int)c;
                if (!(n >= 48 && n <= 57))
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkTextAsInt(string text)
        {
            return checkTextAsNO(text);
        }

        private bool checkTextAsCharater(string text)
        {
            if (text.Length == 0)
            {
                return false;
            }
            foreach (char c in text)
            {
                int n = (int)c;
                if (!
                    ((n >= 48 && n <= 57) 
                    || (n >= 65 && n <= 90)
                    || (n >= 97 && n <= 122))
                    )
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkTextAsTEL(string text)
        {
            if (text.Length == 0)
            {
                return false;
            }
            foreach (char c in text)
            {
                int n = (int)c;
                if (!((n >= 48 && n <= 57) || n == 45))
                {
                    return false;
                }
            }
            return true;
        }

        private void groupBox_add_address_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }

        private void radioButton_warehouse_Click(object sender, EventArgs e)
        {
            manage_option_warehouse_category = "warehouse";
            SetManage(manage_option_warehouse_category);
            if (manage_option_add_alter_remove == "add")
            {
                groupBox_add_address.Visible = true;
            }
            else
            {
                this.manage_comboBox.SelectedIndexChanged -= new System.EventHandler(this.manage_comboBox_SelectedIndexChanged);
                SetComboWarehouseManege(dt_warehouse_manage);
                this.manage_comboBox.SelectedIndexChanged += new System.EventHandler(this.manage_comboBox_SelectedIndexChanged);
                manage_comboBox.SelectedIndex = 1;
                manage_comboBox.SelectedIndex = 0;
            }
        }

        private void radioButton_category_Click(object sender, EventArgs e)
        {
            manage_option_warehouse_category = "category";
            SetManage(manage_option_warehouse_category);
            if (manage_option_add_alter_remove == "add")
            {
                groupBox_add_address.Visible = false;
            }
            else
            {
                this.manage_comboBox.SelectedIndexChanged -= new System.EventHandler(this.manage_comboBox_SelectedIndexChanged);
                SetComboCategoryManage(dt_category_manage);
                this.manage_comboBox.SelectedIndexChanged += new System.EventHandler(this.manage_comboBox_SelectedIndexChanged);
                manage_comboBox.SelectedIndex = 1;
                manage_comboBox.SelectedIndex = 0;
            }
        }

        private void radioButton_add_Click(object sender, EventArgs e)
        {
            manage_option_add_alter_remove = "add";
            groupBox_add.Visible = true;
            groupBox_alter.Visible = false;
            if (manage_option_warehouse_category == "warehouse")
            {
                groupBox_add_address.Visible = true;
            }
            else
            {
                groupBox_add_address.Visible = false;
            }
        }

        private void radioButton_alter_Click(object sender, EventArgs e)
        {
            manage_option_add_alter_remove = "alter";
            groupBox_add.Visible = false;
            groupBox_alter.Visible = true;
            groupBox_add_address.Visible = false;
            ulabel_changed_fee.Visible = true;
            ulabel_current_fee.Visible = true;
            label_current_fee.Visible = true;
            textBox_alter_fee.Visible = true;
        }

        private void radioButton_remove_Click(object sender, EventArgs e)
        {
            manage_option_add_alter_remove = "remove";
            groupBox_add.Visible = false;
            groupBox_alter.Visible = true;
            groupBox_add_address.Visible = false;
            ulabel_changed_fee.Visible = false;
            ulabel_current_fee.Visible = false;
            label_current_fee.Visible = false;
            textBox_alter_fee.Visible = false;
        }

        private void manage_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fee_current = "";
            string ID = manage_comboBox.SelectedValue.ToString();
            if (db_connect.OpenConnection())
            {
                string mysql_cmd = "SELECT fee FROM " + manage_option_warehouse_category 
                    + " WHERE id_" + manage_option_warehouse_category + "= @ID;";
                MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                cmd.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    fee_current = dataReader["fee"].ToString();
                }
                if (fee_current == "")
                {
                    MessageBox.Show("Database Error! Cannot find the warehouse!");
                }
                label_current_fee.Text = fee_current;
            }
            else
            {
                MessageBox.Show(db_connect.Message);
            }
            if (!db_connect.CloseConnection())
            {
                MessageBox.Show(db_connect.Message);
            }
        }

        private void ManagerMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logInForm.Show();
        }

    }
}
