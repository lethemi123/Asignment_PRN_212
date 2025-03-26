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

namespace Test1
{
    /// <summary>
    /// Interaction logic for CurrentPassword.xaml
    /// </summary>
    public partial class CurrentPassword : Window
    {
        public CurrentPassword()
        {
            InitializeComponent();
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

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            string password = passwordBox.Password;
            string message = string.IsNullOrEmpty(password) ? " " : strengCheckPassword(password);
            passwordBox.SetValue(MaterialDesignThemes.Wpf.HintAssist.HelperTextProperty, message);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PasswordBox_PasswordChanged_confirm(object sender, RoutedEventArgs e)
        
       {
            var passwordBox = sender as PasswordBox;
            if (passwordBox == null) return;
            string passwordConfirm = passwordBox.Password;
            string newPwd = newPassword.Password;
            if (string.IsNullOrEmpty(passwordConfirm))
            {
                passwordBox.SetValue(MaterialDesignThemes.Wpf.HintAssist.HelperTextProperty, " ");
                passwordBox.SetResourceReference(MaterialDesignThemes.Wpf.HintAssist.HelperTextStyleProperty, "HelperTextStyleOverride");
            }
            else if (passwordConfirm == newPwd)
            {
                passwordBox.SetValue(MaterialDesignThemes.Wpf.HintAssist.HelperTextProperty, "✔ Match");
                passwordBox.SetResourceReference(MaterialDesignThemes.Wpf.HintAssist.HelperTextStyleProperty, "HelperTextStyleMatch");
            }
            else
            {
                passwordBox.SetValue(MaterialDesignThemes.Wpf.HintAssist.HelperTextProperty, "❌ Passwords do not match");
                passwordBox.SetResourceReference(MaterialDesignThemes.Wpf.HintAssist.HelperTextStyleProperty, "HelperTextStyleOverride");
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
