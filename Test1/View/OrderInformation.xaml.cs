using System;
using System.Linq;
using System.Windows;
using Test1.Model;

namespace Test1.View
{
    /// <summary>
    /// Interaction logic for OrderInformation.xaml
    /// </summary>
    public partial class OrderInformation : Window
    {
        private ViewOrderModel _selectedOrder;
        private Prn212AssignmentContext _context = new Prn212AssignmentContext();

        public OrderInformation(ViewOrderModel selectedOrder)
        {
            InitializeComponent();
            _selectedOrder = selectedOrder;
            LoadInforMation(selectedOrder);
        }

        private void LoadInforMation(ViewOrderModel order)
        {
            if (order != null)
            {
                txtFullName.Text = order.ReceiverName;
                txtOrderAddress.Text = order.ReceiverAddress;
                txtPhoneNumber.Text = order.ReceiverPhone;
                txtDescription.Text = order.Description;
                txtOrderID.Text = order.OrderId;
                txtQuantity.Text = order.TotalQuantity.ToString();
                txtTotalPrice.Text = order.TotalPrice?.ToString("C2") ?? "0.00";
            }
            foreach (var detail in order.OrderDetails)
            {
                var content = $"{detail.Product.ProductName} x {detail.Quantity}";
                txtDescription.Text += content + Environment.NewLine;
            }
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedOrder == null)
            {
                MessageBox.Show("Chưa chọn đơn hàng!");
                return;
            }

            if (_selectedOrder.OrderStatus == "Pending")
            {
                // Chuyển trạng thái đơn hàng thành 'Done'
                var orderInDb = _context.Orders.FirstOrDefault(o => o.OrderId == _selectedOrder.OrderId);
                if (orderInDb != null)
                {
                    orderInDb.OrderStatus = "Done";  // Cập nhật trạng thái đơn hàng
                    _context.SaveChanges();
                }

                // Cập nhật số lượng sản phẩm trong kho
                foreach (var orderDetail in _selectedOrder.OrderDetails)
                {
                    var product = _context.ProductVariants.FirstOrDefault(p => p.ProductId == orderDetail.ProductId);
                    if (product != null)
                    {
                        product.Stock -= orderDetail.Quantity;  // Trừ số lượng kho
                    }
                }

                // Cộng tiền vào ví của Admin, không phải người đặt hàng
                var adminUser = _context.People.FirstOrDefault(p => p.RoleAccount == true);  // Tìm Admin (có RoleAccount là true)
                if (adminUser != null)
                {
                    adminUser.Balance += _selectedOrder.TotalPrice ?? 0;  // Cộng tiền vào ví Admin
                    _context.SaveChanges();
                }

                // Thông báo cho người dùng
                MessageBox.Show("Đơn hàng đã được xác nhận và chuyển sang trạng thái 'Done'.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                MessageBox.Show("Số tiền đã được cộng vào ví Admin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Đơn hàng không phải trạng thái 'Pending'.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // Refresh giao diện sau khi cập nhật
         

            Close();  // Đóng cửa sổ
        }

        private void btnReject_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedOrder == null)
            {
                MessageBox.Show("Chưa chọn đơn hàng!");
                return;
            }

          
            if (_selectedOrder.OrderStatus == "Pending")
            {
               
                var user = _context.People.FirstOrDefault(p => p.Id == _selectedOrder.Id);
                if (user != null)
                {
                 
                    user.Balance += _selectedOrder.TotalPrice ?? 0;
                    MessageBox.Show("Số tiền đã được hoàn lại vào ví của người đặt hàng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }

               
                var orderInDb = _context.Orders.FirstOrDefault(o => o.OrderId == _selectedOrder.OrderId);
                if (orderInDb != null)
                {
                    orderInDb.OrderStatus = "Cancelled";  // Chuyển trạng thái đơn hàng sang "Cancelled"
                    _context.SaveChanges();
                }

                MessageBox.Show("Đơn hàng đã bị hủy và tiền đã được hoàn lại!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
               
                var orderInDb = _context.Orders.FirstOrDefault(o => o.OrderId == _selectedOrder.OrderId);
                if (orderInDb != null)
                {
                    orderInDb.OrderStatus = "Cancelled";  
                    _context.SaveChanges();
                }

                MessageBox.Show("Đơn hàng đã bị hủy!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            

            Close(); 
        }

    }
}
