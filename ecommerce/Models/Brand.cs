using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
