using System;
using System.Collections.Generic;

namespace Test1.Models;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public string? PersonId { get; set; }

    public string? OrderAddress { get; set; }

    public double? TotalMoney { get; set; }

    public string? OrderStatus { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Person? Person { get; set; }
}
