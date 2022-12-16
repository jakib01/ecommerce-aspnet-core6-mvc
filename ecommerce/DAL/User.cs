using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ecommerce.Models;

namespace ecommerce.DAL;

public partial class User
{
    public int UserId { get; set; }

    [Required]
    [StringLength(100)]
    public string? FirstName { get; set; }

    [StringLength(100)]
    public string? LastName { get; set; }

    [Required]
    [UserUniqueAttribute]
    [Column("phoneNo", TypeName = "varchar(254)")]
    public string? PhoneNo { get; set; }

    [Required]
    [EmailAddress]
    [EmailUserUniqueAttribute]
    [Column("email", TypeName = "varchar(254)")]
    public string? Email { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? ShippingAddress { get; set; }

    public byte? IsAdmin { get; set; }

    public DateTime? EmailVerifiedAt { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    //[Required]
    //[DataType(DataType.Password)]
    //public string? RePassword { get; set; }

    public string? RememberToken { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

}
