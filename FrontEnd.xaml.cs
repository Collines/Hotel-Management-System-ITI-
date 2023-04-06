using HotelManagementSystem.Context;
using HotelManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
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

    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public partial class FrontEnd : Window
    {
        FoodMenu menu;
        FinalizePayment FP;
        FrontendDB DB = new FrontendDB();
        //
        public decimal FoodPrice { get; set; } = 0;
        public decimal ServicesPrice { get; set; } = 0;
        public decimal RoomPrice { get; set; } = 0;
        public int Breakfast { get; set; } = 0;
        public int Lunch { get; set; } = 0;
        public int Dinner { get; set; } = 0;
        public bool Cleaning { get; set; } = false;
        public bool Towels { get; set; } = false;
        public bool SweetestSurprise { get; set; } = false;
        public Payment payment { get; set; }

        public FrontEnd()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeAll();
            Closed += delegate (object? sender, EventArgs e)
            {
                DB.Dispose();
                FP?.Close();
                menu?.Close();
            };
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void InitializeAll()
        {
            InitializeComboBox();
            City.ItemsSource = DB.Cities.ToList();
            City.DisplayMemberPath = "Name";
            City.SelectedValuePath = "CityID";
            FillComboWithNumbers(NoOfGuests, 1, 10);
            FillComboWithNumbers(Floor, 1, 15);
            ComboBoxItem selectedFloor = (ComboBoxItem)Floor.SelectedValue;
            ComboBoxItem selectedRoomType = (ComboBoxItem)RoomTypeCombo.SelectedValue;
            RoomType RT = Enum.Parse<RoomType>((string)selectedRoomType.Content);
            RoomNumber.ItemsSource = DB.Rooms.Where(R => R.RoomFloor == (int)selectedFloor.Content
                                                                    && (R.RoomType == RT)).ToList();
            RoomNumber.DisplayMemberPath = "RoomNumber";
            RoomNumber.SelectedValuePath = "RoomID";
            SelectReservation.ItemsSource = DB.Reservations.Include("Guest").Select(R => new
            {
                DisplayedData = $"{R.ReservationID} | {R.Guest.FirstName} {R.Guest.LastName}",
                ReservationID = R.ReservationID
            }).ToList();
            SelectReservation.SelectedValuePath = "ReservationID";
            SelectReservation.DisplayMemberPath = "DisplayedData";
        }

        private void InitializeComboBox()
        {
            int Days = 0;
            ComboBoxItem selectedItem = (ComboBoxItem)BirthMonth?.SelectedItem;
            if (Enum.TryParse<Months>(selectedItem?.Content?.ToString(), out Months M))
            {
                switch (M)
                {
                    case Months.January:
                        Days = 30;
                        break;
                    case Months.February:
                        Days = 29;
                        break;
                    case Months.March:
                        Days = 31;
                        break;
                    case Months.April:
                        Days = 30;
                        break;
                    case Months.May:
                        Days = 31;
                        break;
                    case Months.June:
                        Days = 30;
                        break;
                    case Months.July:
                        Days = 31;
                        break;
                    case Months.August:
                        Days = 31;
                        break;
                    case Months.September:
                        Days = 30;
                        break;
                    case Months.October:
                        Days = 31;
                        break;
                    case Months.November:
                        Days = 30;
                        break;
                    case Months.December:
                        Days = 31;
                        break;
                    default:
                        Days = 30;
                        break;
                }

            }
            if (Days > 0)
            {
                BirthDayCombo?.Items.Clear();
                FillComboWithNumbers(BirthDayCombo, 1, Days);
            }
        }

        private void MonthComboChange(object sender, SelectionChangedEventArgs e)
        {
            InitializeComboBox();
        }

        private void FoodMenuClick(object sender, RoutedEventArgs e)
        {
            if (menu != null)
                menu.ShowDialog();
            else
            {
                menu = new FoodMenu(this);
                menu.ShowDialog();
            }
        }

        private void FinlizeBillClick(object sender, RoutedEventArgs e)
        {
            if (FP != null)
            {
                FP.ShowDialog();
                FP.UpdatePaymentFields();
            }

            else
            {
                FP = new(this);
                FP.ShowDialog();

            }
        }

        private void NewReservationClick(object sender, RoutedEventArgs e)
        {


            Guest newGuest;
            List<string> Errors = new List<string>();

            // Gather Guest data with validation
            if (FirstName.Text?.Length == 0)
                Errors.Add("Enter Firstname");
            if (LastName.Text.Length == 0)
                Errors.Add("Enter Lastname");
            if (!int.TryParse(BirthYear.Text, out int year))
                Errors.Add("Enter Birth Year");
            if (PhoneNumber.Text?.Length == 0 || Regex.Matches(PhoneNumber.Text, "^([0-9]*)$").Count ==0)
                Errors.Add("Enter a valid Phone number");
            if (Email.Text?.Length == 0 || Regex.Matches(Email.Text, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$").Count == 0)
                Errors.Add("Enter a valid Email address");
            if (StreetAddress.Text?.Length == 0)
                Errors.Add("Enter your address");
            if (Appartment.Text?.Length == 0 || Regex.Matches(Appartment.Text, "^(0|[1-9][0-9]*)$").Count == 0)
                Errors.Add("Enter your appartment");
            if (State.Text?.Length == 0)
                Errors.Add("Enter your state");
            if (Zipcode.Text?.Length == 0 || Regex.Matches(Zipcode.Text, "^(0|[1-9][0-9]*)$").Count == 0)
                Errors.Add("Enter your Zipcode");
            if (City.SelectedValue == null || (Int32)City.SelectedValue == 0)
                Errors.Add("Enter your city");

            if (Errors.Count > 0)
            {
                CustomMessageBox.Show(string.Join("\n", Errors.ToArray()), "Enter Missing Fields", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                ComboBoxItem CBItm = (ComboBoxItem)BirthMonth.SelectedValue;
                Months Month = Enum.Parse<Months>((string)CBItm.Content);
                int MonthID =(int)Month;
                CBItm = (ComboBoxItem)BirthDayCombo.SelectedValue;
                int bday = (int)CBItm.Content;
                int cityID = (int)City.SelectedValue;
                CBItm = (ComboBoxItem)Gender.SelectedValue;
                newGuest = new Guest()
                {
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    Birthday = new DateTime(int.Parse(BirthYear.Text), MonthID, bday),
                    Gender = Enum.Parse<Gender>((string)CBItm.Content),//(Gender)Gender.SelectedValue,
                    Phone = PhoneNumber.Text,
                    Email = Email.Text,
                    StreetAddress = StreetAddress.Text,
                    ApartmentSuite = int.Parse(Appartment.Text),
                    State = State.Text,
                    City = DB.Cities.FirstOrDefault(c => c.CityID == cityID),
                    ZipCode = Zipcode.Text
                };
            }
            //
            if (RoomNumber.SelectedValue == null || (Int32)RoomNumber.SelectedValue == 0)
                Errors.Add("Please Pick a room");
            if (!DateTime.TryParse(EntryDate.Text, out DateTime r) || Convert.ToDateTime(EntryDate.Text) < DateTime.Now)
                Errors.Add("Enter valid Entry date");
            if (!DateTime.TryParse(DepartureDate.Text, out DateTime d) || Convert.ToDateTime(DepartureDate.Text) <= Convert.ToDateTime(EntryDate.Text))
                Errors.Add("Enter valid departure date (Date should be in future)");

            if(Errors.Count > 0)
            {
                CustomMessageBox.Show(string.Join("\n", Errors.ToArray()), "Enter Missing Fields", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else
            {
                Reservation reservation = new Reservation()
                {
                    NumberOfGuests = NoOfGuests.SelectedIndex + 1,
                    Guest = newGuest,
                    Room = DB.Rooms.Find(RoomNumber.SelectedValue),
                    ArrivalTime = Convert.ToDateTime(EntryDate.Text),
                    LeavingTime = Convert.ToDateTime(DepartureDate.Text),
                    CheckedIn = (bool)CheckIn.IsChecked ? true : false,
                    Breakfast= Breakfast,
                    Lunch= Lunch,
                    Dinner = Dinner,
                    Cleaning = Cleaning,
                    Towel = Towels,
                    SSurprise = SweetestSurprise,
                    SupplyStatus = (bool)FoodSupply.IsChecked ? true : false,
                };
                DB.Rooms.Find(RoomNumber.SelectedValue).IsReserved = true;
                Payment payment = new Payment()
                {
                    PaymentType = FP.PaymentType,
                    CardNumber = FP.Cardnumber,
                    CardType = FP.CardType,
                    CardCVC = FP.CVC,
                    ExpireMonth = FP.CardExpireMonth,
                    ExpireYear = FP.CardExpireYear,
                    Guest = newGuest,
                    TotalBill = (double)FP.TotalBill
                };

                DB.Add(newGuest);
                DB.Add(reservation);
                DB.Add(payment);
                DB.SaveChanges();
                //DB.Add(reservation);
                CustomMessageBox.Show("Reservation added Successfully!", "Success", MessageBoxButton.OK);

            }
        }

        private void FillComboWithNumbers(ComboBox comboBox, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                ComboBoxItem item = new() { Content = i };
                if (i == 1)
                    item.IsSelected = true;

                comboBox?.Items.Add(item);
            }
        }

        private void RoomPriceEvent(object sender, SelectionChangedEventArgs e)
        {
            UpdateRoomPrice();
        }

        private void FloorRoomTypeChange(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedRoomType= (ComboBoxItem)RoomTypeCombo?.SelectedValue??new();
            RoomType RT;
            //if (selectedRoomType.Content != null)
            string selectedRoomTypeString = selectedRoomType.Content != null ? (string)selectedRoomType.Content : "Single";
            RT = Enum.Parse<RoomType>(selectedRoomTypeString);

            if(Floor!=null)
            {
                if (Floor.SelectedValue is ComboBoxItem selectedFloor /*&& RoomTypeCombo.SelectedValue is ComboBoxItem selectedRoomType*/)
                {

                    RoomNumber.ItemsSource = DB.Rooms.Where(R => R.RoomFloor == (int)selectedFloor.Content
                                                            && (R.RoomType == RT)).ToList();
                }
            }
            
            RoomPriceEvent(sender, e);
        }

        public void UpdateRoomPrice()
        {
            RoomPrice = 0;
            ComboBoxItem selectedRoomType = (ComboBoxItem)RoomTypeCombo.SelectedValue;
            int GuestNum = NoOfGuests?.SelectedIndex != null ? NoOfGuests.SelectedIndex + 1 : 0;
            RoomPrice += GuestNum * 15;
            if(selectedRoomType != null && selectedRoomType.Content !=null)
            {
                RoomType RT = Enum.Parse<RoomType>((string)selectedRoomType.Content);
                RoomPrice += (int)RT * 40;
            }
            int floorNum = Floor?.SelectedIndex !=null? Floor.SelectedIndex + 1:0;
            RoomPrice += 5 * floorNum;


           if(DepartureDate!=null && EntryDate!=null)
            {
                if (DepartureDate.Text.Length>0 && EntryDate.Text.Length>0)
                {
                    double No_of_Days = (Convert.ToDateTime(DepartureDate?.Text ??$"{DateTime.Now}") - Convert.ToDateTime(EntryDate?.Text?? $"{DateTime.Now}")).TotalDays;
                    RoomPrice *= (int)No_of_Days;

                }
            }
            Debug.WriteLine(RoomPrice);
        }

    }



}
