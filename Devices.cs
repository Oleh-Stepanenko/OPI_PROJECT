using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WpfApp3
{
   public  class Devices
    {
        private string Device_name;


        [Key]
        public int Id_Device { get; set; }


        public string Name_Device
        {
            get { return Device_name; ; }
            set { Device_name = value; }
        }


        public Devices() { }

        public Devices(string Device_name)
        {
            Name_Device = Device_name;
           

        }


    }
}
