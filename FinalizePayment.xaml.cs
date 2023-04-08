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
    public partial class FinalizePayment : Window
    {
        FrontEnd Caller;

        public CardType CardType { get; private set; }
        public PaymentType PaymentType { get; private set; }
        public string Cardnumber { get; private set; }
        public int CardExpireMonth {get; private set;}
        public int CardExpireYear {get; private set; }
        public string CVC { get; private set; }
        public decimal TotalBill { get; private set; }
        public decimal? CurrentBill { get; private set; }
        public decimal? FoodBill { get; private set; }

        public FinalizePayment(FrontEnd caller)
        {
            InitializeComponent();
            Caller = caller;
            MonthCombo.ItemsSource = Enumerable.Range(1, 12).ToList();
            YearCombo.ItemsSource = Enumerable.Range(DateTime.Now.Year, 10).ToList();
            UpdatePaymentFields();
            Closed += (sender, e) => caller.FP = null;
            if(caller.Payment!=null)
            {
                DataContext = caller.Payment;
            }
        }


        private void CheckType()
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
            //if(DataContext == null)
            //{
            //    FoodBillTxtBlock.Text = $"{Caller?.FoodPrice + Caller?.ServicesPrice}";
            //    CurrentBillTxtBlock.Text = $"{Caller?.RoomPrice}";
            //    Tax.Text = $"{0.14m * (Caller?.FoodPrice + Caller?.RoomPrice)}";
            //    Total.Text = $"{Caller?.FoodPrice + Caller?.RoomPrice + (0.14m * (Caller?.FoodPrice + Caller?.RoomPrice))}";
            //    //
            //    FoodBill = Caller?.FoodPrice + Caller?.ServicesPrice;
            //    CurrentBill = Caller?.RoomPrice;
            //}
            //else
            //{
            //    Payment P = DataContext as Payment;
            //    FoodBillTxtBlock.Text = $"{P.Foodbill}";
            //    CurrentBillTxtBlock.Text = $"{P.CurrentBill}";
            //    Tax.Text = $"{P.Tax}";
            //    Total.Text = $"{P.Foodbill +P.CurrentBill + P.Tax}";
            //}


            Payment P = DataContext as Payment;
            FoodBillTxtBlock.Text = $"{P.Foodbill}";
            CurrentBillTxtBlock.Text = $"{P.CurrentBill}";
            Tax.Text = $"{0.14 * (P.Foodbill + P.CurrentBill)}";
            Total.Text = $"{P.Foodbill + P.CurrentBill + (0.14 * (P.Foodbill + P.CurrentBill))}";
            //
            //FoodBill = Caller?.FoodPrice + Caller?.ServicesPrice;
            //CurrentBill = Caller?.RoomPrice;

        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            if (PaymentTypeCombo.SelectedIndex != null && PaymentTypeCombo.SelectedIndex >= 0)
                PaymentType = (PaymentType)(PaymentTypeCombo.SelectedIndex);
            else
            {
                CustomMessageBox.Show("Enter a valid Payment Type", "Enter valid values", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(CardNumber.Text.Length == 0 || CardType <0)
            {
                CustomMessageBox.Show("Enter a valid Card number", "Enter valid values", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else
            {
                Cardnumber = CardNumber.Text;
            }

            //if (MonthCombo?.SelectedValue?.ToString()?.Length > 0 && 
            //    YearCombo?.SelectedValue?.ToString()?.Length >0 &&
            //    int.TryParse(MonthCombo.SelectedValue.ToString(), out int M) && 
            //    int.TryParse(YearCombo.SelectedValue.ToString(), out int Y))
            //{
            //        CardExpireMonth = M;
            //        CardExpireYear = Y;
            //} else
            //{
            //    CustomMessageBox.Show("Enter a valid Expire Date", "Enter valid values", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}
            CardExpireMonth = MonthCombo.SelectedIndex;
            CardExpireYear = (int)YearCombo.SelectedValue;

            if (CVCTXT.Text.Length > 0 && int.TryParse(CVCTXT.Text, out int C))
                CVC = CVCTXT?.Text;
            else
            {
                CustomMessageBox.Show("Enter a valid CVC", "Enter valid values", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Payment payment = new Payment()
            //{
            //    CardNumber = Cardnumber,
            //    CardType = (int)CardType,
            //    Foodbill = (double)Caller.FoodPrice + (double)Caller.ServicesPrice,
            //    CurrentBill = (double)Caller.RoomPrice,
            //    PaymentType = (int)PaymentType,
            //    ExpireMonth = CardExpireMonth,
            //    ExpireYear = CardExpireYear,
            //    CardCVC = CVC,
            //    Tax = 0.14*((double)Caller.FoodPrice + (double)Caller.ServicesPrice + (double)Caller.RoomPrice),
            //};

            //Caller.Payment = payment;

            Caller.Payment.CardNumber = Cardnumber;
            Caller.Payment.CardType = (int)CardType;
            Caller.Payment.PaymentType = (int)PaymentType;
            Caller.Payment.ExpireMonth = CardExpireMonth;
            Caller.Payment.ExpireYear = CardExpireYear;
            Caller.Payment.CardCVC = CVC;
            Caller.Payment.Tax = 0.14 * (Caller.Payment.Foodbill + Caller.Payment.CurrentBill);

            //TotalBill = decimal.Parse(Total.Text);

            Visibility = Visibility.Hidden;
        }

        private void VisibleHand(object sender, DependencyPropertyChangedEventArgs e)
        {
            //FoodBill.Text = $"{Caller.FoodPrice}";
            if (DataContext != null)
                //CardTypeTxt.Text = "";
            //else
                CheckType();
            UpdatePaymentFields();
        }


        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CheckType(object sender, KeyEventArgs e)
        {
            CheckType();
        }

    }
}
