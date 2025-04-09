using System;
using System.Collections.Generic;

namespace Test1.Models;

public partial class ProductVariant
{
    public int VariantId { get; set; }

    public string? ProductId { get; set; }

    public string? Storage { get; set; }

    public decimal? Price { get; set; }

    public int? Stock { get; set; }

    public virtual Product? Product { get; set; }
}
