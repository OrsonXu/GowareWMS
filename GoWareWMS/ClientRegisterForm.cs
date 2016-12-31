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
    public partial class ClientRegisterForm : Form
    {
        private string usertype;
        private string username;
        private string password;
        private string email;

        private string firstname;
        private string middlename;
        private string lastname;
        private string sex;

        private string companyname;

        private DBConnect db_connect;

        public ClientRegisterForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize() 
        {
            radioButton_personal.Select();
            groupBox_both.Visible = true;
            db_connect = new DBConnect();
        }

        private void groupBox_type_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }
        /// <summary>
        /// When register personal client.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_personal_Click(object sender, EventArgs e)
        {
            usertype = "personal";
            groupBox_personal.Visible = true;
            groupBox_corporate.Visible = false;
            textBox_companyname.Clear();
        }
        /// <summary>
        /// When register corpporate client.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_corporate_Click(object sender, EventArgs e)
        {
            usertype = "corporate";
            groupBox_personal.Visible = false;
            groupBox_corporate.Visible = true;
            textBox_firstname.Clear();
            textBox_middlename.Clear();
            textBox_lastname.Clear();
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
            // Check username input
            if (!checkTextAsCharater(username))
            {
                MessageBox.Show("Invalid username!");
                return;
            }
            // Check password input
            if (!checkTextAsCharater(password))
            {
                MessageBox.Show("Invalid password!");
                return;
            }
            // Check email input
            if (!checkTextAsEmail(email))
            {
                MessageBox.Show("Invalid email!");
                return;
            }
            // Register as personal client
            if (usertype == "personal")
            {
                firstname = textBox_firstname.Text;
                middlename = textBox_middlename.Text;
                lastname = textBox_lastname.Text;
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
            }
            // Register as corporate client
            else
            {
                companyname = textBox_companyname.Text;
                if (!checkTextAsCharater(companyname))
                {
                    MessageBox.Show("Invalid company name!");
                    return;
                }
            }
            if (db_connect.OpenConnection())
            {
                string mysql_cmd;
                MySqlCommand cmd;
                // Insert the new client
                if (usertype == "personal")
                {
                    mysql_cmd = "INSERT INTO `gowaredb`.`client` (`usertype`, `username`, `password`, `email`, `firstname`, `middlename`, `lastname`, `sex`) "
                        + "VALUES ('personal', @username, @password, @email, @firstname, @middlename, @lastname, @sex);";
                    cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                    cmd.Parameters.AddWithValue("@firstname", firstname);
                    cmd.Parameters.AddWithValue("@middlename", middlename);
                    cmd.Parameters.AddWithValue("@lastname", lastname);
                    cmd.Parameters.AddWithValue("@sex", sex);
                }
                else
                {
                    mysql_cmd = "INSERT INTO `gowaredb`.`client` (`usertype`, `username`, `password`, `email`, `companyname`) "
                        + "VALUES ('corporate', @username, @password, @email, @companyname);";
                    cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                    cmd.Parameters.AddWithValue("@companyname", companyname);
                }
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Registered Successfully!");
                    this.Close();
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
        /// Set groupbox back color to be white of the common part of the "personal" and "corporate"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox_both_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }
        /// <summary>
        /// Set groupbox back color to be white of the part of "corporate"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox_corporate_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }
        /// <summary>
        /// Set groupbox back color to be white of the part of "personal"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox_personal_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }
        /// <summary>
        /// Set groupbox back color to be white of sex selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox_personal_sex_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
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
        /// Check the text input as the company name, characters + blankspace " "
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool checkTextAsCompanyName(string text)
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
                    || (n >= 97 && n <= 122)
                    || (n == 32))
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
    }
}
