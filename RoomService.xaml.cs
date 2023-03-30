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
        public RoomService()
        {
            InitializeComponent();
            List<Employee> list1 = new List<Employee>() {
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                new(){ID=4,Name="Mazen Salah",Age=13},
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                new(){ID=4,Name="Mazen Salah",Age=13},
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                new(){ID=4,Name="Mazen Salah",Age=13},
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                 new(){ID=4,Name="Mazen Salah",Age=13},
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                new(){ID=4,Name="Mazen Salah",Age=13},
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                new(){ID=4,Name="Mazen Salah",Age=13},
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                 new(){ID=4,Name="Mazen Salah",Age=13},
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                new(){ID=4,Name="Mazen Salah",Age=13},
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                new(){ID=4,Name="Mazen Salah",Age=13},
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                 new(){ID=4,Name="Mazen Salah",Age=13},
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                new(){ID=4,Name="Mazen Salah",Age=13},
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                new(){ID=4,Name="Mazen Salah",Age=13},
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                 new(){ID=4,Name="Mazen Salah",Age=13},
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                new(){ID=4,Name="Mazen Salah",Age=13},
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                new(){ID=4,Name="Mazen Salah",Age=13},
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                new(){ID=4,Name="Mazen Salah",Age=13}
            };
            OnTheLine.ItemsSource = list1;
            OnTheLine.DisplayMemberPath = "Name";
            OverviewGrid.ItemsSource = list1;
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
