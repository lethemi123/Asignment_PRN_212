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
using Test1.Model;
using System.IO;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using MaterialDesignThemes.Wpf;

namespace Test1.Manage
{
    public partial class Customer : Window
    {
        public ObservableCollection<ViewOrderModel> ViewOrders { get; set; } = new ObservableCollection<ViewOrderModel>();
        public List<Product> AllProducts { get; set; } = new List<Product>();
        private Product selectProduct;
        public ObservableCollection<Product> ListProducts { get; set; }
        private Person currentUser;
        public ObservableCollection<Category> ListCategory { get; set; }
        private readonly Prn212AssignmentContext context;

        public Customer(Person user)
        {
            currentUser = user;
            InitializeComponent();
            context = new Prn212AssignmentContext();

            var viewOrder = new ViewOrder(currentUser);
            viewOrder.OnOrderCompleted += ViewOrderCompletedHandler;

            

            DataGridOrder.ItemsSource = ViewOrders;
            LoadProduct();
            LoadProfile(currentUser);
            LoadCateGrories();
            LoadOrderHistory();
            this.DataContext = this;
        }
        private void LoadProfile(Person user)
        {
            txtUserName.Text = user.UserName;
            txtEmail.Text = user.Email;
            txtPhoneNumber.Text = user.PhoneNumber;
            txtRoleAccount.Text = user.RoleAccount == true ? "Admin" : "User";

            if (user.Gender == "Male")
                rdoMale.IsChecked = true;
            else if (user.Gender == "Female")
                rdoFeMale.IsChecked = true;
            else
                rdoOther.IsChecked = true;

            txtFullName.Text = $"{user.Lname} {user.Fname}";

            if (user.DateOfBirth.HasValue)
                dpBirthday.SelectedDate = user.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue);

            txtTotalMoneyUser.Text = user.Balance?.ToString("N0");

            if (!string.IsNullOrEmpty(user.PathImagePerson) && File.Exists(user.PathImagePerson))
            {
                ProfileImage.Source = new BitmapImage(new Uri(user.PathImagePerson));
            }
        }
   
        private void LoadProduct()
        {
            var products = context.Products.Include(p => p.Category).Include(p => p.ProductVariants).ToList();
            AllProducts = products;
            ListProducts = new ObservableCollection<Product>(products);
        }

        private void LoadCateGrories()
        {
            ListCategory = new ObservableCollection<Category>(context.Categories.ToList());
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        private void btnViewOrder_Click(object sender, RoutedEventArgs e)
        {
            var viewOrderWindow = new ViewOrder(currentUser);
            viewOrderWindow.OnOrderCompleted += ViewOrderCompletedHandler;
            viewOrderWindow.ShowDialog();
        } 
        private void ViewOrderCompletedHandler(ViewOrderModel model)
        {
            ViewOrders.Add(model);

            tblTotalPriceOrder.Text = ViewOrders.Sum(v => v.TotalPrice)?.ToString("N0") + " $";
            tblTotalQuanityOrder.Text = ViewOrders.Sum(v => v.TotalQuantity).ToString();
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
        private void LoadOrderHistory()
        {
            ViewOrders.Clear(); // Xoá cũ nếu có

            var orderList = context.Orders
                .Where(o => o.PersonId == currentUser.Id)
                .ToList();

            foreach (var order in orderList)
            {
                var totalQuantity = context.OrderDetails
                    .Where(d => d.OrderId == order.OrderId)
                    .Sum(d => d.Quantity);

                ViewOrders.Add(new ViewOrderModel
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate ?? DateTime.Now,
                    OrderAddress = order.ReceiverAddress,
                    TotalPrice = order.TotalMoney ?? 0,
                    TotalQuantity = totalQuantity ?? 0,
                    PhoneNumber = order.ReceiverPhone,
                    FullName = order.ReceiverName,
                    PaymentMethod = order.PaymentMethod,
                    OrderStatus = order.OrderStatus
                });
            }

            tblTotalPriceOrder.Text = ViewOrders.Sum(v => v.TotalPrice)?.ToString("N0") + " $";
            tblTotalQuanityOrder.Text = ViewOrders.Sum(v => v.TotalQuantity).ToString();
        }

        private void btnNaptien_Click(object sender, RoutedEventArgs e)
        {
            CreaditCard creaditCard = new CreaditCard();
            creaditCard.Show();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            selectProduct = border?.DataContext as Product;

            if (selectProduct != null)
            {
                tbxProductName.Text = selectProduct.ProductName;
                tbxProductID.Text = selectProduct.ProductId;
                tbxProducType.Text = selectProduct.Category?.CategoryName ?? "N/A";

                cbxProductVariants.ItemsSource = selectProduct.ProductVariants.ToList();
                cbxProductVariants.DisplayMemberPath = "Storage";
                cbxProductVariants.SelectedIndex = 0;

                if (!string.IsNullOrEmpty(selectProduct.ImagePathProduct) && File.Exists(selectProduct.ImagePathProduct))
                {
                    ImangePathProduct.Source = new BitmapImage(new Uri(selectProduct.ImagePathProduct));
                }
                else
                {
                    ImangePathProduct.Source = null;
                }

                productDetailPanel.Visibility = Visibility.Visible;
            }
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

        private void UpdateTotalDynamic()
        {
            if (tbxProductPrice == null || tblTotalCart == null)
                return;

            if (cbxProductVariants.SelectedItem is ProductVariant variant)
            {
                int quantity = (int)tbxProductStock.Value;
                decimal price = variant.Price ?? 0;
                decimal total = quantity * price;

                tbxProductPrice.Text = $"{price:N0} $";
                tblTotalCart.Text = $"{total:N0} $";
            }
            else
            {
                tbxProductPrice.Text = "N/A";
                tblTotalCart.Text = "0 $";
            }
        }

        private void cbxProductVariants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTotalDynamic();
        }

        private void FilledComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectCategory = FilledComboBox.SelectedItem as Category;
            if (selectCategory != null)
            {
                using (var contexxt = new Prn212AssignmentContext())
                {
                    var products = contexxt.Products
                        .Include(p => p.Category)
                        .Include(p => p.ProductVariants)
                        .Where(p => p.CategoryId.Contains(selectCategory.CategoryId))
                        .ToList();

                    ListProducts.Clear();
                    foreach (var product in products)
                    {
                        ListProducts.Add(product);
                    }
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string fillterByName = txtFillterByName.Text.ToLower();
            var filter = AllProducts.Where(p => p.ProductName != null && p.ProductName.ToLower().Contains(fillterByName)).ToList();
            ListProducts.Clear();
            foreach (var product in filter)
            {
                ListProducts.Add(product);
            }
        }

        private void tbxProductStock_ValueChanged(object sender, RoutedPropertyChangedEventArgs<int> e)
        {
            UpdateTotalDynamic();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (selectProduct == null || cbxProductVariants.SelectedItem == null)
            {
                MessageBox.Show("Please select a product and variant to clear.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int quantity = (int)tbxProductStock.Value;
            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var variant = cbxProductVariants.SelectedItem as ProductVariant;
            if (variant == null)
            {
                MessageBox.Show("Invalid variant selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var existing = context.Carts.FirstOrDefault(c =>
                c.PersonId == currentUser.Id &&
                c.ProductId == selectProduct.ProductId &&
                c.VariantId == variant.VariantId);

            if (existing != null)
            {
                existing.Quantity += quantity;
                context.Carts.Update(existing);
            }
            else
            {
                var newCart = new Cart
                {
                    PersonId = currentUser.Id,
                    ProductId = selectProduct.ProductId,
                    VariantId = variant.VariantId,
                    Quantity = quantity
                };
                context.Carts.Add(newCart);
            }

            context.SaveChanges();
            MessageBox.Show("Added to cart!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

      

        private void ControlBarUC_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnOrderProductByUser_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = DataGridOrder.SelectedItem as ViewOrderModel;

            if (selectedOrder == null)
            {
                MessageBox.Show("Please select an order to process.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (selectedOrder.OrderStatus == "Pending" || selectedOrder.PaymentMethod == "COD")
            {
                MessageBox.Show("This order is already paid.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            double amount = (Double)selectedOrder.TotalPrice;

            if ((currentUser.Balance ?? 0) < amount)
            {
                MessageBox.Show("Insufficient balance!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Update balance
            currentUser.Balance -= amount;

            // Update order
            var orderInDb = context.Orders.FirstOrDefault(o => o.OrderId == selectedOrder.OrderId);
            if (orderInDb != null)
            {
                orderInDb.OrderStatus = "Pending";
                orderInDb.PaymentMethod = "COD";
            }

            // Update ViewOrder
            selectedOrder.OrderStatus = "Pending";
            selectedOrder.PaymentMethod = "COO";

            context.People.Update(currentUser);
            context.SaveChanges();

            DataGridOrder.Items.Refresh(); // Cập nhật lại hiển thị
            txtTotalMoneyUser.Text = currentUser.Balance?.ToString("N0");

            MessageBox.Show("Payment successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridOrder.SelectedItem is ViewOrderModel selectedOrder)
            {
                var infoWindow = new ShowInformation(selectedOrder);

                // Đăng ký callback khi ShowInformation update xong
                infoWindow.OrderUpdated += () =>
                {
                    LoadOrderHistory(); 
                };

                infoWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an order to update.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DataGridOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
