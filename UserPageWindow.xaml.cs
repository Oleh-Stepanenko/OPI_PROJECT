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
    /// Логика взаимодействия для UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        DATADBContext dATADB = new DATADBContext();
        User users = new User();
        public UserPageWindow(string Name)
        {
            InitializeComponent();
            this.User.Text = Name;
            User users = dATADB.Users.Where(ItemCollection => ItemCollection.Login == Name).FirstOrDefault();
            List<Network> networks = dATADB.Networks.Where(x => x.Id_User == users.Id).ToList();
            if (networks.Count != 0)
            {
                networks.ForEach(item => ListOfUsers.Items.Add("Назва мережі:" + "\t" + item.Name));
            }
            else
            {
                MessageBox.Show("У користувача немає мереж");
            }

            this.users = users;

            var User_logn = users.Login;
            var User_Email = users.Email;
            this.User_Login.Text = User_logn;
            this.User_Email.Text = User_Email;

        }
        public UserPageWindow()
        {
            
        }
           
            private void Create_Net(object sender, RoutedEventArgs e)
        {
            Create_Net create_Net = new Create_Net(users,this.ListOfUsers);
            create_Net.Show();
           
        }

        
        private void Delete_Net(object sender, RoutedEventArgs e)
        {

            try
            {

                var kk = this.ListOfUsers.SelectedItem.ToString().Split('\t')[1];
                this.ListOfUsers.Items.Clear();
                var bb = this.dATADB.Networks.Where(item => item.Name.Contains(kk)).FirstOrDefault();
                this.dATADB.Networks.Remove(bb);
                this.dATADB.SaveChanges();
                User users = dATADB.Users.Where(ItemCollection => ItemCollection.Login == this.User.Text).FirstOrDefault();
                List<Network> networks = dATADB.Networks.ToList().Where(item => item.Id_User == users.Id).ToList();
                networks.ForEach(item => ListOfUsers.Items.Add("Назва мережі:" + "\t" + item.Name));





            }
            catch (Exception cs)
            {

                Console.WriteLine(cs.Message);
            }
           
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Show_information_Click(object sender, RoutedEventArgs e)
        {
            InformationWindow info = new InformationWindow(users);
            info.Show();

        }
    }
}
