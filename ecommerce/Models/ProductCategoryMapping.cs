using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class ProductCategoryMapping
{
    public int ProductCategoryMappingId { get; set; }

    public int CategoryId { get; set; }

    public int ProductId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public byte? IsCurrent { get; set; }

    public byte? IsDelete { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
