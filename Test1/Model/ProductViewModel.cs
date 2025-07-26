using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Model
{
    public class ProductViewModel
    {
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int Stock { get; set; }  // Thuộc tính Stock
        public double Price { get; set; }  // Thuộc tính Price
        public string? Storage { get; set; }  // Thuộc tính Categories (hoặc Storage nếu là tên cột)
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? ImagePathProduct { get; set; }
        
        public bool IsSelected { get; set; }
    }

}
