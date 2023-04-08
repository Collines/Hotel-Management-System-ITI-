using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class RoomService : Window
    {
        FrontendDB DB = new FrontendDB();
        Reservation SelectedReservation;
        public RoomService()
        {
            InitializeComponent();
            Closed += (sender, e) => DB.Dispose();
            //ListBoxReservations.ItemsSource = DB.Reservations.IgnoreQueryFilters().Include(R=>R.Guest).Include(R=>R.Room).ToList();
            ListBoxReservations.ItemsSource = DB.Reservations.IgnoreQueryFilters().Include(R=>R.Guest).Include(R=>R.Room).Select(R=> new
            {
                DisplayedData = $"{R.ReservationID} | {R.Room.RoomNumber} | {R.Guest.FirstName} {R.Guest.LastName} | {R.Guest.Payment.CardNumber}",
                ReservationID = R.ReservationID
            }).ToList();
            ListBoxReservations.DisplayMemberPath = "DisplayedData";
            ListBoxReservations.SelectedValuePath = "ReservationID";
        }

        private void SelectionChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            SelectedReservation = DB.Reservations.IgnoreQueryFilters().Include(R=>R.Room).Include(R=>R.Guest).Include(R=>R.Guest.Payment).FirstOrDefault(R=>R.ReservationID==(int)ListBoxReservations.SelectedValue);
            DataContext = SelectedReservation;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        
    }
}
