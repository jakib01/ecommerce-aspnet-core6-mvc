using System;
using System.Collections.Generic;

namespace ecommerce.DAL;

public partial class Category
{
    public int CategoryId { get; set; }

    public int? ParentId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<ProductCategoryMapping> ProductCategoryMappings { get; } = new List<ProductCategoryMapping>();
}
