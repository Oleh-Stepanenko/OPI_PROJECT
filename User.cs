using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WpfApp3
{
   public  class User
    {
        [Key]
        public int Id { get; set; }
        private string Logins, Passwords, Emails;

        public string Login
        {
            get { return Logins; }
            set { Logins = value; }
        }
        public string Password
        {
            get { return Passwords; }
            set { Passwords = value; }
        }
        public string Email
        {
            get { return Emails; }
            set { Emails = value; }
        }
        public User() { }

        public User(string LOGINS, string PASSWORDS, string EMAILS) {
            this.Logins = LOGINS;
            this.Passwords = PASSWORDS;
            this.Emails = EMAILS;

        }

        

    }
}
