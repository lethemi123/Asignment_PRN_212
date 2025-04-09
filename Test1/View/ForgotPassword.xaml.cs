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
using Test1.Models;

namespace Test1
{
    /// <summary>
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Window
    {

        Prn212AsignmentContext context = new Prn212AsignmentContext();

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void txtForgotPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BackLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btnCheckEmal_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            var user = context.People.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                CurrentPassword currentPW = new CurrentPassword();
                currentPW.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Email not exits in database. Please try again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
