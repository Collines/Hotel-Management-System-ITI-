using System;
using System.Collections.Generic;
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

namespace HotelManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
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
    }
}
