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

namespace GoWareWMS
{
    public partial class ClientMainForm : Form
    {
        private Client client;
        private DBConnect db_connect;

        private DataTable dt_warehouse_view;
        private DataColumn dc_warehouse_id_view;
        private DataColumn dc_warehouse_name_view;

        private DataTable dt_warehouse_checkin;
        private DataColumn dc_warehouse_id_checkin;
        private DataColumn dc_warehouse_name_checkin;

        private DataTable dt_category_view;
        private DataColumn dc_category_id_view;
        private DataColumn dc_category_name_view;

        private DataTable dt_category_checkin;
        private DataColumn dc_category_id_checkin;
        private DataColumn dc_category_name_checkin;

        private DataSet ds_search;

        private string mysql_cmd_search_basic;

        public LogInForm logInForm { get; set; }

        public ClientMainForm(Client client)
        {
            InitializeComponent();
            this.client = client; 
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

            dt_warehouse_checkin = new DataTable();
            dc_warehouse_id_checkin = new DataColumn("id_warehouse", typeof(int));
            dc_warehouse_name_checkin = new DataColumn("name_warehouse", typeof(string));
            dt_warehouse_checkin.Columns.Add(dc_warehouse_id_checkin);
            dt_warehouse_checkin.Columns.Add(dc_warehouse_name_checkin);
            dt_category_checkin = new DataTable();
            dc_category_id_checkin = new DataColumn("id_category", typeof(int));
            dc_category_name_checkin = new DataColumn("name_category", typeof(string));
            dt_category_checkin.Columns.Add(dc_category_id_checkin);
            dt_category_checkin.Columns.Add(dc_category_name_checkin);

            ds_search = new DataSet();

            dateTimePicker_after.CustomFormat = "yyyy-MM-dd";
            dateTimePicker_before.CustomFormat = "yyyy-MM-dd";

            mysql_cmd_search_basic = "SELECT inventory.id_inventory as InvID, "
                                    + "warehouse.name as Warehouse, "
                                    + "inventory.description as Description, "
                                    + "category.name as Category, "
                                    + "inventory.date_in as Date "
                                + "FROM inventory JOIN warehouse ON inventory.id_warehouse = warehouse.id_warehouse "
                                    + "JOIN category ON inventory.id_category = category.id_category ";

            SetComboWarehouseView(dt_warehouse_view);
            SetComboWarehouseCheckin(dt_warehouse_checkin);
            SetComboCategoryView(dt_category_view);
            SetComboCategoryCheckin(dt_category_checkin);
            SetDefaultSearch();

            view_textBox_InvNO.Clear();
            checkin_textBox_description.Clear();
            string welcome = "Welcome To Goware! Dear ";
            if (client.Type == "personal") {
                if (client.Sex == "M"){
                    welcome += "Mr. ";
                }
                else
                {
                    welcome += "Ms. ";
                }
                welcome += client.Lastname;
            }
            else
            {
                welcome += client.Companyname;
            }
            MessageBox.Show(welcome);
        }

        public void SetDefaultSearch()
        {
            if (db_connect.OpenConnection())
            {
                ds_search.Clear();
                string mysql_cmd = mysql_cmd_search_basic
                                + "WHERE inventory.id_client = @clientID;";
                MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                cmd.Parameters.Add(new MySqlParameter("@clientID", client.ID));
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(ds_search);
                dataGridView_client.DataSource = ds_search.Tables[0].DefaultView;
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
            view_comboBox_warehouse.DataSource = dt_warehouse_view;
        }

        public void SetComboWarehouseCheckin(DataTable dt_warehouse)
        {
            dt_warehouse.Clear();
            SetComboWarehouse(dt_warehouse);
            checkin_comboBox_warehouse.DisplayMember = "name_warehouse";
            checkin_comboBox_warehouse.ValueMember = "id_warehouse";
            checkin_comboBox_warehouse.DataSource = dt_warehouse_checkin;
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
            view_comboBox_category.DataSource = dt_category_view;
        }

        public void SetComboCategoryCheckin(DataTable dt_category)
        {
            dt_category.Clear();
            SetComboCategory(dt_category);
            checkin_comboBox_category.DisplayMember = "name_category";
            checkin_comboBox_category.ValueMember = "id_category";
            checkin_comboBox_category.DataSource = dt_category_checkin;
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            string invNO = view_textBox_InvNO.Text;
            if (invNO != "")
            {
                if (!checkText(invNO))
                {
                    MessageBox.Show("Sorry! The Inv NO you entered is invalid!\n Please make sure all the characters are between 0 - 9!");
                    return;
                }
                // Reset the other options
                view_comboBox_warehouse.Text = "All";
                view_comboBox_category.Text = "All";
                dateTimePicker_after.Value = DateTime.Today;
                dateTimePicker_before.Value = DateTime.Today;
                // Search for the valid inv NO
                if (db_connect.OpenConnection())
                {
                    string mysql_cmd = mysql_cmd_search_basic
                                    + "WHERE inventory.id_client = @clientID "
                                        + "AND inventory.id_inventory = @invID;";
                    MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                    cmd.Parameters.AddWithValue("@clientID", client.ID);
                    cmd.Parameters.AddWithValue("@invID", invNO);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    ds_search.Clear();
                    dataAdapter.Fill(ds_search);
                    dataGridView_client.DataSource = ds_search.Tables[0].DefaultView;
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
                    string mysql_cmd = mysql_cmd_search_basic
                                    + "WHERE inventory.id_client = @clientID ";
                    if (id_warehouse != "0")
                    {
                        mysql_cmd += "AND inventory.id_warehouse = @warehouseID ";
                    }
                    if (id_category != "0")
                    {
                        mysql_cmd += "AND inventory.id_category = @categoryID ";
                    }
                    mysql_cmd += "AND inventory.date_in >= @dateAfter AND inventory.date_in <= @dateBefore;";
                    MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                    cmd.Parameters.AddWithValue("@clientID", client.ID);
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
                    ds_search.Clear();
                    dataAdapter.Fill(ds_search);
                    dataGridView_client.DataSource = ds_search.Tables[0].DefaultView;
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

        private bool checkText(string text)
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

        private void checkin_btn_checkin_Click(object sender, EventArgs e)
        {
            string description = checkin_textBox_description.Text;
            if (description.Length >= 200)
            {
                MessageBox.Show("Sorry! Your description is too long!");
                return;
            }
            // Confirm messagebox
            if (MessageBox.Show("Are you sure to check-in?", "Confirm Message", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }
            string inventoryID = "";
            string categoryID = checkin_comboBox_category.SelectedValue.ToString();
            string warehouseID = checkin_comboBox_warehouse.SelectedValue.ToString();
            string repositoryID = DetermineRepositoryID(warehouseID, categoryID);
            if (repositoryID == "") return;
            if (db_connect.OpenConnection())
            {
                string mysql_cmd = "INSERT INTO `history_info` "
                                + "(`id_client`, `id_warehouse`, `id_repository`, `id_category`, `description`, `payment`) "
                                + "VALUES (@clientID, @warehouseID, @repositoryID, @categoryID, @description, '0');";
                MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                cmd.Parameters.AddWithValue("@clientID", client.ID);
                cmd.Parameters.AddWithValue("@warehouseID", warehouseID);
                cmd.Parameters.AddWithValue("@repositoryID", repositoryID);
                cmd.Parameters.AddWithValue("@categoryID", categoryID);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your order has been placed!");
                
                mysql_cmd = "select @@IDENTITY;";
                cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    inventoryID = dataReader["@@IDENTITY"].ToString();
                }
                
                checkin_textBox_description.Clear();
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
            ShowReceipt("checkin", "", inventoryID, categoryID, description, warehouseID, "");
        }

        private string DetermineRepositoryID(string warehouseID, string categoryID)
        {
            // Create an array of list to store the output of the sql select result
            // to help to decide which repository
            List<string>[] list = new List<string>[4];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();

            if (db_connect.OpenConnection())
            {
                string mysql_cmd = "SELECT id_warehouse, id_category, id_repository, count(id_inventory) as inventoryCount "
                                + "FROM inventory "
                                + "WHERE id_warehouse = @warehouseID AND id_category = @categoryID "
                                + "GROUP BY id_warehouse, id_category, id_repository;";
                MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                cmd.Parameters.AddWithValue("@warehouseID", warehouseID);
                cmd.Parameters.AddWithValue("@categoryID", categoryID);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    if (dataReader["id_warehouse"].ToString() == warehouseID)
                    {
                        list[0].Add(dataReader["id_warehouse"].ToString());
                        list[1].Add(dataReader["id_repository"].ToString());
                        list[2].Add(dataReader["id_category"].ToString());
                        list[3].Add(dataReader["inventoryCount"].ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show(db_connect.Message);
                return "";
            }
            if (!db_connect.CloseConnection())
            {
                MessageBox.Show(db_connect.Message);
                return "";
            }
            // If the search result is zero, which means that in the inventory 
            // there is not any this kind
            if (list[0].Count == 0)
            {
                string tmp_repositoryID = "";
                if (db_connect.OpenConnection())
                {
                    // Judge whether there is any need to add a new repo
                    string mysql_cmd = "SELECT * "
                        + "FROM repository "
                        + "WHERE id_warehouse = @warehouseID AND id_category = @categoryID "
                        + "ORDER BY id_repository DESC;";
                    MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                    cmd.Parameters.AddWithValue("@warehouseID", warehouseID);
                    cmd.Parameters.AddWithValue("@categoryID", categoryID);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        tmp_repositoryID = dataReader["id_repository"].ToString();
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
                // If there is no available rpeo, assign a new one
                if (tmp_repositoryID == "")
                {
                    AddNewRepository(warehouseID, categoryID, "1");
                    return "1";
                }
                // Else just use the newest one
                else
                {
                    return tmp_repositoryID;
                }
            }
            else
            {
                int index = 0;
                // If there exist any repository whose items is less than 5
                // Just use the one whose id is as small as possible
                foreach (string count_str in list[3])
                {
                    int count_int = Convert.ToInt32(count_str);
                    if (count_int < 5)
                    {
                        return list[1][index];
                    }
                    index++;
                }
                // If haven't returned, then should add a new repository
                // First we need to find out the largest ID of the existing repo
                int id_repo_max = 0;
                foreach (string id_repo_str in list[1])
                {
                    int id_repo_int = Convert.ToInt32(id_repo_str);
                    if (id_repo_int > id_repo_max)
                    {
                        id_repo_max = id_repo_int;
                    }
                }
                id_repo_max++;
                string repository = id_repo_max.ToString();
                AddNewRepository(warehouseID, categoryID, repository);
                return repository;
            }
        }

        private void AddNewRepository(string warehouseID, string categoryID, string repositoryID)
        {
            if (db_connect.OpenConnection())
            {
                string mysql_cmd = "INSERT INTO `repository` "
                                + "(`id_warehouse`, `id_category`, `id_repository`) "
                                + "VALUES (@warehouseID, @categoryID, @repositoryID);";
                MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                cmd.Parameters.AddWithValue("@warehouseID", warehouseID);
                cmd.Parameters.AddWithValue("@categoryID", categoryID);
                cmd.Parameters.AddWithValue("@repositoryID", repositoryID);
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
        }

        public void ShowReceipt(string check, string finalfee, string inventoryID, string categoryID, string description, string warehouseID, string date2)
        {
            DataRow [] row_category = dt_category_checkin.Select("id_category = " + categoryID);
            string category = row_category[0]["name_category"] as string;
            DataRow[] row_warehouse = dt_warehouse_checkin.Select("id_warehouse = " + warehouseID);
            string warehouse = row_warehouse[0]["name_warehouse"] as string;

            Dictionary<string, string> feeCategory = GetFeeCategory(categoryID);
            Dictionary<string, string> feeAddressWarehouse = GetFeeAddressWarehouse(warehouseID);
            string date = DateTime.Today.ToShortDateString();
            
            ReceipForm receipt = new ReceipForm();
            receipt.SetLabel(check, finalfee, inventoryID, category, description, feeCategory, warehouse, feeAddressWarehouse, date, date2);
            receipt.Show();
        }

        private Dictionary<string, string> GetFeeCategory(string categoryID)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("fee", "0");
            if (db_connect.OpenConnection())
            {
                string mysql_cmd = "SELECT * FROM category WHERE id_category = @categoryID";
                MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                cmd.Parameters.AddWithValue("@categoryID", categoryID);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    dict["fee"] = dataReader["fee"].ToString();
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
            return dict;
        }

        private Dictionary<string, string> GetFeeAddressWarehouse(string warehouseID)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("fee", "0");
            dict.Add("street", "");
            dict.Add("city", "");
            dict.Add("country", "");
            dict.Add("tel", "");
            if (db_connect.OpenConnection())
            {
                string mysql_cmd = "SELECT * FROM warehouse WHERE id_warehouse = @warehouseID";
                MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                cmd.Parameters.AddWithValue("@warehouseID", warehouseID);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    dict["fee"] = dataReader["fee"].ToString();
                    dict["street"] = dataReader["street"].ToString();
                    dict["city"] = dataReader["city"].ToString();
                    dict["country"] = dataReader["country"].ToString();
                    dict["tel"] = dataReader["tel"].ToString();
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
            return dict;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    SetComboWarehouseView(dt_warehouse_view);
                    SetComboCategoryView(dt_category_view);
                    SetDefaultSearch();
                    view_textBox_InvNO.Clear();
                    break;
                case 1:
                    SetComboWarehouseCheckin(dt_warehouse_checkin);
                    SetComboCategoryCheckin(dt_category_checkin);
                    checkin_textBox_description.Clear();
                    break;
                case 2:
                    checkout_textBox_invNO.Clear();
                    break;
                default:
                    break;
            }
        }

        private void checkout_btn_checkout_Click(object sender, EventArgs e)
        {
            bool valid = false;
            double fee = 0f;
            string inventoryID = checkout_textBox_invNO.Text;
            string categoryID = "";
            Dictionary<string, string> dict_category;
            string warehouseID = "";
            Dictionary<string, string> dict_warehouse;
            string description = "";
            string date = "";
            if (db_connect.OpenConnection())
            {
                string mysql_cmd = "SELECT * FROM inventory WHERE id_client = @clientID AND id_inventory = @inventoryID";
                MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                cmd.Parameters.AddWithValue("@inventoryID", inventoryID);
                cmd.Parameters.AddWithValue("@clientID", client.ID);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    valid = true;
                    categoryID = dataReader["id_category"].ToString();
                    warehouseID = dataReader["id_warehouse"].ToString();
                    date = dataReader["date_in"].ToString();
                    description = dataReader["description"].ToString();
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
            if (valid)
            {
                // Confirm messagebox
                if (MessageBox.Show("Are you sure to check-out?", "Confirm Message", MessageBoxButtons.OKCancel)
                    != DialogResult.OK)
                {
                    return;
                }
                dict_category = GetFeeCategory(categoryID);
                dict_warehouse = GetFeeAddressWarehouse(warehouseID);
                int interval = (int)(DateTime.Today.Date - Convert.ToDateTime(date).Date).Days;
                fee = Convert.ToDouble(dict_category["fee"]) + Convert.ToDouble(dict_warehouse["fee"]) * interval;
                MessageBox.Show("You need to pay " + fee.ToString());
                ShowReceipt("checkout", fee.ToString(), inventoryID, categoryID, description, warehouseID, Convert.ToDateTime(date).Date.ToShortDateString());
                if (db_connect.OpenConnection())
                {
                    string mysql_cmd = "UPDATE `gowaredb`.`history_info` SET `payment`=@fee WHERE `id_inventory`=@inventoryID;";
                    MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                    cmd.Parameters.AddWithValue("@fee", fee.ToString());
                    cmd.Parameters.AddWithValue("@inventoryID", inventoryID);
                    cmd.ExecuteNonQuery();
                    checkout_textBox_invNO.Clear();
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
            else
            {
                MessageBox.Show("Cannot find the Inventory ID!");
                checkout_textBox_invNO.Clear();
                return;
            }
        }

        private void ClientMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logInForm.Show();
        }
    }
}
