using AutoFilterWpfDataGridDemo.Models;
using System.Data;
using System.Windows;

namespace AutoFilterWpfDataGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // NOTE: This demo runs in FREE MODE (1 filter at a time).
        // To unlock unlimited filters, add your license key below.
        public MainWindow()
        {
            InitializeComponent();

            MyAutoFilterWpfDataGrid.LicenseKey = "YOUR LICENSE KEY HERE";

            //--PropertyHeaderMapList--------------------------------------------------------------------------------------------------------------------------------
            //By default headers will be generated based on property name. So "DateOfBirth" will be displayed as "Date of birth" 
            //but You may want to use custom headers for your properties:
            var propertyHeaderMapList = new List<AutoFilterWpfDataGrid.PropertyHeaderMap>();
            propertyHeaderMapList.Add(new AutoFilterWpfDataGrid.PropertyHeaderMap("Name", "First Name")); // 'Name' property will be displyed as 'First Name'
            propertyHeaderMapList.Add(new AutoFilterWpfDataGrid.PropertyHeaderMap("DateOfBirth", "D.O.B")); // 'DateOfBirth' property will be displyed as 'D.O.B'
            propertyHeaderMapList.Add(new AutoFilterWpfDataGrid.PropertyHeaderMap("Nationality", "Country of origin")); // 'Nationality' property will be displyed as 'Country of origin'
            //Un-comment to apply:
            //MyAutoFilterWpfDataGrid.PropertyHeaderMapList = propertyHeaderMapList;


            //--ShowSumInHeadersPropertyList------------------------------------------------------------------------------------------------------------------------
            //By default all numeric types will have sum (∑) in headers. You can overwrite this if you only want to show sum (∑) only in your desired columns:
            var showSumInHeadersPropertyList = new List<string>();
            showSumInHeadersPropertyList.Add("NetIncome"); // 'NetIncome' column will have sum (∑) in header. Other numberis columns will not have sum (∑). Add more if you wish
            //Un-comment to apply:
            //MyAutoFilterWpfDataGrid.ShowSumInHeadersPropertyList = showSumInHeadersPropertyList;


            //--ShowSumsInHeaders------------------------------------------------------------------------------------------------------------------------------------
            //You can disable showing sum (∑) entirely:
            //Un-comment to apply:
            //MyAutoFilterWpfDataGrid.ShowSumsInHeaders = false;


            //--ShowNoValueFilterCheckBox----------------------------------------------------------------------------------------------------------------------------
            //If you do not wish to show 'No value' checkbox filter for nullable types, set to false:
            //Un-comment to apply:
            //MyAutoFilterWpfDataGrid.ShowNoValueFilterCheckBox = false;


            //--FilteredColumnHeaderBackground------------------------------------------------------------------------------------------------------------------------
            //Set your desired column header background where filter is applied:
            //Un-comment to apply:
            //MyAutoFilterWpfDataGrid.FilteredColumnHeaderBackground = Brushes.Red;
        }

        private void MyAutoFilterWpfDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //Set your ItemsSource. AutoFilterWpfDataGrid will generate filters for supported types
            MyAutoFilterWpfDataGrid.ItemsSource = GetPersons();

            //For comparisson with regular DataGrid:
            RegularDataGrid.ItemsSource = MyAutoFilterWpfDataGrid.ItemsSource;
        }

        private List<Person> GetPersons()
        {
            var persons = new List<Person>();

            persons.Add(new Person()
            {
                Name = "John",
                LastName = "Steward",
                DateOfBirth = new DateTime(1984, 3, 10),
                IsMarried = true,
                MarriedDate = new DateTime(2010, 1, 10).AddHours(12).AddMinutes(30),
                Nationality = Nationality.American,
                Height = 170.5,
                ShoeSize = 42,
                NetIncome = 3600.123m,
                WakeUpTime = TimeSpan.FromMinutes(530),
                UniqueGuidId = Guid.NewGuid()
            });

            persons.Add(new Person()
            {
                Name = "Silvia",
                LastName = "Gonzalez",
                DateOfBirth = new DateTime(1990, 3, 15),
                Nationality = Nationality.Mexican,
                Height = 160.5,
                ShoeSize = 39,
                NetIncome = 2650.123m,
                WakeUpTime = TimeSpan.FromMinutes(415),
                UniqueGuidId = Guid.NewGuid()
            });

            persons.Add(new Person()
            {
                Name = "Annika",
                LastName = "Roos",
                DateOfBirth = new DateTime(1990, 3, 15),
                Nationality = Nationality.Estonian,
                Height = 166.5,
                ShoeSize = 37,
                IsMarried = false,
                NetIncome = 2760.423m,
                WakeUpTime = TimeSpan.FromMinutes(635),
                UniqueGuidId = Guid.NewGuid()
            });

            persons.Add(new Person()
            {
                Name = "John",
                LastName = "Doe",
                Nationality = Nationality.Other,
                Height = 181.8,
                ShoeSize = 44,
                UniqueGuidId = Guid.NewGuid()
            });

            persons.Add(new Person()
            {
                Name = "Jaquin",
                LastName = "Delavega",
                DateOfBirth = new DateTime(1995, 7, 8),
                Nationality = Nationality.Spanish,
                ShoeSize = 45,
                NetIncome = 4550,
                IsMarried = true,
                MarriedDate = new DateTime(2026, 2, 25).AddHours(10).AddMinutes(45),
                UniqueGuidId = Guid.NewGuid(),
                WakeUpTime = TimeSpan.FromMinutes(765),
            });

            persons.Add(new Person()
            {
                Name = "James",
                LastName = "Gammel",
                DateOfBirth = new DateTime(1992, 3, 8),
                Nationality = Nationality.American,
                Height = 162.8,
                IsMarried = false,
                NetIncome = 321.777m,
                UniqueGuidId = Guid.NewGuid(),
                WakeUpTime = TimeSpan.FromMinutes(915),
            });

            persons.Add(new Person()
            {
                Name = "Unidentified",
                LastName = ""
            });

            persons.Add(new Person()
            {
                Name = "Jenifer",
                LastName = "Walker",
                DateOfBirth = new DateTime(1998, 3, 9),
                Nationality = Nationality.American,
                Height = 167.5,
                ShoeSize = 36,
                IsMarried = true,
                NetIncome = 6533,
                MarriedDate = new DateTime(2025, 4, 5).AddHours(13).AddMinutes(15),
                UniqueGuidId = Guid.NewGuid(),
                WakeUpTime = TimeSpan.FromMinutes(900),
            });

            return persons;
        }
        private void MyAutoFilterWpfDataGrid_FiltersChanged(object sender, RoutedEventArgs e)
        {
            //You may want to use this event to reload data based on entered filters or whatever reason. You can access the filters via 'Filters' property:

            //Examples:
            var namePropertyFilter = MyAutoFilterWpfDataGrid.Filters.Where(filter => filter.PropertyName == "Name").Select(filter => filter.StringValue).FirstOrDefault();
            var uniqueGuidIdPropertyFilter = MyAutoFilterWpfDataGrid.Filters.Where(filter => filter.PropertyName == "UniqueGuidId").Select(filter => filter.StringValue).FirstOrDefault();
            var dateOfBirthPropertyFilter_From = MyAutoFilterWpfDataGrid.Filters.Where(filter => filter.PropertyName == "DateOfBirth").Select(filter => filter.DateTimeFromValue).FirstOrDefault();
            var dateOfBirthPropertyFilter_To = MyAutoFilterWpfDataGrid.Filters.Where(filter => filter.PropertyName == "DateOfBirth").Select(filter => filter.DateTimeFromValue).FirstOrDefault();

            //etc.
        }
    }
}