using HotelManagementSystem.Context;
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

    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public partial class FrontEnd : Window
    {
        FrontendDB DB = new FrontendDB();
        public FrontEnd()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeAll();
            
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
            NoOfGuests.ItemsSource = Enumerable.Range(1, 15).ToList();
            List<Employee> list1 = new List<Employee>() {
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                new(){ID=4,Name="Mazen Salah",Age=13}
            };
            List<Employee> list2 = new List<Employee>() {
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                new(){ID=4,Name="Mazen Salah",Age=13}
            };
            List<Employee> list3 = new List<Employee>() {
                new(){ID=1,Name="Mohamed Salah",Age=26},
                new(){ID=2,Name="Omar Salah",Age=23},
                new(){ID=3,Name="Mahmoud Salah",Age=19},
                new(){ID=4,Name="Mazen Salah",Age=13}
            };
            ResGrid.ItemsSource = list1;
            OccupiedGrid.ItemsSource = list2;
            ReservedGrid.ItemsSource = list3;

        }

        private void InitializeComboBox()
        {
            int Days = 0;
            ComboBoxItem selectedItem = (ComboBoxItem)BirthMonth?.SelectedItem;
            if(Enum.TryParse<Months>(selectedItem?.Content?.ToString(), out Months M))
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
            if(Days>0)
            {
                BirthDay?.Items.Clear();
                for(int i=1;i<=Days;i++)
                {
                    ComboBoxItem item = new();
                    item.Content = i;
                    BirthDay?.Items.Add(i);
                }
            }
        }

        private void MonthComboChange(object sender, SelectionChangedEventArgs e)
        {
            InitializeComboBox();
        }

        private void FoodMenuClick(object sender, RoutedEventArgs e)
        {
            FoodMenu foodMenu = new FoodMenu();
            foodMenu.ShowDialog();
        }
    }
}
