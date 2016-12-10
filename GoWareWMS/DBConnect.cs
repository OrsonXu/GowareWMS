using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace GoWareWMS
{
    public class DBConnect
    {
        public MySqlConnection Connection { get; set; }
        public string Message { get; set; }
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "gowaredb";
            uid = "root";
            password = "orsonxu";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            Connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                Message = "Successfully connect";
                return true;
            }
            catch (MySqlException ex)
            {
                Message = ex.ToString();
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {   
                if (Connection.State != ConnectionState.Closed)
                    Connection.Close();
                Message = "Successfully disconnect";
                return true;
            }
            catch (MySqlException ex)
            {
                Message = ex.ToString();
                return false;
            }
        }
    }
}
