using System;
using System.Collections.Generic;

namespace ecommerce.DAL;

public partial class Product
{
    public int ProductId { get; set; }

    public int BrandId { get; set; }

    public string? ProductCode { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Slug { get; set; }

    public string? Unit { get; set; }

    public string? Size { get; set; }

    public string? Color { get; set; }

    public string? Quantity { get; set; }

    public int? Price { get; set; }

    public int? OfferPrice { get; set; }

    public byte? Status { get; set; }

    public byte? IsCurrent { get; set; }

    public byte? IsDelete { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual ICollection<ProductCategoryMapping> ProductCategoryMappings { get; } = new List<ProductCategoryMapping>();

    public virtual ICollection<ProductImage> ProductImages { get; } = new List<ProductImage>();
}
