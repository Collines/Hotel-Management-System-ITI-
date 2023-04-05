using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using WPFCustomMessageBox;

namespace HotelManagementSystem
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FinalizePayment : Window
    {
        FrontEnd Caller;

        public CardType CardType { get; private set; }
        public PaymentType PaymentType { get; private set; }
        public string Cardnumber { get; private set; }
        //public DateTime CardExpireDate { get; private set; }
        public int CardExpireMonth {get; private set;}
        public int CardExpireYear {get; private set; }
        public string CVC { get; private set; }
        public decimal TotalBill { get; private set; }

        public FinalizePayment(FrontEnd caller)
        {
            InitializeComponent();
            PaymentTypeCombo.ItemsSource = new string[] { "Credit", "Debit" };
            MonthCombo.ItemsSource = Enumerable.Range(1, 12).ToList();
            YearCombo.ItemsSource = Enumerable.Range(DateTime.Now.Year, 10).ToList();
            UpdatePaymentFields();
            Caller = caller;
            //FoodBill.SetBinding(TextBlock.TextProperty, "FoodPrice"); /* = $"{Caller.FoodPrice}";*/
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CheckType(object sender, KeyEventArgs e)
        {
            Regex VisaRegEX = new("^4[0-9]{6,}$");
            Regex MastercardRegEX = new("^5[1-5][0-9]{5,}|222[1-9][0-9]{3,}|22[3-9][0-9]{4,}|2[3-6][0-9]{5,}|27[01][0-9]{4,}|2720[0-9]{3,}$");
            Regex DiscoverRegEX = new("^6(?:011|5[0-9]{2})[0-9]{3,}$");
            if (VisaRegEX.Matches(CardNumber.Text).Count > 0)
            {
                CardTypeTxt.Text = "Visa";
                CardType = CardType.Visa;
            }
            else if (MastercardRegEX.Matches(CardNumber.Text).Count > 0)
            {
                CardTypeTxt.Text = "Mastercard";
                CardType = CardType.Mastercard;
            }
            else if (DiscoverRegEX.Matches(CardNumber.Text).Count > 0)
            {
                CardTypeTxt.Text = "Discover";
                CardType = CardType.Discover;
            }
            else
            {
                CardTypeTxt.Text = "Unknown";
                CardType = CardType.Unknown;
            }
        }

        public void UpdatePaymentFields()
        {
            FoodBill.Text = $"{Caller?.FoodPrice}";
            CurrentBill.Text = $"{Caller?.RoomPrice}";
            Tax.Text = $"{0.14m * (Caller?.FoodPrice + Caller?.RoomPrice)}";
            Total.Text = $"{Caller?.FoodPrice + Caller?.RoomPrice + (0.14m * (Caller?.FoodPrice + Caller?.RoomPrice))}";
        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            if (PaymentTypeCombo.SelectedIndex != null)
                PaymentType = (PaymentType)(PaymentTypeCombo.SelectedIndex + 1);
            if(CardNumber.Text.Length == 0 || CardType == CardType.Unknown)
            {
                CustomMessageBox.Show("Enter a valid Card number", "Enter valid values", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else
            {
                Cardnumber = CardNumber.Text;
            }
            
            //MonthCombo?.SelectedValue?.ToString()?.Length;
            if (MonthCombo?.SelectedValue?.ToString()?.Length > 0 && YearCombo?.SelectedValue?.ToString()?.Length >0)
            {
                CardExpireMonth = int.Parse(MonthCombo.SelectedValue.ToString());
                CardExpireYear = int.Parse(YearCombo.SelectedValue.ToString());
            } else
            {
                CustomMessageBox.Show("Enter a valid Expire Date", "Enter valid values", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(CVCTXT.Text.Length > 0)
                CVC = CVCTXT?.Text;
            else
            {
                CustomMessageBox.Show("Enter a valid CVC", "Enter valid values", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            TotalBill = decimal.Parse(Total.Text);

            Visibility = Visibility.Hidden;
        }

        private void VisibleHand(object sender, DependencyPropertyChangedEventArgs e)
        {
            //FoodBill.Text = $"{Caller.FoodPrice}";
            UpdatePaymentFields();
        }
    }
}
