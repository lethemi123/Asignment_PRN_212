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
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {
        public ObservableCollection<Products> ListProducts { get; set; }
        public ObservableCollection<Products> DatagridViewOrder { get; set; }
        public Customer()
        {
            InitializeComponent();
            

            DatagridViewOrder = new ObservableCollection<Products>
            {
                new Products {ProductId = "SC1",ProductName = "Computer Acer",CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 5000,ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg" },
                new Products {ProductId = "SC2",ProductName = "Computer A", CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 6000, ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg" },
                new Products {ProductId = "SC3",ProductName = "Computer B",CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 2000, ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                new Products {ProductId = "SC4",ProductName = "Computer C", Price = 3000,CateGoryID = "Acer", ProductDescription = "Computer screen", ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                new Products {ProductId = "SC5",ProductName = "Computer E", Price = 1000,CateGoryID = "Acer", ProductDescription = "Computer screen", ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"}
            };
            ListProducts = new ObservableCollection<Products>
            {
                new Products {ProductId = "SC1",ProductName = "Computer Acer",CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 5000,ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg" },
                new Products {ProductId = "SC2",ProductName = "Computer A", CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 6000, ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg" },
                new Products {ProductId = "SC3",ProductName = "Computer B",CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 2000, ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                new Products {ProductId = "SC4",ProductName = "Computer C", Price = 3000,CateGoryID = "Acer", ProductDescription = "Computer screen", ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                new Products {ProductId = "SC5",ProductName = "Computer E", Price = 1000,CateGoryID = "Acer", ProductDescription = "Computer screen", ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                 new Products {ProductId = "SC1",ProductName = "Computer Acer",CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 5000,ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg" },
                new Products {ProductId = "SC2",ProductName = "Computer A", CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 6000, ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg" },
                new Products {ProductId = "SC3",ProductName = "Computer B",CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 2000, ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                new Products {ProductId = "SC4",ProductName = "Computer C", Price = 3000,CateGoryID = "Acer", ProductDescription = "Computer screen", ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                new Products {ProductId = "SC5",ProductName = "Computer E", Price = 1000,CateGoryID = "Acer", ProductDescription = "Computer screen", ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                 new Products {ProductId = "SC1",ProductName = "Computer Acer",CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 5000,ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg" },
                new Products {ProductId = "SC2",ProductName = "Computer A", CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 6000, ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg" },
                new Products {ProductId = "SC3",ProductName = "Computer B",CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 2000, ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                new Products {ProductId = "SC4",ProductName = "Computer C", Price = 3000,CateGoryID = "Acer", ProductDescription = "Computer screen", ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                new Products {ProductId = "SC5",ProductName = "Computer E", Price = 1000,CateGoryID = "Acer", ProductDescription = "Computer screen", ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                 new Products {ProductId = "SC1",ProductName = "Computer Acer",CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 5000,ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg" },
                new Products {ProductId = "SC2",ProductName = "Computer A", CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 6000, ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg" },
                new Products {ProductId = "SC3",ProductName = "Computer B",CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 2000, ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                new Products {ProductId = "SC4",ProductName = "Computer C", Price = 3000,CateGoryID = "Acer", ProductDescription = "Computer screen", ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                new Products {ProductId = "SC5",ProductName = "Computer E", Price = 1000,CateGoryID = "Acer", ProductDescription = "Computer screen", ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                 new Products {ProductId = "SC1",ProductName = "Computer Acer",CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 5000,ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg" },
                new Products {ProductId = "SC2",ProductName = "Computer A", CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 6000, ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg" },
                new Products {ProductId = "SC3",ProductName = "Computer B",CateGoryID = "Acer", ProductDescription = "Computer screen", Price = 2000, ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                new Products {ProductId = "SC4",ProductName = "Computer C", Price = 3000,CateGoryID = "Acer", ProductDescription = "Computer screen", ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"},
                new Products {ProductId = "SC5",ProductName = "Computer E", Price = 1000,CateGoryID = "Acer", ProductDescription = "Computer screen", ImangePathProduct = "C:\\Users\\lethe\\source\\repos\\Test1\\Test1\\Image\\Karma is a Cat.jpg"}
            };



            this.DataContext = this;
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
            bool newState = (HeaderCheckbox.IsChecked == true);
            foreach(var item in DatagridViewOrder)
            {
                item.IsSelected = newState;
            }
            DataGridOrder.Items.Refresh();
            
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
    }
}
