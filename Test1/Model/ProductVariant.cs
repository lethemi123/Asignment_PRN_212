using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test1.Model;

public  class ProductVariant
{
   
    public int  VariantId { get; set; }

    public string? ProductId { get; set; }

    public string? Storage { get; set; }
  
    public decimal? Price { get; set; }

    public int? Stock { get; set; }

    public virtual Product Product { get; set; } = null!;
}
