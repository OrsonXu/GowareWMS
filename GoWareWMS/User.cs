using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWareWMS
{
    public abstract class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string ID { get; set; }
    }

    public  class Client : User 
    {
        public string Type { get; set; }
        public string Companyname { get; set; }

        public Client()
        {
            Username = "";
            Password = "";
            Firstname = "";
            Middlename = "";
            Lastname = "";
            Sex = "";
            Type = "";
            Companyname = "";
        }
    }

    public  class Manager : User
    {
        public Manager()
        {
            Username = "";
            Password = "";
            Firstname = "";
            Middlename = "";
            Lastname = "";
            Sex = "";
        }
    }

}
