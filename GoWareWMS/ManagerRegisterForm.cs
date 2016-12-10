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

        private void groupBox_both_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }

        private void groupBox_personal_sex_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
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
            if (!checkTextAsCharater(username))
            {
                MessageBox.Show("Invalid username!");
                return;
            }
            if (!checkTextAsCharater(password))
            {
                MessageBox.Show("Invalid password!");
                return;
            }
            if (!checkTextAsEmail(email))
            {
                MessageBox.Show("Invalid email!");
                return;
            }
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
        private void radioButton_sex_m_Click(object sender, EventArgs e)
        {
            sex = "M";
        }

        private void radioButton_sex_f_Click(object sender, EventArgs e)
        {
            sex = "F";
        }




    }
}
