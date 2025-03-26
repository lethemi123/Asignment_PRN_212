using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Test1.Model;

namespace Test1.Manage
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {      
        public ObservableCollection<Persons> Items1 { get; set; }
        public ObservableCollection<Categories> Items2 { get; set; }
        public ObservableCollection<Products> ItemDataGridProducts { get; set; }

        public Admin()
        {
            InitializeComponent();
            Window window = Window.GetWindow(this);
            window.WindowState = WindowState.Normal;
            Items2 = new ObservableCollection<Categories> { new Categories { CategoryID = "1", CategoryName = " Computer" } };
            ItemDataGridProducts = new ObservableCollection<Products>
        {
            new Products{ProductId = "1", ProductName = "CX2 Computer", Price = 120000, ProductDescription = "this is computer doing gaming", IsSelected = false, Stock = 100, CateGoryID = "Computer", ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Linh.jpg" }
        };
            Items1 = new ObservableCollection<Persons>
        {
            new Persons{Id = 1, userName="lethemi", FName ="Le " ,LName = "My", Age = 18 , Gender = "Male", Address ="Vinh Tuong - Vinh Phuc",phoneNumber = "0787459334",Email= "lethemi436@gmail.com", IsSelected = false }
        };
            DataContext = this;
        }

        private void txtFullName_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void rdoMale_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnChoosePicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();  
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                ProfileImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }   
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void ControlBarUC_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void HeaderCheckbox_Click(object sender, RoutedEventArgs e)
        {
            bool iMax = (HeaderCheckbox.IsChecked == true);
            foreach(var item in ItemDataGridProducts)
            {
                item.IsSelected = iMax;
            }
            DataGridProduct.Items.Refresh();
        }

        private void HeaderCheckAccount_Click(object sender, RoutedEventArgs e)
        {
            bool checkBoxAccount = (HeaderCheckbox.IsChecked == true);
            foreach(var item in Items1)
            {
                item.IsSelected = checkBoxAccount;
            }
            DataGridAccount.Items.Refresh();
        }
    }
}
