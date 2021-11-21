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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class InformationWindow : Window
    {
        User User = new User();
       // ListView ListView = new ListView();
        Devices Devices = new Devices();
        DATADBContext DATADBContext = new DATADBContext();

        public InformationWindow(User user)
        {
           // this.ListView = listView;
            this.User = user;
            InitializeComponent();
            Show_info();
        }
        public void Show_info()
        {
            User users = DATADBContext.Users.Where(ItemCollection => ItemCollection.Login == this.User.Login).FirstOrDefault();
           
            List<Network> networks = DATADBContext.Networks.ToList().Where(item => item.Id_User == users.Id).ToList();


            networks.ForEach(elem => { Devices devices1 = DATADBContext.Devices.Where(item => item.Id_Device == elem.ID_Device).FirstOrDefault(); this.ListOfNetworks.Items.Add("Назва мережі" + "\t" +
                elem.Name + "\n" + "Ім'я коритсувача" + "\t" + users.Login + "\n" + "Назва девайсу" + "\t" + devices1.Name_Device);});
        }
    }
}
