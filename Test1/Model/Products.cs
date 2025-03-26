using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Model
{
    public class Products
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductId { get; set; }
        public bool IsSelected { get; set; }
        public string? CateGoryID { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; } 

        public string?   ImangePathProduct { get; set; }

        public DateTime CreatAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public string? Status { get; set; }

        
}
    }
