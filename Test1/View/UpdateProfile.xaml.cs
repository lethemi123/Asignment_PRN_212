using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Test1.Model;

namespace Test1
{
    public partial class UpdateProfile : Window
    {
        private readonly PendingAccount _pending;
        private int _calculatedAge = 0;

        public UpdateProfile(PendingAccount account)
        {
            InitializeComponent();
            _pending = account ?? throw new ArgumentNullException(nameof(account));
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // Validate cơ bản
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter your name.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhoneUser.Text))
            {
                MessageBox.Show("Please enter your phone number.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dpBirthDay.SelectedDate == null || _calculatedAge <= 0)
            {
                MessageBox.Show("Please select a valid birthday.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Giới tính
            string gender = rdoMale.IsChecked == true ? "Male" :
                            rdoFeMale.IsChecked == true ? "Female" : "Other";

            // Ngày sinh
            DateOnly? dob = null;
            if (dpBirthDay.SelectedDate.HasValue)
            {
                dob = DateOnly.FromDateTime(dpBirthDay.SelectedDate.Value);
            }

            try
            {
                using var context = new Prn212AssignmentContext();
                var person = new Person
                {
                    UserName = _pending.UserName,
                    Email = _pending.Email,
                    Password = _pending.Password,
                    Fname = txtFirstName.Text.Trim(),
                    Lname = txtLastName.Text.Trim(),
                    PhoneNumber = txtPhoneUser.Text.Trim(),
                    Gender = gender,
                    Address = txtAddress.Text.Trim(),
                    DateOfBirth = DateOnly.FromDateTime(dpBirthDay.SelectedDate.Value),
                    Age = _calculatedAge,
                    Balance = 0,
                    RoleAccount = false
                };

                context.People.Add(person);
                context.SaveChanges();

                MessageBox.Show("Account created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                new Login().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException?.Message ?? "No inner exception";
                MessageBox.Show($"Something went wrong:\n{ex.Message}\n{inner}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dpBirthDay_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpBirthDay.SelectedDate.HasValue)
            {
                // Convert từ DateTime sang DateOnly
                DateOnly birthDate = DateOnly.FromDateTime(dpBirthDay.SelectedDate.Value);

                int currentYear = DateTime.Now.Year;
                int age = currentYear - birthDate.Year;

                // Nếu sinh nhật năm nay chưa tới => trừ thêm 1 tuổi
                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                if (today < birthDate.AddYears(age))
                {
                    age--;
                }

                if (age < 10)
                {
                    MessageBox.Show("Age must be at least 10 years old.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    dpBirthDay.SelectedDate = null;
                    _calculatedAge = 0;
                    return;
                }

                _calculatedAge = age;
            }
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
    }
}
