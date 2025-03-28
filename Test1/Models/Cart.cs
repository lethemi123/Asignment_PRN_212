using System;
using System.Collections.Generic;

namespace Test1.Models;

public partial class Cart
{
    public string CartId { get; set; } = null!;

    public string? ProductId { get; set; }

    public string? PersonId { get; set; }

    public int? Quantity { get; set; }

    public virtual Person? Person { get; set; }

    public virtual Product? Product { get; set; }
}
