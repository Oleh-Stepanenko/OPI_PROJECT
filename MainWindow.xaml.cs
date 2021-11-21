using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DATADBContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new DATADBContext();

            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 450;
            doubleAnimation.Duration = TimeSpan.FromSeconds(1);
            regButton.BeginAnimation(Button.WidthProperty,doubleAnimation);
        }

        private void Button_REG_Click(object sender, RoutedEventArgs e)
        {

            
            
           

            string login = textlogin.Text.Trim();
            string password = textpassword.Password.Trim();
            string second_password = textsecond_password.Password.Trim();
            string email = textemail.Text.ToLower().Trim();

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                textemail.ToolTip = " is correct";
                textemail.Background = Brushes.Transparent;
            }
            else
            {
                textemail.ToolTip = " is incorrect";
                textemail.Background = Brushes.DarkRed;
            }

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
                else if (second_password != password)
                {
                    textsecond_password.ToolTip = "Вторий пароль не збігається з першим";
                    textsecond_password.Background = Brushes.DarkRed;
                }
                else
                {

                    textlogin.Background = Brushes.Transparent;

                    textpassword.Background = Brushes.Transparent;

                    textsecond_password.Background = Brushes.Transparent;

                    textemail.Background = Brushes.Transparent;

                    MessageBox.Show("Користувач зареєстрований");



                    try {
                        User user = new User(login, password, email);
                        db.Users.Add(user);
                        db.SaveChanges();
                        AuthWindow authWindow = new AuthWindow();
                        authWindow.Show();
                        Close();

                    } 
                catch (Exception ex) { Console.WriteLine(ex.Message); }

                

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

        private void textsecond_password_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string second_password = textsecond_password.Password.Trim();
            string password = textpassword.Password.Trim();
            if (second_password != password)
            {
                textsecond_password.ToolTip = "Вторий пароль не збігається з першим";
                textsecond_password.Background = Brushes.DarkRed;
            }
            else { textsecond_password.Background = Brushes.Transparent; }
        }

        private void textemail_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string email = textemail.Text.ToLower().Trim();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                textemail.ToolTip = " is correct";
                textemail.Background = Brushes.Transparent;
            }
            else
            {
                textemail.ToolTip = " is incorrect";
                textemail.Background = Brushes.DarkRed;
            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }
    }
}
