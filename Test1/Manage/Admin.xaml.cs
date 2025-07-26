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
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private Person currentUser;
        List<Person> personList = new List<Person>();
        private ObservableCollection<ViewOrderModel> ItemHistoryBills = new ObservableCollection<ViewOrderModel>();
        private List<Category> categoryList;
        private List<Product> ProductList = new List<Product>();
        private Product selectedProduct = null;
        private readonly Prn212AssignmentContext context = new Prn212AssignmentContext();
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
        private void LoadProductData()
        {
            var products = context.Products
                .Include(p => p.ProductVariants)  
                .Include(p => p.Category)         
                .ToList();  

            
            var productList = products.Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.ProductDescription,
                Stock = p.ProductVariants.FirstOrDefault()?.Stock ?? 0,  
                Price = (double)(p.ProductVariants.FirstOrDefault()?.Price ?? 0.0m),  
                Storage = p.Category?.CategoryName ?? "",  
                CreatedAt = p.CreatedAt?.ToString("yyyy-MM-dd"),
                UpdatedAt = p.UpdatedAt?.ToString("yyyy-MM-dd"),
                ImagePathProduct = p.ImagePathProduct
            }).ToList();

            DataGridProduct.ItemsSource = productList;  // Gán dữ liệu vào DataGrid
            LoadCategories();
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
                txtUserIdAC.Text = selectedPerson.Id;
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

            // Kiểm tra nếu personList là null hoặc không chứa dữ liệu
            if (personList == null || personList.Count == 0)
            {
                personList = context.People.ToList(); // Lấy lại danh sách người dùng từ cơ sở dữ liệu
            }

            // Lọc danh sách theo UserName
            var filtered = personList
                .Where(p => !string.IsNullOrEmpty(p.UserName) && p.UserName.ToLower().Contains(keyword))
                .ToList();

            // Cập nhật lại DataGrid
            DataGridUsers.ItemsSource = filtered;
        }



        private void btnDeleteAC_Click(object sender, RoutedEventArgs e)
        {
            string id = txtUserIdAC.Text;
            var personToDelete = context.People.FirstOrDefault(p => p.Id == id);
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
       (!rdoAdmin.IsChecked.Value && !rdoCustomer.IsChecked.Value)) // Kiểm tra nếu không chọn Role
            {
                MessageBox.Show("Please fill in all the required fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            string id = txtUserIdAC.Text;
            var personToUpdate = context.People.FirstOrDefault(p => p.Id == id);
            if (personToUpdate != null)
            {
                personToUpdate.UserName = txtUserNameAC.Text;
                personToUpdate.Fname = txtFullNameAC.Text.Split(' ').Last();  // Tách Fname
                personToUpdate.Lname = string.Join(" ", txtFullNameAC.Text.Split(' ').SkipLast(1)); // Lname
                personToUpdate.Age = int.TryParse(txtAgeAC.Text, out int age) ? age : null;
                personToUpdate.Gender = txtGenderAC.Text;
                personToUpdate.PhoneNumber = txtPhoneNumberAC.Text;
                personToUpdate.Email = txtEmailAC.Text;
                personToUpdate.Address = txtAddress.Text;
                personToUpdate.Password = pswdAC.Password;
                personToUpdate.RoleAccount = rdoAdmin.IsChecked == true;

                context.SaveChanges();
                loadManageUser(); // Refresh lại DataGrid
                MessageBox.Show("Cập nhật thành công!");
            }
        }

        private void btnCreateAC_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra nếu bất kỳ trường nào còn trống
            if (string.IsNullOrEmpty(txtUserNameAC.Text) ||
                string.IsNullOrEmpty(txtFullNameAC.Text) ||
                string.IsNullOrEmpty(txtAgeAC.Text) ||
                string.IsNullOrEmpty(txtPhoneNumberAC.Text) ||
                string.IsNullOrEmpty(txtEmailAC.Text) ||
                string.IsNullOrEmpty(txtAddress.Text) ||
                string.IsNullOrEmpty(pswdAC.Password) ||
                (!rdoAdmin.IsChecked.Value && !rdoCustomer.IsChecked.Value)) // Kiểm tra nếu không chọn Role
            {
                MessageBox.Show("Please fill in all the required fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Nếu không có trường trống, thực hiện tạo tài khoản mới
            Person newPerson = new Person
            {
                Id = txtUserIdAC.Text,
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
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = DataGridProduct.SelectedItem as Product;  // Lấy sản phẩm được chọn từ DataGrid
            if (selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Kiểm tra nếu có sản phẩm nào được chọn
            var productInDb = context.Products.FirstOrDefault(p => p.ProductId == selectedProduct.ProductId);
            if (productInDb != null)
            {
                // Kiểm tra có sản phẩm trong giỏ hàng hoặc đơn hàng không
                if (productInDb.Carts.Any() || productInDb.OrderDetails.Any())
                {
                    MessageBox.Show("Không thể xóa sản phẩm này vì nó đang có trong giỏ hàng hoặc đơn hàng!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                context.Products.Remove(productInDb); // Xóa sản phẩm khỏi cơ sở dữ liệu
                context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                LoadProductData(); // Tải lại dữ liệu sản phẩm từ cơ sở dữ liệu
                MessageBox.Show("Sản phẩm đã được xóa thành công!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Sản phẩm không tồn tại trong cơ sở dữ liệu!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
                                          .FirstOrDefault(p => p.ProductId == productId);
            if (product == null) return;

            // Cập nhật thông tin sản phẩm
            product.ProductName = txtProductName.Text;
            product.ProductDescription = txtDescription.Text;
            product.CategoryId = cbxCateGrory.SelectedValue?.ToString();
            product.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);
            product.ImagePathProduct = ProductImage.Source?.ToString();

            // Cập nhật thông tin ProductVariant
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
                ProductId =  "P" + productId,
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
                ProductId = newProduct.ProductId
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
            var selectedProduct = DataGridProduct.SelectedItem as Product;  // Thay vì dynamic, sử dụng Product

            if (selectedProduct != null)
            {
                txtProductid.Text = selectedProduct.ProductId;
                txtProductName.Text = selectedProduct.ProductName;
                txtDescription.Text = selectedProduct.ProductDescription;
                txtStockProduct.Text = selectedProduct.ProductVariants.FirstOrDefault()?.Stock.ToString() ?? "0";  // Lấy stock từ ProductVariants
                txtPrice.Text = selectedProduct.ProductVariants.FirstOrDefault()?.Price.ToString() ?? "0";  // Lấy price từ ProductVariants

                cbxCateGrory.SelectedValue = selectedProduct.CategoryId;  // Chọn category

                if (!string.IsNullOrEmpty(selectedProduct.ImagePathProduct) && File.Exists(selectedProduct.ImagePathProduct))
                {
                    ProductImage.Source = new BitmapImage(new Uri(selectedProduct.ImagePathProduct));
                }
                else
                {
                    ProductImage.Source = null;
                }
            }
            LoadCategories();  // Đảm bảo danh sách danh mục được tải lại
        }






        private void LoadHistoryBills()
        {
            var historyBills = context.Orders
                .Include(o => o.Person)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                .Select(o => new ViewOrderModel
                {
                    Id = o.PersonId,
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
            DataGridYourHistory.ItemsSource = context.Orders
                .Include(o => o.Person)
                .Select(o => new
                {
                    o.PersonId,
                     o.OrderId,
                    o.ReceiverName,
                   o.ReceiverPhone,
                    o.ReceiverAddress,
                    TotalQuantity = o.OrderDetails.Sum(od => od.Quantity),
                    TotalPrice = o.TotalMoney ?? 0,
                    OrderDate = o.OrderDate ?? DateTime.MinValue,
                    o.OrderStatus,
                    Description = string.Join(", ", o.OrderDetails.Select(od => od.Product.ProductDescription)),
                    OrderDetails = o.OrderDetails.ToList(),
                    ContentOrder = string.Join(", ", o.OrderDetails.Select(od => od.Product.ProductName + " x" + od.Quantity))
                })
                .ToList();
        }
    }
}
