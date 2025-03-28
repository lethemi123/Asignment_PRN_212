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
using Test1.Manage;
using Test1.Models;

namespace Test1
{

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Prn212AsignmentContext context = new Prn212AsignmentContext();
       
        public Login()
        {
            InitializeComponent();
        }

        private void ForgotPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Password;

            var user = context.People.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user != null) {
                if (user.RoleAccount == true)
                {
                    Admin admin = new Admin();
                    admin.Show();
                    this.Close();
                }
                else
                {
                    Customer customer = new Customer();
                    customer.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Wrong", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

            

        

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
