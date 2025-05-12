using System;
using System.Collections.Generic;

namespace Test1.Models;

public partial class Category
{
    public string? CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
