using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test1.Model;

public partial class Product 
{
    public string ProductId { get; set; } = Guid.NewGuid().ToString();

    public string ProductName { get; set; } = null!;

    public string? ProductDescription { get; set; }

    public string? ImagePathProduct { get; set; }

    public string? CategoryId { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly? UpdatedAt { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? Category { get; set; }

    [NotMapped]
    public bool IsSelected { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
 
}
