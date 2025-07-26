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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test1.Model;

namespace Test1.View
{
    /// <summary>
    /// Interaction logic for ShowInformation.xaml
    /// </summary>
    public partial class ShowInformation : Window
    {
        public event Action? OrderUpdated;
        public ShowInformation(ViewOrderModel selectedOrder)
        {
            InitializeComponent();
            if(selectedOrder != null)
            {
                txtOrderID.Text = selectedOrder.OrderId;
                txtFullName.Text = selectedOrder.FullName;
                txtOrderAddress.Text = selectedOrder.OrderAddress;
                txtPhoneNumber.Text = selectedOrder.PhoneNumber;         
               
            }



        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var orderId = txtOrderID.Text.Trim();
                using (var context = new Prn212AssignmentContext()) // Đúng tên DbContext của bạn
                {
                    var order = context.Orders.FirstOrDefault(o => o.OrderId == orderId);
                    if (order != null)
                    {
                        // Cập nhật người nhận
                        order.ReceiverName = txtFullName.Text.Trim();
                        order.ReceiverPhone = txtPhoneNumber.Text.Trim();
                        order.ReceiverAddress = txtOrderAddress.Text.Trim();

                        context.SaveChanges();

                        MessageBox.Show("Order updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                        OrderUpdated?.Invoke(); // Gửi sự kiện ra ngoài để Customer nhận được
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Order not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




    }
}
