using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Model
{
    internal class DashboardViewModel : INotifyPropertyChanged
    {
        private int _totalPersons;
        public int TotalPersons
        {
            get => _totalPersons;
            set
            {
                _totalPersons = value;
                OnPropertyChanged();
            }
        }

        private int _totalOrder;
        public int TotalOrder
        {
            get => _totalOrder;
            set
            {
                _totalOrder = value;
                OnPropertyChanged();
            }
        }
        private string _id;
        public string Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set { _userName = value; OnPropertyChanged(); }
        }

        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(); }
        }

        private int? _age;
        public int? Age
        {
            get => _age;
            set { _age = value; OnPropertyChanged(); }
        }

        private string _gender;
        public string Gender
        {
            get => _gender;
            set { _gender = value; OnPropertyChanged(); }
        }

        private string _address;
        public string Address
        {
            get => _address;
            set { _address = value; OnPropertyChanged(); }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(); }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        private string _categoryId;
        public string CategoryId
        {
            get => _categoryId;
            set { _categoryId = value; OnPropertyChanged(); }
        }

        private string _imagePathProduct;
        public string ImagePathProduct
        {
            get => _imagePathProduct;
            set { _imagePathProduct = value; OnPropertyChanged(); }
        }



        public DashboardViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new Prn212AssignmentContext())
            {
                TotalPersons = context.People.Count();
                TotalOrder = context.Orders.Count();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

