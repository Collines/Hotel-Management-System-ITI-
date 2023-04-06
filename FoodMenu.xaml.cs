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
using System.Windows.Shapes;

namespace HotelManagementSystem
{
    /// <summary>
    /// Interaction logic for FoodMenu.xaml
    /// </summary>
    public partial class FoodMenu : Window
    {
        FrontEnd CallerWindow;
        public static decimal FoodPrice = 0;
        public static decimal ServicesPrice = 0;
        public FoodMenu(FrontEnd? caller = null)
        {
            InitializeComponent();
            if(caller != null) 
                CallerWindow = caller;
        }

        private void NextBtnClick(object sender, RoutedEventArgs e)
        {
            FoodPrice = 0;
            ServicesPrice = 0;
            if(BreakfastPrice.IsChecked == true && int.TryParse(BreakfastQuantity.Text,out int BreakfastQ))
            {
                FoodPrice += BreakfastQ * 7;
                CallerWindow.Breakfast = BreakfastQ;
            }
            if(LunchPrice.IsChecked == true && int.TryParse(LunchQuantity.Text, out int LunchQ))
            {
                FoodPrice += LunchQ * 15;
                CallerWindow.Lunch = LunchQ;
            }
            if (DinnerPrice.IsChecked == true && int.TryParse(DinnerQuantity.Text, out int DinnerQ))
            {
                FoodPrice += DinnerQ * 15;
                CallerWindow.Dinner = DinnerQ;
            }
            if (Towels.IsChecked == true)
            {
                ServicesPrice += 20;
                CallerWindow.Towels = true;
            }
            if (Surprise.IsChecked == true)
            {
                ServicesPrice += 30;
                CallerWindow.SweetestSurprise = true;
            }
            if(Cleaning.IsChecked == true)
            {
                ServicesPrice += 30;
                CallerWindow.Cleaning = true;
            }
            CallerWindow.FoodPrice = FoodPrice;
            CallerWindow.ServicesPrice = ServicesPrice;
            Visibility = Visibility.Hidden;
        }

        private void FocusEvent(object sender, RoutedEventArgs e)
        {
            TextBox TB = sender as TextBox;
            if(TB?.Text.ToLower() == "quantity?")
                TB.Text = "";
            if(TB.Name == "BreakfastQuantity")
                BreakfastLabel.Visibility = Visibility.Hidden;
            if (TB.Name == "DinnerQuantity")
                DinnerLabel.Visibility = Visibility.Hidden;
            if (TB.Name == "LunchQuantity")
                LunchLabel.Visibility = Visibility.Hidden;
        }

        private void LostFocusEvent(object sender, RoutedEventArgs e)
        {
            TextBox TB = sender as TextBox;
            if (TB?.Text.Length == 0)
                TB.Text = "Quantity?";
            if(!int.TryParse(TB?.Text,out int r))
            {
                if(TB?.Name == "DinnerQuantity")
                    DinnerLabel.Visibility = Visibility.Visible;
                if(TB?.Name == "LunchQuantity")
                    LunchLabel.Visibility = Visibility.Visible;
                if(TB?.Name == "BreakfastQuantity")
                    BreakfastLabel.Visibility = Visibility.Visible;

            }

        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Name == "BreakfastPrice" && checkBox.IsChecked !=true)
                BreakfastLabel.Visibility = Visibility.Hidden;
            if (checkBox.Name == "LunchPrice" && checkBox.IsChecked != true)
                LunchLabel.Visibility = Visibility.Hidden;
            if (checkBox.Name == "DinnerPrice" && checkBox.IsChecked != true)
                DinnerLabel.Visibility = Visibility.Hidden;
        }
    }
}
