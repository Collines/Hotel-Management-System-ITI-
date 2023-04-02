using HotelManagementSystem.Context;
using HotelManagementSystem.HelperClasses;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
using WPFCustomMessageBox;

namespace HotelManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        LoginDB LoginDBContext = new();
        public Login()
        {
            InitializeComponent();
            Closed += (sender, e) => LoginDBContext.Dispose();
        }

        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ClearPlaceholder(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox Tbx)
            {
                if (Tbx?.Text == "Username")
                    Tbx.Text = "";
            }
            else if (sender is PasswordBox PwdBox)
                {
                    if (PwdBox?.Password == "Password")
                        PwdBox.Password = "";
                }
        }

        private void RemovedFocus(object sender, RoutedEventArgs e)
        {
            if(sender is TextBox Tbx)
            {
                if (Tbx?.Text.Length == 0)
                    Tbx.Text = "Username";
            }
            else if(sender is PasswordBox PwdBox)
            {
                if (PwdBox?.Password.Length == 0)
                    PwdBox.Password = "Password";
            }
        }

        private void SignInClick(object sender, RoutedEventArgs e)
        {
            if (UsernameText.Text.IsNullOrEmpty() || PasswordText.Password.IsNullOrEmpty())
            {
                CustomMessageBox.Show("Please fill fields", "Enter missing fields!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (LoginDBContext.KitchenUsers.FirstOrDefault(k => k.Username.ToLower() == UsernameText.Text.ToLower()) != null)
                {
                    var Cred = LoginDBContext.KitchenUsers.Where(K => K.Username.ToLower() == UsernameText.Text.ToLower()).Select(K => new { K.Password, K.Salt }).FirstOrDefault();
                    if (PasswordHandler.VerifyPassword(PasswordText.Password,Cred?.Password,Convert.FromHexString(Cred?.Salt)))
                    {
                        RoomService roomService = new RoomService();
                        roomService.Show();
                        Close();
                    } else
                    {
                        CustomMessageBox.Show("Wrong Credintials", "Wrong Credintials!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else if (LoginDBContext.FrontendUsers.FirstOrDefault(F => F.Username.ToLower() == UsernameText.Text.ToLower()) != null)
                {
                    var Cred = LoginDBContext.FrontendUsers.Where(F => F.Username.ToLower() == UsernameText.Text.ToLower()).Select(F => new { F.Password, F.Salt }).FirstOrDefault();
                    if (PasswordHandler.VerifyPassword(PasswordText.Password, Cred?.Password, Convert.FromHexString(Cred?.Salt)))
                    {
                        FrontEnd frontend = new FrontEnd();
                        frontend.Show();
                        Close();
                    }
                    else
                    {
                        CustomMessageBox.Show("Wrong Credintials", "Wrong Credintials!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                } else
                {
                    CustomMessageBox.Show("Wrong Credintials", "Wrong Credintials!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }
    }
}
