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
    public partial class ManagerRegisterForm : Form
    {
        private DBConnect db_connect;

        private string username;
        private string password;
        private string email;

        private string firstname;
        private string middlename;
        private string lastname;
        private string sex;

        private string key;

        public ManagerRegisterForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            db_connect = new DBConnect();
        }
        /// <summary>
        /// Select sex as male
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_sex_m_Click(object sender, EventArgs e)
        {
            sex = "M";
        }
        /// <summary>
        /// Select sex as female
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_sex_f_Click(object sender, EventArgs e)
        {
            sex = "F";
        }
        /// <summary>
        /// When the register button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_register_Click(object sender, EventArgs e)
        {
            username = textBox_username.Text;
            password = textBox_password.Text;
            email = textBox_email.Text;
            firstname = textBox_firstname.Text;
            middlename = textBox_middlename.Text;
            lastname = textBox_lastname.Text;
            key = textBox_key.Text;
            string keyID = "";
            // Check username
            if (!checkTextAsCharater(username))
            {
                MessageBox.Show("Invalid username!");
                return;
            }
            // Check password
            if (!checkTextAsCharater(password))
            {
                MessageBox.Show("Invalid password!");
                return;
            }
            // Check email
            if (!checkTextAsEmail(email))
            {
                MessageBox.Show("Invalid email!");
                return;
            }
            // Check name
            if (!checkTextAsCharater(firstname))
            {
                MessageBox.Show("Invalid first name!");
                return;
            }
            if (middlename.Length != 0)
            {
                if (!checkTextAsCharater(middlename))
                {
                    MessageBox.Show("Invalid middle name!");
                    return;
                }
            }
            if (!checkTextAsCharater(lastname))
            {
                MessageBox.Show("Invalid last name!");
                return;
            }
            // Check whether the manage key is valid
            keyID = judgeKey(key);
            if (key.Length == 0 || keyID == "")
            {
                MessageBox.Show("Invalid Management Key!");
                return;
            }
            if (db_connect.OpenConnection())
            {
                string mysql_cmd = "INSERT INTO `gowaredb`.`manager` (`id_key`, `username`, `password`, `email`, `firstname`, `middlename`, `lastname`, `sex`) "
                 + "VALUES (@keyID, @username, @password, @email, @firstname, @middlename, @lastname, @sex);";
                MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                cmd.Parameters.AddWithValue("@keyID", keyID);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@middlename", middlename);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@sex", sex);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Registered Successfully!");
                    this.Close();
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
        /// <summary>
        /// Judge whether the manage key is in the database
        /// </summary>
        /// <param name="key"></param>
        /// <returns>True if the key is valid. Flase if the key cannot be found in the database</returns>
        private string judgeKey(string key)
        {
            string ID = "";
            if (db_connect.OpenConnection())
            {
                string mysql_cmd = "SELECT * FROM manage_key";
                MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    if (key == dataReader["key"].ToString())
                    {
                        ID = dataReader["id_key"].ToString();
                        break;
                    }
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
            return ID;
        }
        /// <summary>
        /// Check the text input as pure characters a-z A-Z 0-9
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
        /// Check the text input as the email, including characters, @ and "."
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool checkTextAsEmail(string text)
        {
            if (text.Length == 0)
            {
                return false;
            }
            if (text.IndexOf('.') < text.IndexOf('@'))
            {
                return false;
            }
            for (int i = 0; i < text.Length; ++i)
            {
                if (!
                    ((text[i] >= 48 && text[i] <= 57)
                    || (text[i] >= 65 && text[i] <= 90)
                    || (text[i] >= 97 && text[i] <= 122)
                    || (text[i] == 64)
                    || (text[i] == 46))
                    )
                {
                    return false;
                }
                if (text[i] == 64)
                {
                    if (i == text.Length - 1)
                    {
                        return false;
                    }
                    else if (text[i + 1] == 46)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Set groupbox back color to be white of the part of basic information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox_both_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }
        /// <summary>
        /// Set groupbox back color to be white of the part of sex selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox_personal_sex_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }


    }
}
