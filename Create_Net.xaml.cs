using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Create_Net.xaml
    /// </summary>
    public partial class Create_Net : Window
    {
        User User = new User();
        ListView ListView = new ListView();
        Devices Devices = new Devices();
        DATADBContext DATADBContext = new DATADBContext();

        public Create_Net(User user,ListView listView)
        {

            this.ListView = listView;
            this.User = user;
            InitializeComponent();
            List<Devices> dev = new List<Devices>();
            foreach (var device in DATADBContext.Devices)
            {
                dev.Add(device);
            }
            this.FirstDevice.Text = dev[0].Name_Device.ToString();
            this.SecondDevice.Text = dev[1].Name_Device.ToString();
            this.ThirdDevice.Text = dev[2].Name_Device.ToString();
            this.FourthDevice.Text = dev[3].Name_Device.ToString();

            

        }
        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            var fff = comboBox.SelectedIndex;
            Devices devices = DATADBContext.Devices.Where(x => x.Id_Device - 1 == fff).FirstOrDefault();
            Devices.Id_Device = devices.Id_Device;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string network = Write_Net.Text.Trim();
                if (network != "")
                {
                    this.ListView.Items.Clear();

                    this.DATADBContext.Networks.Add(new Network(network, User.Id, Devices.Id_Device));
                    this.DATADBContext.SaveChanges();
                    User users = DATADBContext.Users.Where(ItemCollection => ItemCollection.Login == this.User.Login).FirstOrDefault();
                    List<Network> networks = DATADBContext.Networks.ToList().Where(item => item.Id_User == users.Id).ToList();
                    networks.ForEach(item => ListView.Items.Add("Назва мережі:" + "\t" + item.Name));
                    MessageBox.Show("Мережу було створено");


                }
                else
                {
                    MessageBox.Show("Введіть коректну назву мережі");
                }
            }
            catch (Exception CS)
            {

                Console.WriteLine(CS.Message);
            }
            
        }
    }
}
