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
        /// <summary>
        /// Datatable for the warehouse combox of the view tab
        /// </summary>
        private DataTable dt_warehouse_view;
        private DataColumn dc_warehouse_id_view;
        private DataColumn dc_warehouse_name_view;
        /// <summary>
        /// Datatable for the warehouse combox of the manage tab
        /// </summary>
        private DataTable dt_warehouse_manage;
        private DataColumn dc_warehouse_id_manage;
        private DataColumn dc_warehouse_name_manage;
        /// <summary>
        /// Datatable for the category combox of the view tab
        /// </summary>
        private DataTable dt_category_view;
        private DataColumn dc_category_id_view;
        private DataColumn dc_category_name_view;
        /// <summary>
        /// Datatable for the category combox of the manage tab
        /// </summary>
        private DataTable dt_category_manage;
        private DataColumn dc_category_id_manage;
        private DataColumn dc_category_name_manage;
        /// <summary>
        /// Dataset to bind into the datagrid in the view tab
        /// </summary>
        private DataSet ds_search;
        /// <summary>
        /// Dataset to bind into the datagrid in the manage tab
        /// </summary>
        private DataSet ds_manage;

        private string mysql_cmd_search_inventory_basic;
        private string mysql_cmd_search_history_basic;
        private string view_search_option;
        private string manage_option_add_alter_remove;
        private string manage_option_warehouse_category;

        private bool manage_confirm_flag;

        public LogInForm logInForm { get; set; }
        /// <summary>
        /// Initiate the manager form and the login manager information
        /// </summary>
        /// <param name="manager"></param>
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

            // Basic sql command for searching in inventory table
            // More constraint can be added at the end
            mysql_cmd_search_inventory_basic = "SELECT inventory.id_inventory as InvID, "
                                    + "inventory.id_client as ClientID, "
                                    + "warehouse.name as Warehouse, "
                                    + "inventory.description as Description, "
                                    + "category.name as Category, "
                                    + "inventory.date_in as Date "
                                + "FROM inventory JOIN warehouse ON inventory.id_warehouse = warehouse.id_warehouse "
                                    + "JOIN category ON inventory.id_category = category.id_category ";

            // Basic sql command for searching in history table
            // More constraint can be added at the end
            mysql_cmd_search_history_basic = "SELECT history_info.id_inventory as InvID, "
                                    + "history_info.id_client as ClientID, "
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

            // Set default search
            manage_option_add_alter_remove = "add";
            manage_option_warehouse_category = "category";
            SetDefaultSearch(mysql_cmd_search_inventory_basic);
            SetManage(manage_option_warehouse_category);

            // Set all of the combobox
            UpdateComboBox();

            // Set default selection
            radioButton_inventory.Checked = true;
            view_search_option = "inventory";
            view_textBox_InvNO.Clear();

            radioButton_add.Select();
            radioButton_category.Select();
            radioButton_add.Checked = true;
            radioButton_category.Checked = true;
            groupBox_add.Visible = true;
            groupBox_alter.Visible = false;
            groupBox_add_address.Visible = false;

            manage_confirm_flag = false;

            // Show the welcome messagebox
            string welcome = "Nice to meet you! ";
            if (manager.Sex == "F")
            {
                welcome += "Ms. ";
            }
            else
            {
                welcome += "Mr. ";
            }
            welcome += manager.Lastname + ".";
            MessageBox.Show(welcome);
        }
        /// <summary>
        /// When the form is closed, back to the login form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManagerMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logInForm.Show();
        }
        /// <summary>
        /// Set the default DataGridView in the "review" tab
        /// </summary>
        /// <param name="mysql_cmd">The selection command</param>
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
        /// <summary>
        /// Set the DataGridView in the "manage" tab
        /// </summary>
        /// <param name="option">If category/warehouse, then category/warehouse information will be shown</param>
        private void SetManage(string option)
        {
            // Ensure the connection is closed
            if (!db_connect.CloseConnection())
            {
                MessageBox.Show(db_connect.Message);
                return;
            }
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
        /// <summary>
        /// Set the datatable of warehouse. Used by view combo and manage combo.
        /// </summary>
        /// <param name="dt_warehouse"></param>
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
        /// <summary>
        /// Set the datatable of the warehouse combo in view tab.
        /// </summary>
        /// <param name="dt_warehouse"></param>
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
        /// <summary>
        /// Set the datatable of the warehouse combo in manage tab.
        /// </summary>
        /// <param name="dt_warehouse"></param>
        public void SetComboWarehouseManage(DataTable dt_warehouse)
        {
            dt_warehouse.Clear();
            SetComboWarehouse(dt_warehouse);
            manage_comboBox.DataSource = null;
            manage_comboBox.DisplayMember = "name_warehouse";
            manage_comboBox.ValueMember = "id_warehouse";
            manage_comboBox.DataSource = dt_warehouse;
        }
        /// <summary>
        /// Set the datatable of category. Used by view combo and manage combo.
        /// </summary>
        /// <param name="dt_category"></param>
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
        /// <summary>
        /// Set the datatable of the category combo in view tab.
        /// </summary>
        /// <param name="dt_category"></param>
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
        /// <summary>
        /// Set the datatable of the category combo in manage tab.
        /// </summary>
        /// <param name="dt_category"></param>
        public void SetComboCategoryManage(DataTable dt_category)
        {
            dt_category.Clear();
            SetComboCategory(dt_category);
            manage_comboBox.DataSource = null;            
            manage_comboBox.DisplayMember = "name_category";
            manage_comboBox.ValueMember = "id_category";
            manage_comboBox.DataSource = dt_category;
        }
        /// <summary>
        /// Reset the datapicker to be today (as default)
        /// </summary>
        private void ResetComboBoxDatePicker()
        {
            view_comboBox_warehouse.Text = "All";
            view_comboBox_category.Text = "All";
            dateTimePicker_after.Value = DateTime.Today;
            dateTimePicker_before.Value = DateTime.Today;
        }
        /// <summary>
        /// Update all of the combobox together.
        /// </summary>
        private void UpdateComboBox()
        {
            SetComboCategoryView(dt_category_view);
            SetComboWarehouseView(dt_warehouse_view);
            this.manage_comboBox.SelectedIndexChanged -= new System.EventHandler(this.manage_comboBox_SelectedIndexChanged);
            if (manage_option_warehouse_category == "warehouse")
            {
                SetComboWarehouseManage(dt_warehouse_manage);
            }
            else
            {
                SetComboCategoryManage(dt_category_manage);
            }
            this.manage_comboBox.SelectedIndexChanged += new System.EventHandler(this.manage_comboBox_SelectedIndexChanged);
            // Simulate the click
            manage_comboBox.SelectedIndex = 1;
            manage_comboBox.SelectedIndex = 0;
        }
        /// <summary>
        /// Things that would happen when clicking the search button in the view tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void view_btn_search_Click(object sender, EventArgs e)
        {
            ds_search = new DataSet();
            string invNO = view_textBox_InvNO.Text;
            // If search by Inventory ID
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
                    // Select the value to fill the datagrid.
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
                // Reset the other three constraints selection
                ResetComboBoxDatePicker();
                UpdateComboBox();
            }
            // Else add constraints by warehouse/category/date
            else
            {
                string id_warehouse = view_comboBox_warehouse.SelectedValue.ToString();
                string id_category = view_comboBox_category.SelectedValue.ToString();
                DateTime before = dateTimePicker_before.Value;
                DateTime after = dateTimePicker_after.Value;
                // Check for the calidity of the date
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
                        mysql_cmd += "AND inventory.date_in >= @dateAfter AND inventory.date_in <= @dateBefore ";
                        mysql_cmd += "ORDER BY inventory.id_inventory ASC;";
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
                        mysql_cmd += "AND (DateInOut.DateOut >= @dateAfter OR DateInOut.DateIn <= @dateBefore) ";
                        mysql_cmd += "ORDER BY history_info.id_inventory ASC;";
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
        /// <summary>
        /// Things that would happen when clikcing the confirm button in the manage tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                // Check the calidity of the text input
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
                // Confirm messagebox
                if (MessageBox.Show("Do you want to add this " + manage_option_warehouse_category + "?", "Confirm Message", MessageBoxButtons.OKCancel)
                    != DialogResult.OK)
                {
                    return;
                }
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
                        // If the insert is successful
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
                        // Then change the current name of the Other and the corresponding fee
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
                        // Then insert the origin other as a new category in the end of the category list
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
                // Confirm messagebox
                if (MessageBox.Show("Do you want to alter this " + manage_option_warehouse_category + "?", "Confirm Message", MessageBoxButtons.OKCancel)
                    != DialogResult.OK)
                {
                    return;
                }
                string fee = textBox_alter_fee.Text;
                // If the warehouse is selected
                string ID = manage_comboBox.SelectedValue.ToString();
                // Change the new fee
                if (db_connect.OpenConnection())
                {
                    string mysql_cmd = "UPDATE `gowaredb`.`" + manage_option_warehouse_category +
                        "` SET `fee`=@fee WHERE `id_" + manage_option_warehouse_category + "`=@ID";
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
            // If the remove is selected
            else
            {
                string ID = manage_comboBox.SelectedValue.ToString();
                // Check for the deletion of "Other"
                if (ID == categoryID_other)
                {
                    MessageBox.Show("Sorry! The type 'Other' cannot be removed!");
                    return;
                }
                // Confirm messagebox
                if (MessageBox.Show("Do you want to remove this " + manage_option_warehouse_category + "?", "Confirm Message", MessageBoxButtons.OKCancel)
                    != DialogResult.OK)
                {
                    return;
                }
                string mysql_cmd;
                MySqlCommand cmd;
                if (db_connect.OpenConnection())
                {
                    // Judge whether the category/warehouse can be removed.
                    mysql_cmd = "SELECT * FROM inventory WHERE `id_" + manage_option_warehouse_category + "`=@ID;";
                    cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        // If the dataReader is not null, 
                        // then there exists at least one inventory with this category/warehouse 
                        MessageBox.Show("Sorry! There still exists some inventories belonging to this " + manage_option_warehouse_category);
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
                if (db_connect.OpenConnection())
                {
                    // If can be removed, then should first remove the corresponding repository
                    mysql_cmd = "DELETE FROM `gowaredb`.`" + "repository"
                        + "` WHERE `id_" + manage_option_warehouse_category + "`=@ID;";
                    cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                    cmd.Parameters.AddWithValue("@ID", ID);
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
                    // Then remove the category/warehouse 
                    mysql_cmd = "DELETE FROM `gowaredb`.`" + manage_option_warehouse_category
                        + "` WHERE `id_" + manage_option_warehouse_category + "`=@ID;";
                    cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
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
            // Update the datagrid in time
            SetManage(manage_option_warehouse_category);
        }
        /// <summary>
        /// Check for number text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Check for int text (actually the same as check NO)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool checkTextAsInt(string text)
        {
            return checkTextAsNO(text);
        }
        /// <summary>
        /// Check for normal a-z A-Z 0-9 string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Check for normal tel string with 0-9 and "-"
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Update the fee when the change the selection in the combobox 
        /// of the manage tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    // Normally it should be only loop one time
                    fee_current = dataReader["fee"].ToString();
                }
                if (fee_current == "")
                {
                    MessageBox.Show("Database Error! Cannot find the " + manage_option_warehouse_category + "!");
                    return;
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
        /// <summary>
        /// Update the option when clicked the radio button of the warehouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                // Remove the listener temporarily for set combobox
                this.manage_comboBox.SelectedIndexChanged -= new System.EventHandler(this.manage_comboBox_SelectedIndexChanged);
                SetComboWarehouseManage(dt_warehouse_manage);
                this.manage_comboBox.SelectedIndexChanged += new System.EventHandler(this.manage_comboBox_SelectedIndexChanged);
                // Simulate click
                manage_comboBox.SelectedIndex = 1;
                manage_comboBox.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// Update the option when clicked the radio button of the category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Update the option and GUI when clicking the button of adding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Update the option and GUI when clicking the button of altering
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Update the option and GUI when clicking the button of removing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Update the option and GUI when clicking the button of inventory in the view tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_inventory_Click(object sender, EventArgs e)
        {
            view_search_option = "inventory";
            SetDefaultSearch(mysql_cmd_search_inventory_basic);
            ResetComboBoxDatePicker();
            view_textBox_InvNO.Clear();
        }
        /// <summary>
        /// Update the option and GUI when clicking the button of inventory in the manage tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_history_Click(object sender, EventArgs e)
        {
            view_search_option = "history";
            SetDefaultSearch(mysql_cmd_search_history_basic);
            ResetComboBoxDatePicker();
            view_textBox_InvNO.Clear();
        }
        /// <summary>
        /// Set the background color of the groupbox of 
        /// inventory_history choose button in the view tab to be invisible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }
        /// <summary>
        /// Set the background color of the groupbox of 
        /// add_alter_remove button in the manage tab to be invisible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }
        /// <summary>
        /// Set the background color of the groupbox of 
        /// warehouse_category button in the manage tab to be invisible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }
        /// <summary>
        /// Set the background color of the groupbox of the altering in the manage tab to be invisible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox_alter_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }
        /// <summary>
        /// Set the background color of the groupbox of the adding in the manage tab to be invisible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox_add_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }
        /// <summary>
        /// Set the background color of the groupbox of adding address in the manage tab to be invisible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox_add_address_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }
    }
}
