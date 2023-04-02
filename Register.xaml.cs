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
    public partial class Register : Window
    {
        LoginDB LoginDBContext = new();
        public Register()
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
            if (sender is TextBox Tbx)
            {
                if (Tbx?.Text.Length == 0)
                    Tbx.Text = "Username";
            }
            else if (sender is PasswordBox PwdBox)
            {
                if (PwdBox?.Password.Length == 0)
                    PwdBox.Password = "Password";
            }
        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)accountTypeCombo?.SelectedItem;
            AccountType accType;

            // validating inputs
            if(UsernameText.Text.IsNullOrEmpty() || UsernameText.Text.ToLower() == "username" || PasswordText.Password.IsNullOrEmpty() || PasswordText.Password.ToLower() == "password" || selectedItem==null)
            {
                CustomMessageBox.Show("Enter missing fields", "Enter missing fields!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            } else
            {

                accType = selectedItem.Content.ToString() == "Kitchen" ? AccountType.KitchenAccount : AccountType.FrontendAccount;

                // Validating that account doesn't exist
                if(accType == AccountType.KitchenAccount)
                {   
                    // validating kitchen accounts
                    if (LoginDBContext.KitchenUsers.FirstOrDefault(k => k.Username.ToLower() == UsernameText.Text.ToLower()) != null)
                    {
                        CustomMessageBox.Show("Account with this name already exist", "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                } else
                {
                    // validating frontend accounts
                    if (LoginDBContext.FrontendUsers.FirstOrDefault(k => k.Username.ToLower() == UsernameText.Text.ToLower()) != null)
                    {
                        CustomMessageBox.Show("Account with this name already exist", "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                // when passed all validations create account
                if(accType==AccountType.KitchenAccount)
                {
                    var HashedPassword = PasswordHandler.Hash(PasswordText.Password, out byte[] salt);
                    var saltStr = Convert.ToHexString(salt);
                    Kitchen newAccount = new Kitchen() { Username = UsernameText.Text,Password= HashedPassword,Salt= saltStr };
                    LoginDBContext.Add(newAccount);
                    LoginDBContext.SaveChanges();
                    CustomMessageBox.Show("Kitchen Account Created Successfully!", "Account Created!", MessageBoxButton.OK, MessageBoxImage.Information);
                    //RoomService roomService = new RoomService();
                    //roomService.Show();
                    //Close();
                } else
                {
                    var HashedPassword = PasswordHandler.Hash(PasswordText.Password, out byte[] salt);
                    var saltStr = Convert.ToHexString(salt);
                    Frontend newAccount = new Frontend() { Username = UsernameText.Text, Password = HashedPassword, Salt = saltStr };
                    LoginDBContext.Add(newAccount);
                    LoginDBContext.SaveChanges();
                    CustomMessageBox.Show("Frontend Account Created Successfully!", "Account Created!", MessageBoxButton.OK, MessageBoxImage.Information);
                    //FrontEnd front = new FrontEnd();
                    //front.Show();
                    //Close();
                }
                Login login = new Login();
                login.Show();
                Close();
            }
        }
    }
}
