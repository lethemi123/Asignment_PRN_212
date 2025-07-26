using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Model
{
    public class ViewOrderModel
    {
        public string? Id { get; set; }
        public string? OrderId { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? OrderAddress { get; set; }
        public int? TotalQuantity { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string? PaymentMethod { get; set; }
        public string? OrderStatus { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverPhone { get; set; }
        public string? ReceiverAddress { get; set; }
        public string? Description { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } // Thêm thuộc tính này
        public string? ContentOrder { get; set; }

    }
}
