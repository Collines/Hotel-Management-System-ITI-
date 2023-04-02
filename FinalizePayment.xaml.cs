using System;
using System.Collections.Generic;
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

namespace HotelManagementSystem
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FinalizePayment : Window
    {
        public FinalizePayment()
        {
            InitializeComponent();
            PaymentTypeCombo.ItemsSource = new string[] { "Credit", "Debit" };
            MonthCombo.ItemsSource = Enumerable.Range(1, 12).ToList();
            YearCombo.ItemsSource = Enumerable.Range(DateTime.Now.Year, 10).ToList();
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
                CardTypeTxt.Text = "Visa";
            else if (MastercardRegEX.Matches(CardNumber.Text).Count > 0)
                CardTypeTxt.Text = "Mastercard";
            else if (DiscoverRegEX.Matches(CardNumber.Text).Count > 0)
                CardTypeTxt.Text = "Discover";
            else
                CardTypeTxt.Text = "Unknown";
        }
    }
}
