using System;
using System.Collections.Generic;

namespace ecommerce.DAL;

public partial class User
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNo { get; set; }

    public string? Email { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? ShippingAddress { get; set; }

    public byte? IsAdmin { get; set; }

    public byte[]? EmailVerifiedAt { get; set; }

    public string? Password { get; set; }

    public string? RememberToken { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
