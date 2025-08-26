using System;
using System.Collections.Generic;

namespace Test1.Model;

public partial class Cart
{
    public int CartId { get; set; }

    public int ProductId { get; set; }

    public int VariantId { get; set; }

    public int? PersonId { get; set; }

    public int Quantity { get; set; }

    public bool? IsSelected { get; set; }

    public virtual Person? Person { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ProductVariant? Variant { get; set; }
}
