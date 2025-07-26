using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test1.Model;
using Test1.Manage;

namespace Test1.View
{
    public partial class ViewOrder : Window
    {
        private Order currentOrder;
        private Person currentUser;
        private Prn212AssignmentContext context = new Prn212AssignmentContext();
        private ObservableCollection<CartViewModel> cartList = new();
       
        public Action<ViewOrderModel>? OnOrderCompleted;

        public ViewOrder(Person user)
        {
            InitializeComponent();
            currentUser = user;
            LoadCartFromDatabase(user.Id);
        }

        private void LoadCartFromDatabase(string userId)
        {
            currentUser = context.People.FirstOrDefault(p => p.Id == userId);

            currentOrder = context.Orders
                            .Include(o => o.Person)
                            .Include(o => o.OrderDetails)
                            .ThenInclude(od => od.Product)
                            .Where(o => o.PersonId == userId)
                            .OrderByDescending(o => o.OrderDate)
                            .FirstOrDefault();

            var itemCart = context.Carts
                .Where(c => c.PersonId == userId)
                .Include(c => c.Product)
                .ToList()
                .Select(c =>
                {
                    var variant = c.VariantId.HasValue
                        ? context.ProductVariants.FirstOrDefault(v => v.VariantId == c.VariantId)
                        : null;

                    return new CartViewModel
                    {
                        CartId = c.CartId,
                        ProductId = c.ProductId ?? "",
                        Name = c.Product?.ProductName ?? "N/A",
                        Variant = variant?.Storage ?? "N/A",
                        Quantity = c.Quantity ?? 0,
                        UnitPrice = variant?.Price ?? 0,
                        TotalAmount = (c.Quantity ?? 0) * (variant?.Price ?? 0),
                        IsSelected = c.IsSelected
                    };
                })
                .ToList();

            cartList = new ObservableCollection<CartViewModel>(itemCart);
            dataGridOrderDetail.ItemsSource = cartList;

            txtTotalQuantity.Text = itemCart.Sum(c => c.Quantity).ToString();
            txtTotalAmount.Text = itemCart.Sum(c => c.TotalAmount).ToString("N2") + " $";

            tblPhoneNumber.Text = currentUser?.PhoneNumber ?? "N/A";
            tblFullName.Text = $"{currentUser?.Fname} {currentUser?.Lname}";
            tblAddress.Text = currentUser?.Address ?? "N/A";
            txtOrderID.Text = currentOrder?.OrderId ?? "N/A";
            txtOrderDate.Text = currentOrder?.OrderDate?.ToString("dd/MM/yyyy") ?? DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
            }
        }

        private void dataGridOrderDetail_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

        private void headerCheckbox_Click(object sender, RoutedEventArgs e)
        {
            bool isChecked = (sender as CheckBox)?.IsChecked ?? false;

            if (cartList == null || !cartList.Any()) return;

            foreach (var item in cartList)
            {
                item.IsSelected = isChecked;
            }

            dataGridOrderDetail.Items.Refresh();
        }

        private void btnRejected_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = cartList.Where(i => i.IsSelected).ToList();

            if (!selectedItems.Any())
            {
                MessageBox.Show("Please select items to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            foreach (var item in selectedItems)
            {
                var cart = context.Carts.FirstOrDefault(c => c.CartId == item.CartId);
                if (cart != null)
                {
                    context.Carts.Remove(cart);
                }
            }

            context.SaveChanges();
            MessageBox.Show("Selected items deleted.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadCartFromDatabase(currentUser.Id);
        }

       

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            if (cartList == null || !cartList.Any())
            {
                MessageBox.Show("Giỏ hàng trống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show("Bạn muốn thanh toán qua ví không?\nNhấn 'Có' để thanh toán qua ví, 'Không' để thanh toán khi giao hàng.",
                                         "Phương thức thanh toán",
                                         MessageBoxButton.YesNoCancel,
                                         MessageBoxImage.Question);

            if (result == MessageBoxResult.Cancel)
                return;

            double totalCartAmount = (double)cartList.Sum(c => c.TotalAmount);

            if (result == MessageBoxResult.Yes && (currentUser.Balance ?? 0) < totalCartAmount)
            {
                MessageBox.Show("Số dư trong ví không đủ! Đơn hàng không được xử lý.", "Thanh toán thất bại", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Tạo đơn hàng cho từng sản phẩm trong giỏ hàng
            foreach (var item in cartList)
            {
                // Tạo mã đơn hàng và mã chi tiết đơn hàng duy nhất
                string orderId = "O" + DateTime.Now.Ticks + new Random().Next(100, 999);
                string orderDetailId = "OD" + Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();

                // Thêm đơn hàng vào cơ sở dữ liệu
                var newOrder = new Order
                {
                    ReceiverName = $"{currentUser.Fname} {currentUser.Lname}",
                    ReceiverPhone = currentUser.PhoneNumber,
                    ReceiverAddress = currentUser.Address,
                    OrderId = orderId,
                    PersonId = currentUser.Id,
                    OrderDate = DateTime.Now,
                    OrderStatus = (result == MessageBoxResult.Yes) ?  "Pending" : "Pressing...", 
                    OrderAddress = currentUser.Address,
                    TotalMoney = (double)item.TotalAmount,
                    PaymentMethod = (result == MessageBoxResult.Yes) ? "COO" : "COD "
                };
                context.Orders.Add(newOrder);

                var orderDetail = new OrderDetail
                {
                    OrderDetailId = orderDetailId,
                    OrderId = orderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    VariantId = item.VariantId
                };
                context.OrderDetails.Add(orderDetail);

                // Nếu thanh toán qua ví thì trừ tiền trong ví của người dùng đang đăng nhập
                if (result == MessageBoxResult.Yes)
                {
                    currentUser.Balance -= (double)item.TotalAmount;
                }

                OnOrderCompleted?.Invoke(new ViewOrderModel
                {
                    OrderId = newOrder.OrderId,
                    OrderDate = newOrder.OrderDate ?? DateTime.Now,
                    OrderAddress = newOrder.OrderAddress,
                    TotalPrice = newOrder.TotalMoney ?? 0,
                    TotalQuantity = item.Quantity,
                    PhoneNumber = currentUser.PhoneNumber,
                    FullName = $"{currentUser.Fname} {currentUser.Lname}",
                    PaymentMethod = newOrder.PaymentMethod,
                    OrderStatus = newOrder.OrderStatus
                });

                // Cập nhật số lượng trong kho
                var product = context.ProductVariants.FirstOrDefault(p => p.ProductId == item.ProductId);
                if (product != null)
                {
                    product.Stock -= item.Quantity;
                }
            }

            // Xoá giỏ hàng sau khi đơn hàng được tạo
            var userCarts = context.Carts.Where(c => c.PersonId == currentUser.Id).ToList();
            context.Carts.RemoveRange(userCarts);
            context.SaveChanges();

            MessageBox.Show("Đơn hàng đã được tạo thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);

            // Cập nhật lại giao diện
            LoadCartFromDatabase(currentUser.Id);
           
        }



       


    }
}
