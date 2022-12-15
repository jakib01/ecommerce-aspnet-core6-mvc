using System;
using System.Collections.Generic;

namespace ecommerce.DAL;

public partial class ProductImage
{
    public int ProductImageId { get; set; }

    public int ProductId { get; set; }

    public string? ImageUrl { get; set; }

    public byte? IsCurrent { get; set; }

    public byte? IsDelete { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
