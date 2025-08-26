using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using Test1.View;

namespace Test1.Manage
{
    public partial class Admin : Window
    {
        private Person currentUser;
        private ObservableCollection<Product> ProductList = new ObservableCollection<Product>();
        private List<Category> categoryList;
        private Product selectProduct;
        private readonly Prn212AssignmentContext context = new Prn212AssignmentContext();
        private ObservableCollection<ViewOrderModel> ItemHistoryBills = new ObservableCollection<ViewOrderModel>();

        public Admin(Person user)
        {
            InitializeComponent();
            Window window = Window.GetWindow(this);
            window.WindowState = WindowState.Normal;
            LoadProfile(user);
            this.DataContext = new DashboardViewModel();
            loadManageUser();
            LoadProductData();
            LoadCategories();
            LoadHistoryBills();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            selectProduct = border?.DataContext as Product;

            if (selectProduct != null)
            {
                txtProductName.Text = selectProduct.ProductName;
                txtProductid.Text = selectProduct.ProductId.ToString();
                txtDescription.Text = selectProduct.ProductDescription;
                cbxCateGrory.SelectedValue = selectProduct.CategoryId;

                cbxProductVariants.ItemsSource = selectProduct.ProductVariants;
                cbxProductVariants.SelectedIndex = 0;

                if (!string.IsNullOrEmpty(selectProduct.ImagePathProduct) && File.Exists(selectProduct.ImagePathProduct))
                {
                    ProductImage.Source = new BitmapImage(new Uri(selectProduct.ImagePathProduct));
                }
                else
                {
                    ProductImage.Source = null;
                }

                // Nếu có variant thì load stock & price tương ứng
                var variant = selectProduct.ProductVariants.FirstOrDefault();
                if (variant != null)
                {
                    txtPrice.Text = (variant.Price ?? 0).ToString("F2");
                    txtStockProduct.Text = variant.Stock.ToString();
                }
            }
        }


        private void LoadProductData()
        {
            var products = context.Products
                .Include(p => p.ProductVariants)
                .Include(p => p.Category)
                .ToList();

            ProductList.Clear();
            foreach (var p in products)
            {
                p.IsSelected= false; 
                ProductList.Add(p);
            }

            DataGridProduct.ItemsSource = ProductList;
            LoadCategories();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                var product = checkBox.DataContext as Product;
                if (product != null)
                {
                    product.IsSelected = checkBox.IsChecked ?? false;
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedProducts = ProductList.Where(p => p.IsSelected).ToList();

            if (!selectedProducts.Any())
            {
                MessageBox.Show("Please select at least one product to delete!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            foreach (var product in selectedProducts)
            {
                var productInDb = context.Products
                    .Include(p => p.ProductVariants)
                    .FirstOrDefault(p => p.ProductId == product.ProductId);

                if (productInDb != null)
                {
                    if (productInDb.Carts.Any() || productInDb.OrderDetails.Any())
                    {
                        MessageBox.Show("This product cannot be deleted because it is linked to a cart or an order!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Xóa các ProductVariant liên quan trước
                    context.ProductVariants.RemoveRange(productInDb.ProductVariants);

                    // Sau đó mới xóa Product
                    context.Products.Remove(productInDb);
                }
            }


            context.SaveChanges();
            LoadProductData();
            MessageBox.Show($"{selectedProducts.Count} product(s) deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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

            txtTotalMoneyUser.Text = user.Balance?.ToString("N0") + " $";

            if (!string.IsNullOrEmpty(user.PathImagePerson) && File.Exists(user.PathImagePerson))
            {
                ProfileImage.Source = new BitmapImage(new Uri(user.PathImagePerson));
            }
        }

        private void txtFullName_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void rdoMale_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void loadManageUser()
        {
            var users = context.People.ToList();
            DataGridUsers.ItemsSource = users;
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
            var selectedPerson = DataGridUsers.SelectedItem as Person;
            if (selectedPerson != null)
            {
                txtUserIdAC.Text = selectedPerson.Id.ToString();
                txtUserNameAC.Text = selectedPerson.UserName;
                txtFullNameAC.Text = $"{selectedPerson.Lname} {selectedPerson.Fname}";
                txtAgeAC.Text = selectedPerson.Age?.ToString() ?? "";
                txtGenderAC.Text = selectedPerson.Gender;
                txtPhoneNumberAC.Text = selectedPerson.PhoneNumber;
                txtEmailAC.Text = selectedPerson.Email;
                txtAddress.Text = selectedPerson.Address;
                pswdAC.Password = selectedPerson.Password;

                if (selectedPerson.RoleAccount == true)
                    rdoAdmin.IsChecked = true;
                else
                    rdoCustomer.IsChecked = true;
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
            var headerCheckBox = sender as CheckBox;
            if (headerCheckBox != null)
            {
                foreach (var product in ProductList)
                {
                    product.IsSelected = headerCheckBox.IsChecked ?? false;
                }
                DataGridProduct.Items.Refresh();
            }
        }

        private void btnBowseImageProduc_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                ProductImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void dataGrid_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btnSearchAC_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearchAC.Text.Trim().ToLower();
            var users = context.People.ToList();

            var filtered = users
                .Where(p => !string.IsNullOrEmpty(p.UserName) && p.UserName.ToLower().Contains(keyword))
                .ToList();

            DataGridUsers.ItemsSource = filtered;
        }

        private void btnDeleteAC_Click(object sender, RoutedEventArgs e)
        {
            string id = txtUserIdAC.Text;
            var personToDelete = context.People.FirstOrDefault(p => p.Id.ToString() == id);
            if (context.Orders.Any(o => o.PersonId == personToDelete.Id))
            {
                MessageBox.Show("Không thể xóa người dùng này vì đang có đơn hàng liên kết.");
                return;
            }
            if (personToDelete != null)
            {
                context.People.Remove(personToDelete);
                context.SaveChanges();
                loadManageUser();
                MessageBox.Show("Xoá thành công!");
            }
        }

        private void btnUpdateAC_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserNameAC.Text) ||
                string.IsNullOrEmpty(txtFullNameAC.Text) ||
                string.IsNullOrEmpty(txtAgeAC.Text) ||
                string.IsNullOrEmpty(txtPhoneNumberAC.Text) ||
                string.IsNullOrEmpty(txtEmailAC.Text) ||
                string.IsNullOrEmpty(txtAddress.Text) ||
                string.IsNullOrEmpty(pswdAC.Password) ||
                (!rdoAdmin.IsChecked.Value && !rdoCustomer.IsChecked.Value))
            {
                MessageBox.Show("Please fill in all the required fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string id = txtUserIdAC.Text;
            var personToUpdate = context.People.FirstOrDefault(p => p.Id.ToString() == id);
            if (personToUpdate != null)
            {
                personToUpdate.UserName = txtUserNameAC.Text;
                personToUpdate.Fname = txtFullNameAC.Text.Split(' ').Last();
                personToUpdate.Lname = string.Join(" ", txtFullNameAC.Text.Split(' ').SkipLast(1));
                personToUpdate.Age = int.TryParse(txtAgeAC.Text, out int age) ? age : null;
                personToUpdate.Gender = txtGenderAC.Text;
                personToUpdate.PhoneNumber = txtPhoneNumberAC.Text;
                personToUpdate.Email = txtEmailAC.Text;
                personToUpdate.Address = txtAddress.Text;
                personToUpdate.Password = pswdAC.Password;
                personToUpdate.RoleAccount = rdoAdmin.IsChecked == true;

                context.SaveChanges();
                loadManageUser();
                MessageBox.Show("Cập nhật thành công!");
            }
        }

        private void btnCreateAC_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserNameAC.Text) ||
                string.IsNullOrEmpty(txtFullNameAC.Text) ||
                string.IsNullOrEmpty(txtAgeAC.Text) ||
                string.IsNullOrEmpty(txtPhoneNumberAC.Text) ||
                string.IsNullOrEmpty(txtEmailAC.Text) ||
                string.IsNullOrEmpty(txtAddress.Text) ||
                string.IsNullOrEmpty(pswdAC.Password) ||
                (!rdoAdmin.IsChecked.Value && !rdoCustomer.IsChecked.Value))
            {
                MessageBox.Show("Please fill in all the required fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Person newPerson = new Person
            {
                
                UserName = txtUserNameAC.Text,
                Fname = txtFullNameAC.Text.Split(' ').Last(),
                Lname = string.Join(" ", txtFullNameAC.Text.Split(' ').SkipLast(1)),
                Age = int.TryParse(txtAgeAC.Text, out int age) ? age : null,
                Gender = txtGenderAC.Text,
                PhoneNumber = txtPhoneNumberAC.Text,
                Email = txtEmailAC.Text,
                Address = txtAddress.Text,
                Password = pswdAC.Password,
                RoleAccount = rdoAdmin.IsChecked == true
            };

            context.People.Add(newPerson);
            context.SaveChanges();
            loadManageUser();
            MessageBox.Show("Tạo tài khoản mới thành công!");
        }

        private void LoadCategories()
        {
            categoryList = context.Categories.ToList();
            cbxCateGrory.ItemsSource = categoryList;
            cbxCateGrory.DisplayMemberPath = "CategoryName";
            cbxCateGrory.SelectedValuePath = "CategoryId";
        }

        private void btnClearProduct_Click(object sender, RoutedEventArgs e)
        {
            txtProductid.Clear();
            txtProductName.Clear();
            txtDescription.Clear();
            txtStockProduct.Clear();
            txtPrice.Clear();
            cbxCateGrory.SelectedIndex = -1;
            ProductImage.Source = null;
        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            var productId = txtProductid.Text;
            var product = context.Products.Include(p => p.ProductVariants)
                                          .FirstOrDefault(p => p.ProductId.ToString() == productId);
            if (product == null) return;

            product.ProductName = txtProductName.Text;
            product.ProductDescription = txtDescription.Text;
            product.CategoryId = cbxCateGrory.SelectedValue?.ToString();
            product.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);
            product.ImagePathProduct = ProductImage.Source?.ToString();

            var variant = product.ProductVariants.FirstOrDefault();
            if (variant != null)
            {
                int.TryParse(txtStockProduct.Text, out int stock);
                double.TryParse(txtPrice.Text, out double price);
                variant.Stock = stock;
                variant.Price = (decimal)price;
            }

            context.SaveChanges();
            LoadProductData();
            MessageBox.Show("Cập nhật thành công!");
        }

        private void btnCreateProduct_Click(object sender, RoutedEventArgs e)
        {
            string productId = txtProductid.Text;
            string productName = txtProductName.Text;
            string description = txtDescription.Text;
            int.TryParse(txtStockProduct.Text, out int stock);
            double.TryParse(txtPrice.Text, out double price);
            string categoryId = cbxCateGrory.SelectedValue?.ToString();

            var newProduct = new Product
            {
                ProductId = int.Parse("P" + productId.ToString()),
                ProductName = productName,
                ProductDescription = description,
                CategoryId = categoryId,
                CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                UpdatedAt = DateOnly.FromDateTime(DateTime.Now),
                ImagePathProduct = ProductImage.Source?.ToString()
            };

            var variant = new ProductVariant
            {
                Stock = stock,
                Price = (decimal)price,
                ProductId = int.Parse(newProduct.ProductId.ToString())
            };

            newProduct.ProductVariants = new List<ProductVariant> { variant };
            context.Products.Add(newProduct);
            context.SaveChanges();
            LoadCategories();
            LoadProductData();
            MessageBox.Show("Thêm sản phẩm thành công!");
        }

        private void DataGridProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridProduct.SelectedItem is Product selectedProduct)
            {
                txtProductid.Text = selectedProduct.ProductId.ToString();
                txtProductName.Text = selectedProduct.ProductName;
                txtDescription.Text = selectedProduct.ProductDescription;
                txtStockProduct.Text = selectedProduct.ProductVariants?.FirstOrDefault()?.Stock.ToString() ?? "0";
                txtPrice.Text = selectedProduct.ProductVariants?.FirstOrDefault()?.Price.ToString() ?? "0";
                cbxCateGrory.SelectedValue = selectedProduct.CategoryId;

                if (!string.IsNullOrEmpty(selectedProduct.ImagePathProduct) && File.Exists(selectedProduct.ImagePathProduct))
                {
                    ProductImage.Source = new BitmapImage(new Uri(selectedProduct.ImagePathProduct));
                }
                else
                {
                    ProductImage.Source = null;
                }
            }
        }

        private void LoadHistoryBills()
        {
            var historyBills = context.Orders
                .Include(o => o.Person)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                .Select(o => new ViewOrderModel
                {
                    Id = o.PersonId.ToString(),
                    OrderId = o.OrderId,
                    ReceiverName = o.ReceiverName,
                    ReceiverPhone = o.ReceiverPhone,
                    ReceiverAddress = o.ReceiverAddress,
                    TotalQuantity = o.OrderDetails.Sum(od => od.Quantity),
                    TotalPrice = o.TotalMoney ?? 0,
                    OrderDate = o.OrderDate ?? DateTime.MinValue,
                    OrderStatus = o.OrderStatus,
                    Description = string.Join(", ", o.OrderDetails.Select(od => od.Product.ProductDescription)),
                    OrderDetails = o.OrderDetails.ToList(),
                    ContentOrder = string.Join(", ", o.OrderDetails.Select(od => od.Product.ProductName + " x" + od.Quantity))
                })
                .ToList();

            DataGridYourHistory.ItemsSource = historyBills;
        }


        private void DataGridYourHistory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataGridYourHistory.SelectedItem != null)
            {
                var selectedOrder = (ViewOrderModel)DataGridYourHistory.SelectedItem;
                var orderWindow = new OrderInformation(selectedOrder);
                orderWindow.Show();
            }
            else
            {
                MessageBox.Show("Chưa chọn đơn hàng!");
            }
        }

        private void DataGridYourHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadHistoryBills();
            loadManageUser();
            LoadProductData();
            LoadCategories();
          
        }

        private void cbxProductVariants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selectedVariant = context.ProductVariants.ToList().FirstOrDefault(v => v.VariantId.ToString() == comboBox.SelectedValue?.ToString());
            var product = comboBox?.DataContext as Product;
            

            if (product != null && selectedVariant != null)
            {
              
                product.SelectedVariant = selectedVariant;

                // Ví dụ: hiển thị giá hoặc tồn kho tương ứng
                txtPrice.Text = selectedVariant.Price?.ToString("F2");
                txtStockProduct.Text = selectedVariant.Stock?.ToString();
            }
        }
    }
}