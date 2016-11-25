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
     
    public partial class ManagerMainForm : Form
    {
        private Manager manager;
        private DBConnect db_connect;

        private DataTable dt_warehouse_view;
        private DataColumn dc_warehouse_id_view;
        private DataColumn dc_warehouse_name_view;

        private DataTable dt_category_view;
        private DataColumn dc_category_id_view;
        private DataColumn dc_category_name_view;

        private DataSet ds_search;

        private string mysql_cmd_search_inventory_basic;
        private string mysql_cmd_search_history_basic;
        private string view_search_option;


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

            ds_search = new DataSet();

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

            SetComboWarehouseView(dt_warehouse_view);
            SetComboCategoryView(dt_category_view);
            SetDefaultSearch(mysql_cmd_search_inventory_basic);

            radioButton_inventory.Checked = true;

            view_textBox_InvNO.Clear();
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
                dataGridView_manager.DataSource = ds_search.Tables[0].DefaultView;
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
                if (!checkText(invNO))
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
                    dataGridView_manager.DataSource = ds_search.Tables[0].DefaultView;
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
                    dataGridView_manager.DataSource = ds_search.Tables[0].DefaultView;
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
    }
}
