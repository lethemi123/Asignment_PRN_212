using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test1.Model;

public partial class OrderDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string OrderDetailId { get; set; } = null!;

    public string? OrderId { get; set; }

    public string? ProductId { get; set; }

    public int? Quantity { get; set; }
    public string? VariantId { get; set; }
    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
