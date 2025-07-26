using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Model
{
    public class OrderBillViewModel
    {
        public string OrderBillId { get; set; }
        public string OrderBillName { get; set; }
        public string OrderPhone { get; set; }
        public string OrderEmail { get; set; }
        public double TotalPrice { get; set; }   // ← THÊM DÒNG NÀY
        public string OrderCreatAt { get; set; }
        public string OrderCreateUpdate { get; set; }
        public string ContentOrderBill { get; set; }
        public string Status { get; set; }
    }


}
