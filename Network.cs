using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WpfApp3
{
   public  class Network
    {
        [Key]
        public int Id { get; set; }
        private string Network_name;

        public int Id_User { get; set; }

        public int ID_Device { get; set; }

        public string Name
        {
            get { return Network_name; }
            set { Network_name = value; }
        }


        public Network() { }

        public Network(string Name, int Id_User, int ID_Device)
        {
            this.Name = Name;
            this.Id_User = Id_User;
            this.ID_Device = ID_Device;
        }


    }
}
