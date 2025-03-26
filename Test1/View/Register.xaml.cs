using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;

namespace Test1
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PasswordBox passwordBox = sender as System.Windows.Controls.PasswordBox;
            string password = passwordBox.Password.Trim();

            if (string.IsNullOrEmpty(password))
            {
                passwordBox.SetValue(MaterialDesignThemes.Wpf.HintAssist.HelperTextProperty, "Password is Empty");
                passwordBox.SetResourceReference(MaterialDesignThemes.Wpf.HintAssist.HelperTextStyleProperty, "HelperTextStyleOverride");
            }
            else
            {
                string message = strengCheckPassword(password);
                passwordBox.SetValue(MaterialDesignThemes.Wpf.HintAssist.HelperTextProperty, message);

                if (message == "Strong password")
                {
                    passwordBox.SetResourceReference(MaterialDesignThemes.Wpf.HintAssist.HelperTextStyleProperty, "HHelperTextStyleMatch");
                }
                else
                {
                    passwordBox.SetResourceReference(MaterialDesignThemes.Wpf.HintAssist.HelperTextStyleProperty, "HelperTextStyleOverride");
                }
            }
        }


        private string strengCheckPassword(string password)
        {
            if (password.Length < 8) return "Must be at least 8 characters.";
            if (!Regex.IsMatch(password, @"[A-Z]")) return "Must have uppercase letter.";
            if (!Regex.IsMatch(password, @"[a-z]")) return "Must have a lowercase letter.";
            if (!Regex.IsMatch(password, @"[0-9]")) return "Must have a number.";
            if (!Regex.IsMatch(password, @"[\W_]")) return "Must have a special character.";
            return "Strong password";
        }



        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
             string email = txtEmail.Text.Trim();
            string formEmail = @"^[a-zA-Z0-9]+@gmail\.com$";
            if (string.IsNullOrEmpty(email))
            {
                txtEmail.SetValue(MaterialDesignThemes.Wpf.HintAssist.HelperTextProperty, "Email is Empty");
                txtEmail.SetResourceReference(MaterialDesignThemes.Wpf.HintAssist.HelperTextStyleProperty, "HelperTextStyleOverride");
            }
            else if (!Regex.IsMatch(email, formEmail))
            {
                txtEmail.SetValue(MaterialDesignThemes.Wpf.HintAssist.HelperTextProperty, "Wrong format");
                txtEmail.SetResourceReference(MaterialDesignThemes.Wpf.HintAssist.HelperTextStyleProperty, "HelperTextStyleOverride");
            }
            else
            {
                txtEmail.SetValue(MaterialDesignThemes.Wpf.HintAssist.HelperTextProperty, "");
            }
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                txtUserName.SetValue(MaterialDesignThemes.Wpf.HintAssist.HelperTextProperty, "Username is Empty");
                txtUserName.SetResourceReference(MaterialDesignThemes.Wpf.HintAssist.HelperTextStyleProperty, "HelperTextStyleOverride");
            }
            else
            {
                txtUserName.SetValue(MaterialDesignThemes.Wpf.HintAssist.HelperTextProperty, "");
            }
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Create Account Successful", "Success", MessageBoxButton.OK, MessageBoxImage.Error);
            UpdateProfile updateProfile = new UpdateProfile();
            updateProfile.Show();
            this.Close();
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
