using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCustomMessageBox;
//using Dapper;

namespace HotelManagementSystem
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FrontEnd : Window
    {
        public FoodMenu menu;
        public FinalizePayment FP;
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
        public Payment Payment { get; set; } = new();
        
        public Reservation SelectedReservation { get; set; }

        public FrontEnd()
        {
            InitializeComponent();
            InitializeCities();
            Closed += delegate (object? sender, EventArgs e)
            {
                DB.Dispose();
                FP?.Close();
                menu?.Close();
            };
            LoadReservationAdvertisementGridData();
            LoadRoomAvailability();
        }

        private void RoomNumberMouseEnter(object sender, MouseEventArgs e)
        {
            if (SelectedReservation != null)
            {
                var Rooms = DB.Rooms.IgnoreQueryFilters().Where(R => R.RoomFloor == SelectedReservation.Room.RoomFloor
                                                                    && (R.RoomType == SelectedReservation.Room.RoomType)).ToList();
                if (Rooms != null)
                {
                    RoomNumber.ItemsSource = null;
                    RoomNumber.Items.Clear();
                    RoomNumber.ItemsSource = Rooms;
                    RoomNumber.DisplayMemberPath = "RoomNumber";
                    RoomNumber.SelectedValuePath = "RoomID";
                    RoomNumber.SelectedItem = Rooms.Find(R => R.RoomID == SelectedReservation.Room.RoomID);
                }
                return;
            }
            RoomType? selectedRoomType = (RoomType)RoomTypeCombo?.SelectedIndex;
            if (selectedRoomType != null && Floor != null && Floor.SelectedIndex > 0)
            {
                var Rooms = DB.Rooms.Where(R => R.RoomFloor == Floor.SelectedIndex
                                                                    && (R.RoomType == selectedRoomType)).ToList();
                if (Rooms != null)
                {
                    RoomNumber.ItemsSource = Rooms;
                    RoomNumber.DisplayMemberPath = "RoomNumber";
                    RoomNumber.SelectedValuePath = "RoomID";
                }
            }
            
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

        private void FinalizeBillClick(object sender, RoutedEventArgs e)
        {
            UpdateRoomPrice();
            if (FP != null)
            {
                FP.ShowDialog();
                //if (SelectedReservation != null)
                    //FP.DataContext = SelectedReservation?.Guest?.Payment;
                    FP.DataContext = Payment;
                //else
                    //FP.DataContext = Payment;
                FP.UpdatePaymentFields();
            }

            else
            {
                FP = new(this);
                if (SelectedReservation != null)
                    FP.DataContext = SelectedReservation?.Guest?.Payment;
                else
                    FP.DataContext = Payment;
                FP.ShowDialog();
            }
        }

        private void NewReservationClick(object sender, RoutedEventArgs e)
        {
            Guest newGuest;
            if (!ValidateData(out List<string> Errors))
            {
                CustomMessageBox.Show(string.Join("\n", Errors.ToArray()), "Enter Missing Fields", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                UpdateRoomPrice();
                if((double)RoomPrice != Payment.CurrentBill)
                {
                    FinalizeBillClick(sender, e);
                    return;
                }
                ComboBoxItem CBItm;
                int cityID = (int)City.SelectedValue;
                CBItm = (ComboBoxItem)GenderCombo.SelectedValue;
                Gender gender = Enum.Parse<Gender>((string)CBItm.Content);

                #pragma warning disable CS8602 // Dereference of a possibly null reference.
                DB.Rooms.FirstOrDefault(R=> R.RoomID== (int)RoomNumber.SelectedValue).IsReserved = true;
                #pragma warning restore CS8602 // Dereference of a possibly null reference.

                newGuest = new Guest()
                {
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    Birthday = Convert.ToDateTime(BirthDayPicker.Text),
                    Gender = (int)gender,//(Gender)Gender.SelectedValue,
                    Phone = PhoneNumber.Text,
                    Email = Email.Text,
                    StreetAddress = StreetAddress.Text,
                    ApartmentSuite = int.Parse(Appartment.Text),
                    State = State.Text,
                    City = DB.Cities.FirstOrDefault(c => c.CityID == cityID),
                    ZipCode = Zipcode.Text,
                    Payment = Payment
                };
                Reservation reservation = new Reservation()
                {
                    NumberOfGuests = NoOfGuests.SelectedIndex,
                    Guest = newGuest,
                    Room = DB.Rooms.FirstOrDefault(R => R.RoomID == (int)RoomNumber.SelectedValue),
                    ArrivalTime = Convert.ToDateTime(EntryDate.Text),
                    LeavingTime = Convert.ToDateTime(DepartureDate.Text),
                    CheckedIn = (bool)CheckIn.IsChecked ? true : false,
                    Breakfast = Breakfast,
                    Lunch = Lunch,
                    Dinner = Dinner,
                    Cleaning = Cleaning,
                    Towel = Towels,
                    SSurprise = SweetestSurprise,
                    SupplyStatus = (bool)FoodSupply.IsChecked ? true : false,
                };

                DB.Add(newGuest);
                DB.Add(reservation);
                DB.SaveChanges();
                CustomMessageBox.Show("Reservation added Successfully!", "Success", MessageBoxButton.OK);
                //FrontEnd window = new FrontEnd();
                //Close();
                //window.ShowDialog();
            }
            
        }

        public void UpdateRoomPrice()
        {
            RoomPrice = 0;
            int SelectedRoomTypeIndex = RoomTypeCombo?.SelectedIndex??-1;
            int GuestNum = NoOfGuests?.SelectedIndex != null ? NoOfGuests.SelectedIndex: 0;
            RoomPrice += GuestNum * 15;
            if(SelectedRoomTypeIndex >=0)
            {
                RoomPrice += (SelectedRoomTypeIndex + 1) * 40;
            }
            int floorNum = Floor?.SelectedIndex !=null? Floor.SelectedIndex :0;
            RoomPrice += 5 * floorNum;


           if(DepartureDate!=null && EntryDate!=null)
            {
                if (DepartureDate.Text.Length>0 && EntryDate.Text.Length>0)
                {
                    double No_of_Days = (Convert.ToDateTime(DepartureDate?.Text ??$"{DateTime.Now}") - Convert.ToDateTime(EntryDate?.Text?? $"{DateTime.Now}")).TotalDays;
                    RoomPrice *= (int)No_of_Days;
                }
            }

            Payment.CurrentBill = (double)RoomPrice;

            if (FP != null)
                FP.DataContext = SelectedReservation?.Guest?.Payment;
        }

        private void SelectedReservationToEdit(object sender, SelectionChangedEventArgs e)
        {
            #pragma warning disable CS8601 // Possible null reference assignment.
            if(SelectReservation.SelectedValue!=null)
            {
                SelectedReservation = DB.Reservations.IgnoreQueryFilters()
                .Include(R => R.Guest)
                .Include(R => R.Guest.Payment)
                .Include(R => R.Room)
                .FirstOrDefault(R => R.ReservationID == (int)SelectReservation.SelectedValue);
            }
            #pragma warning restore CS8601 // Possible null reference assignment.

            DataContext = SelectedReservation;
            Payment = SelectedReservation.Guest.Payment;

            if (menu != null)
                menu.DataContext = DataContext;
            if (FP != null)
                FP.DataContext = Payment;

            if(SelectReservation.SelectedValue!=null && SelectedReservation!=null)
            {
                Update.Visibility = Visibility.Visible;
                Delete.Visibility = Visibility.Visible;
            } else
            {
                Update.Visibility = Visibility.Hidden;
                Delete.Visibility = Visibility.Hidden;
            }
            MouseEventArgs? t = null;
            RoomNumberMouseEnter(sender,t);
        }
        public void ChooseRoom(object sender, RoutedEventArgs e)
        {
            if(SelectedReservation != null)
            {
                if (SelectedReservation.Room.Equals((Room)RoomNumber.SelectedItem))
                    return;
            
                if(RoomNumber.SelectedItem != null && RoomNumber.SelectedItem is Room selectedRoom && SelectedReservation!=null)
                {
                    if (selectedRoom != SelectedReservation.Room && selectedRoom.IsReserved == true)
                    {
                        CustomMessageBox.Show("This room is already reserved by another guest", "Room already reserved", MessageBoxButton.OK, MessageBoxImage.Stop);
                        RoomNumber.SelectedItem = SelectedReservation.Room;
                        return;
                    }
                }
            }

        }

        private void UpdateRecordClick(object sender, RoutedEventArgs e)
        {

            if(ValidateData(out List<string> Errors))
            {
                if (RoomNumber.SelectedItem != null && RoomNumber.SelectedItem is Room selectedRoom)
                {
                    
                    if (SelectedReservation.Room.Equals(selectedRoom))
                    {
                        DB.SaveChanges();
                        CustomMessageBox.Show("Reservation Modified Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }
                    if (SelectedReservation.Room != selectedRoom && !selectedRoom.IsReserved)
                    {
                        SelectedReservation.Room.IsReserved = false;
                        selectedRoom.IsReserved = true;
                        SelectedReservation.Room = selectedRoom;
                        SelectedReservation.RoomID = selectedRoom.RoomID;
                        ////DB.Entry(SelectedReservation.Room).State = EntityState.Unchanged;
                        ////DB.Entry(selectedRoom).State = EntityState.Unchanged;
                        //Debug.WriteLine(DB.Entry(SelectedReservation.Room).State);
                        //Debug.WriteLine(DB.Entry(selectedRoom).State);
                        DB.SaveChanges();
                        CustomMessageBox.Show("Reservation Modified Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    } else
                    {
                        CustomMessageBox.Show("Room already reserved!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        RoomNumber.SelectedItem = SelectedReservation.Room;
                        return;
                    }
                }
            } else
            {
                CustomMessageBox.Show(string.Join("\n", Errors.ToArray()), "Enter Missing Fields", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
        }

        private void DeleteReservation(object sender, RoutedEventArgs e)
        {
            if(SelectedReservation!=null)
            {
                MessageBoxResult R = MessageBox.Show("Are you sure you want to delete this reservation?", "Confirmation", MessageBoxButton.YesNo);
                if (R == MessageBoxResult.Yes)
                {
                    DB.Remove(SelectedReservation);
                    SelectedReservation.Room.IsReserved = false;
                    DB.Remove(SelectedReservation.Guest);
                    DB.Remove(SelectedReservation.Guest.Payment);
                    DB.SaveChanges();
                    CustomMessageBox.Show("Reservation Deleted Successfully!", "Success", MessageBoxButton.OK,MessageBoxImage.Exclamation);
                    EditReservationClick(sender, e);
                }
            }
            
        }

        private void EditReservationClick(object sender, RoutedEventArgs e)
        {
            ReservationToEditCombo.Visibility = Visibility.Visible;
            if (ReservationToEditCombo != null)
            {
                var Reservations = DB.Reservations.Include("Guest").Select(R => new
                {
                    DisplayedData = $"{R.ReservationID} | {R.Guest.FirstName} {R.Guest.LastName} | {R.Guest.Payment.CardNumber}",
                    ReservationID = R.ReservationID,
                }).ToList();

                if (Reservations != null)
                {
                    SelectReservation.ItemsSource = Reservations;
                    SelectReservation.SelectedValuePath = "ReservationID";
                    SelectReservation.DisplayMemberPath = "DisplayedData";
                }

            }
        }


        private bool ValidateData(out List<string> Errors)
        {
            Errors = new List<string>();
            if (FirstName.Text?.Length == 0)
                Errors.Add("Enter Firstname");
            if (LastName.Text.Length == 0)
                Errors.Add("Enter Lastname");
            if (!DateTime.TryParse(BirthDayPicker.Text, out DateTime date))
                Errors.Add("Enter Valid Birthday");
            if (PhoneNumber.Text?.Length == 0 || Regex.Matches(PhoneNumber.Text, "^([0-9]*)$").Count == 0)
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
            if (NoOfGuests.SelectedIndex == 0)
                Errors.Add("Enter a valid Number of guests");
            if (Floor.SelectedIndex == 0)
                Errors.Add("Enter a valid Floor");
            if (RoomNumber.SelectedValue == null || (Int32)RoomNumber.SelectedValue == 0)
                Errors.Add("Please Pick a room");
            if (!DateTime.TryParse(EntryDate.Text, out DateTime r) || Convert.ToDateTime(EntryDate.Text) < DateTime.Now)
                Errors.Add("Enter valid Entry date");
            if (!DateTime.TryParse(DepartureDate.Text, out DateTime d) || Convert.ToDateTime(DepartureDate.Text) <= Convert.ToDateTime(EntryDate.Text))
                Errors.Add("Enter valid departure date (Date should be in future)");
            if (!Payment)
                Errors.Add("You should Initialize Payment");
            if (Errors.Count > 0)
                return false;
            return true;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void InitializeCities()
        {
            City.ItemsSource = DB.Cities.ToList();
            City.DisplayMemberPath = "Name";
            City.SelectedValuePath = "CityID";
        }

        private void UpdateRoomPriceEvent(object sender, SelectionChangedEventArgs e)
        {
            UpdateRoomPrice();
        }



        /// SEARCH TAB CODE     ////////////////////
        /// 

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            IDbConnection d = new SqlConnection(ConfigurationManager.ConnectionStrings["FrontendConnection"].ConnectionString);
            var x = d.Query<dynamic>($"SELECT Re.*,G.FirstName,G.LastName,G.Email,R.RoomNumber FROM Reservations Re INNER JOIN Guests G "+
                                $"ON G.GuestID = Re.GuestID INNER JOIN Rooms R "+
                                $"ON R.RoomID = Re.RoomID "+
                                $"WHERE  G.FirstName LIKE '%{SearchTextBox.Text}%' OR  G.LastName LIKE '%{SearchTextBox.Text}%' OR R.roomNumber LIKE '%{SearchTextBox.Text}%'"
                                            
                );

            //var Reservations = /*DB.Reservations.IgnoreQueryFilters().Include(R => R.Guest).Include(R=>R.Room)*/x.Where(
            //R => 
            //R.Guest.FirstName.Contains(SearchTextBox.Text) ||
            //R.Guest.LastName.Contains(SearchTextBox.Text) ||
            //R.Room.RoomNumber.Contains(SearchTextBox.Text)).ToList();

            if (/*Reservations*/x != null/* && *//*Reservations*//*x.Count>0*/)
            {
                SearchGrid.ItemsSource = x.ToList()/*Reservations*/;
                SearchGrid.Visibility= Visibility.Visible;
                noresult.Visibility = Visibility.Hidden;
            }
            else
            {
                SearchGrid.Visibility = Visibility.Hidden;
                noresult.Visibility = Visibility.Visible;
            }
        }


        /// Reservation Advertisement TAB CODE     ////////////////////
        /// 

        private void LoadReservationAdvertisementGridData()
        {
            AllReservationDataGrid.ItemsSource = DB.Reservations.IgnoreQueryFilters().Include(R => R.Room).Include(R => R.Guest).ToList();
        }


        /// Room Availability TAB CODE     ////////////////////

        private void LoadRoomAvailability()
        {
            IDbConnection d = new SqlConnection(ConfigurationManager.ConnectionStrings["FrontendConnection"].ConnectionString);
            //DB.Rooms.IgnoreQueryFilters().Load();
            var AvailableRooms = /*DB.Rooms.Local.Where(R => !R.IsReserved).ToList();*/ d.Query<Room>("Select * from Rooms where isreserved=0");
            var UnavailableRooms =/* DB.Rooms.Local.Where(R => R.IsReserved).ToList();*/d.Query<Room>("Select * from Rooms where isreserved=1");
            ReservedGrid.ItemsSource = UnavailableRooms;
            Free.ItemsSource = AvailableRooms;
        }




    }



}
