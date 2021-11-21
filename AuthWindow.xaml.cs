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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        
        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = textlogin.Text.Trim();
                string password = textpassword.Password.Trim();

                if (login.Length < 4)
                {
                    textlogin.ToolTip = "Введіть коректний логін";
                    textlogin.Background = Brushes.DarkRed;
                }
                else if (password.Length < 5)
                {
                    textpassword.ToolTip = "Введіть коректний пароль більше 10 символів";
                    textpassword.Background = Brushes.DarkRed;
                }
                else
                {
                    textlogin.Background = Brushes.Transparent;

                    textpassword.Background = Brushes.Transparent;

                    User autofication = null;

                    using (DATADBContext DATADB = new DATADBContext())
                    {
                        autofication = DATADB.Users.Where(data => data.Login == login && data.Password == password).FirstOrDefault();
                    }

                    if (autofication != null)
                    {
                        UserPageWindow userPageWindow = new UserPageWindow(autofication.Login);
                        userPageWindow.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Користувача з такими даними не знайдено");
                    }

                }
            }

            catch (Exception cs)
            {
                Console.WriteLine(cs.Message);
            }


        }
       
        private void textlogin_MouseLeave(object sender, MouseEventArgs e)
        {
            string login = textlogin.Text.Trim();
            if (login.Length < 4)
            {
                textlogin.ToolTip = "Введіть коректний логін";
                textlogin.Background = Brushes.DarkRed;
            }
            else
            {
                textlogin.Background = Brushes.Transparent;
            }
        }

        private void textpassword_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string password = textpassword.Password.Trim();
            if (password.Length < 5)
            {
                textpassword.ToolTip = "Введіть коректний пароль більше 10 символів";
                textpassword.Background = Brushes.DarkRed;
            }
            else
            {
                textpassword.Background = Brushes.Transparent;
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow auth = new MainWindow();
            auth.Show();
            Close();
        }
    }
}
