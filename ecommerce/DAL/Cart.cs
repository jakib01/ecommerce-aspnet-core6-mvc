using System;
using System.Collections.Generic;

namespace ecommerce.DAL;

public partial class Cart
{
    public int CartId { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    public int? OrderId { get; set; }

    public string? IpAddress { get; set; }

    public int? ProductQuantity { get; set; }

    public string? ProductUnit { get; set; }

    public string? Color { get; set; }

    public string? ProdictSize { get; set; }

    public int? ProductCode { get; set; }

    public int? UnitPrice { get; set; }

    public int? UnitTotalPrice { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
