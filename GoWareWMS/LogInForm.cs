using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GoWareWMS
{
    public partial class LogInForm : Form
    {
        private Client client;
        private Manager manager;
        private DBConnect db_connect;
        
        public LogInForm()
        {
            InitializeComponent();
            db_connect = new DBConnect();
            client = new Client();
            manager = new Manager();
        }

        private void btn_client_login_Click(object sender, EventArgs e)
        {
            client.Username = textBox_username_client.Text;
            client.Password = textBox_pwd_client.Text;
            bool logInSucc = false;
            
            if (client.Username == "")
            {
                MessageBox.Show("Please enter the Username.");
                logInSucc = false;
            } 
            else if (! checkText(client.Username))
            {
                MessageBox.Show("Invalid Username.");
                logInSucc = false;
            }
            else if (client.Password == "")
            {
                MessageBox.Show("Please enter the Password.");
                logInSucc = false;
            }
            else {
                if (db_connect.OpenConnection())
                {
                    string mysql_cmd = "SELECT * FROM client " +
                        "WHERE (username = \"" + client.Username + "\"" +
                        " AND password = \"" + client.Password + "\");";
                    MySqlCommand cmd = new MySqlCommand(mysql_cmd, db_connect.Connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (dataReader["username"].ToString() == client.Username
                            && dataReader["password"].ToString() == client.Password)
                        {
                            client.ID = dataReader["id_client"].ToString();
                            client.Type = dataReader["usertype"].ToString();
                            client.Email = dataReader["email"].ToString();
                            if (client.Type == "person")
                            {
                                client.Firstname = dataReader["firstname"].ToString();
                                client.Middlename = dataReader["middlename"].ToString();
                                client.Lastname = dataReader["lastname"].ToString();
                                client.Sex = dataReader["sex"].ToString();
                            }
                            else if (client.Type == "company")
                            {
                                client.Companyname = dataReader["companyname"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Client type error!");
                                Thread.Sleep(1000);
                                this.Close();
                            }
                            logInSucc = true;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("DB Error!");
                        }
                    }
                    if (!logInSucc)
                    {
                        MessageBox.Show("The Username or the Password is incorrect");
                        textBox_pwd_client.Clear();
                    }
                }
                else
                {
                    logInSucc = false;
                    MessageBox.Show(db_connect.Message);
                }
            }
            if (logInSucc)
            {
                switchToClientMainForm();
            }
            if (!db_connect.CloseConnection())
            {
                MessageBox.Show(db_connect.Message);
            }
        }

        private void switchToClientMainForm()
        {
            Thread.Sleep(2000);
            ClientMainForm clientMainForm = new ClientMainForm(client);
            //clientMainForm.SetClient();
            clientMainForm.Show();
            this.Hide();
        }

        private bool checkText(string text)
        {
            foreach (char c in text )
            {   
                int n = (int) c;
                if ( ! ((n >= 48 && n <= 57) ||
                    (n >= 65 && n <= 90) ||
                    (n >= 97 && n <= 122)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
