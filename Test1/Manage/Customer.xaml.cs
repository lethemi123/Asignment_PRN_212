using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using Test1.View;
using Test1.Models;
using System.IO;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace Test1.Manage
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    

    public partial class Customer : Window
    {
        public ObservableCollection<Product> ListProducts { get; set; }
        private Person currentUser;
        public ObservableCollection<Category> ListCategory { get; set; }
        private readonly Prn212AsignmentContext context;

        public Customer(Person user)
        {
            InitializeComponent();
            context = new Prn212AsignmentContext();

            currentUser = user;
            // Gán dữ liệu từ user vào UI
            txtUserName.Text = user.UserName;
            txtEmail.Text = user.Email;
            txtPhoneNumber.Text = user.PhoneNumber;

            txtRoleAccount.Text = user.RoleAccount == true ? "Admin" : "User";

            // Giới tính
            if (user.Gender == "Male")
                rdoMale.IsChecked = true;
            else if (user.Gender == "Female")
                rdoFeMale.IsChecked = true;
            else
                rdoOther.IsChecked = true;

            // Họ và tên
            txtFullName.Text = $"{user.Lname} {user.Fname}";

            // Ngày sinh
            if (user.DateOfBirth.HasValue)
                dpBirthday.SelectedDate = user.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue);

          
            txtTotalMoneyUser.Text = user.Balance?.ToString("N0"); 

            
            if (!string.IsNullOrEmpty(user.PathImagePerson) && File.Exists(user.PathImagePerson))
            {
                ProfileImage.Source = new BitmapImage(new Uri(user.PathImagePerson));
            }
            LoadProduct();
            this.DataContext = this;
        }

        private void LoadProduct()
        {
            ListProducts = new ObservableCollection<Product>(
       context.Products.Include(p => p.Category).ToList()
   );

        }
        private void LoadCateGrories()
        {
            ListCategory = new ObservableCollection<Category>(context.Categories.ToList());
            foreach (var cate in ListCategory)
            {
                Console.WriteLine($"Loaded: {cate.CategoryName}");
            }
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
           
            
        }

        private void btnChoosePicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                ProfileImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                currentUser.PathImagePerson = openFileDialog.FileName;
            }

        }

        private void btnNaptien_Click(object sender, RoutedEventArgs e)
        {
            CreaditCard creaditCard = new CreaditCard();
            creaditCard.Show();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        { 
        
        
        
        }

        private void btnSaveProFile_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser != null)
            {
                currentUser.UserName = txtUserName.Text;
                txtFullName.Text = currentUser.Fname + currentUser.Lname;
                currentUser.Email = txtEmail.Text;
                currentUser.PhoneNumber = txtPhoneNumber.Text;
                if (rdoMale.IsChecked == true)
                    currentUser.Gender = "Male";
                else if (rdoFeMale.IsChecked == true)
                    currentUser.Gender = "Female";
                else
                    currentUser.Gender = "Other";
                if (dpBirthday.SelectedDate.HasValue)
                {
                    currentUser.DateOfBirth = DateOnly.FromDateTime(dpBirthday.SelectedDate.Value);
                }
                context.People.Update(currentUser);
                context.SaveChanges();
                MessageBox.Show("Information saved!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
