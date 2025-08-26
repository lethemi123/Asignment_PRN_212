using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Test1.Model;
using Test1.Manage;

namespace Test1.View
{
    public partial class ViewOrder : Window
    {
        private Order? currentOrder;
        private Person currentUser;
        private Prn212AssignmentContext context = new Prn212AssignmentContext();
        private ObservableCollection<CartViewModel> cartList = new();

        public Action<ViewOrderModel>? OnOrderCompleted;

        public ViewOrder(Person user)
        {
            InitializeComponent();
            currentUser = user;
            LoadCartFromDatabase(user.Id);
            dataGridOrderDetail.ItemsSource = cartList;

            tblFullName.Text = $"{currentUser.Fname} {currentUser.Lname}";
            txtOrderID.Text = currentOrder?.OrderId ?? "No Order";
            tblPhoneNumber.Text = currentUser.PhoneNumber;
            tblAddress.Text = currentUser.Address;
            txtTotalAmount.Text = cartList.Sum(c => c.TotalAmount).ToString("N2");
            txtTotalQuantity.Text = cartList.Sum(c => c.Quantity).ToString();
            txtOrderDate.Text = currentOrder?.OrderDate?.ToString("dd/MM/yyyy") ?? "No Order Date";
        }
       



        private void LoadCartFromDatabase(int userId)
        {
            currentUser = context.People.FirstOrDefault(p => p.Id == userId)!;

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
                    var variant = c.VariantId != 0
                        ? context.ProductVariants.FirstOrDefault(v => v.VariantId == c.VariantId)
                        : null;

                    decimal unitPrice = variant?.Price??0;

                    return new CartViewModel
                    {
                        CartId = c.CartId,
                        ProductId = c.ProductId,
                        Name = c.Product?.ProductName,
                        Quantity = c.Quantity,
                        VariantId = c.VariantId,
                        Variant = variant?.Storage ?? "N/A", // text để hiển thị
                        UnitPrice = unitPrice,
                        TotalAmount = unitPrice * c.Quantity
                    };
                }).ToList();

            cartList = new ObservableCollection<CartViewModel>(itemCart);
            dataGridOrderDetail.ItemsSource = cartList;
            dataGridOrderDetail.Items.Refresh();
        }



        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

     

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
            var selectedItems = cartList.Where(i => i.IsSelected).ToList();

            if (!selectedItems.Any())
            {
                MessageBox.Show("Please choose at least one product to order.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show("Do you want to pay via wallet?\nClick 'Yes' for wallet payment, 'No' for cash on delivery.",
                                        "Payment Method",
                                        MessageBoxButton.YesNoCancel,
                                        MessageBoxImage.Question);

            if (result == MessageBoxResult.Cancel)
                return;

            double totalCartAmount = (double)selectedItems.Sum(c => c.TotalAmount);

            if (result == MessageBoxResult.Yes && (currentUser.Balance ?? 0) < totalCartAmount)
            {
                MessageBox.Show("Insufficient wallet balance! The order cannot be processed.", "Payment Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Create a single order for all selected items
            string orderId = "O" + DateTime.Now.Ticks + new Random().Next(100, 999);
            var newOrder = new Order
            {
                ReceiverName = $"{currentUser.Fname} {currentUser.Lname}",
                ReceiverPhone = currentUser.PhoneNumber,
                ReceiverAddress = currentUser.Address,
                OrderId = orderId,
                PersonId = currentUser.Id,
                OrderDate = DateTime.Now,
                OrderStatus = result == MessageBoxResult.Yes ? "Pending" : "Processing",
                TotalMoney = totalCartAmount,
                PaymentMethod = result == MessageBoxResult.Yes ? "Wallet" : "Cash on Delivery",
                OrderAddress = currentUser.Address
            };
            context.Orders.Add(newOrder);

            // Create OrderDetail entries for each selected item
            foreach (var item in selectedItems)
            {
                string orderDetailId = "OD" + Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();
                var orderDetail = new OrderDetail
                {
                    OrderDetailId = orderDetailId,
                    OrderId = orderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    VariantId = item.VariantId.ToString() != "N/A" ? item.VariantId : null
                };
                context.OrderDetails.Add(orderDetail);

                // Update stock
                var productVariant = context.ProductVariants.FirstOrDefault(p => p.ProductId == item.ProductId && p.VariantId == item.VariantId);
                if (productVariant != null)
                {
                    productVariant.Stock -= item.Quantity;
                }
            }

            // Update wallet balance if paying via wallet
            if (result == MessageBoxResult.Yes)
            {
                currentUser.Balance -= totalCartAmount;
            }

            // Remove selected items from the cart
            foreach (var item in selectedItems)
            {
                var itemToRemove = context.Carts.FirstOrDefault(c => c.CartId == item.CartId);
                if (itemToRemove != null)
                {
                    context.Carts.Remove(itemToRemove);
                }
            }

            // Save all changes
            context.SaveChanges();

            // Trigger OnOrderCompleted event
            OnOrderCompleted?.Invoke(new ViewOrderModel
            {
                OrderId = newOrder.OrderId,
                OrderDate = newOrder.OrderDate ?? DateTime.Now,
                OrderAddress = newOrder.OrderAddress,
                TotalPrice = newOrder.TotalMoney ?? 0,
                TotalQuantity = selectedItems.Sum(i => i.Quantity),
                PhoneNumber = currentUser.PhoneNumber,
                FullName = $"{currentUser.Fname} {currentUser.Lname}",
                PaymentMethod = newOrder.PaymentMethod,
                OrderStatus = newOrder.OrderStatus
            });

            MessageBox.Show("Your order has been placed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadCartFromDatabase(currentUser.Id);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}