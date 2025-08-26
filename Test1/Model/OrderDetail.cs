using System;
using System.Collections.Generic;

namespace Test1.Model;

public partial class OrderDetail
{
    public string OrderDetailId { get; set; } = null!;

    public string? OrderId { get; set; }

    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? VariantId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product Product { get; set; } = null!;
}
