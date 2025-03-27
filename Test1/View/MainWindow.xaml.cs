using System.Collections.ObjectModel;
using System.Net.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Test1.Model;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace Test1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Persons> ItemsDataGridView { get; set; }

        public ObservableCollection<string> ListGender { get; set; }
        public Persons SelectedPerson { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ItemsDataGridView = new ObservableCollection<Persons> {
            new Persons
               {
                   Id = 1,
                   userName = "john123",
                   password = "pass123",
                   FName = "John",
                   LName = "Doe",             
                   Gender = "Male",
                   Age = 30,
                   Address = "123 Main St, City A",
                   phoneNumber = "123456789",
                   Email = "john.doe@example.com",
                   DateOfBirth = new DateTime(1994, 5, 12),
                   pathImagePerson = @"C:\Users\lethe\source\repos\Test1\Test1\Image\Linh.jpg"
               },
            new Persons
            {
                Id = 2,
                userName = "jane456",
                password = "pass456",
                FName = "Jane",
                LName = "Smith",
                Gender = "Female",
                Age = 28,
                Address = "456 Maple Rd, City B",
                phoneNumber = "987654321",
                Email = "jane.smith@example.com",
                DateOfBirth = new DateTime(1996, 11, 3),
                pathImagePerson = @"C:\Users\lethe\source\repos\Test1\Test1\Image\Daco_5096993.png"
            },
            new Persons
            {
                Id = 3,
                userName = "alex789",
                password = "pass789",
                FName = "Alex",
                LName = "Johnson",
                Gender = "Orther",
                Age = 25,
                Address = "789 Oak Ave, City C",
                phoneNumber = "555123456",
                Email = "alex.johnson@example.com",
                DateOfBirth = new DateTime(1999, 2, 20),
                pathImagePerson = @"C:\Users\lethe\source\repos\Test1\Test1\Image\Daco_5735318.png"
            }
        };

            ListGender = new ObservableCollection<string>
            {
                "Male","Female","Orther",
            };
            
            this.DataContext = this; 
        }
       
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid_name.SelectedItems != null)
            {
                MessageBoxResult result =  MessageBox.Show("Are you sure you want to delete", "Notation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var item = (Persons)dataGrid_name.SelectedItems;
                    ItemsDataGridView.Remove(item);
                    
                }
            }
            else
            {
                MessageBox.Show("Plesae chosse your id you want to delete","Warning",MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
       
        private void btnShowDataGrid_Click(object sender, RoutedEventArgs e)
        {
           
        
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
         
        }

        private void txtSearchbyName_TextChanged(object sender, TextChangedEventArgs e)
        {
          
            
        }

    }
}