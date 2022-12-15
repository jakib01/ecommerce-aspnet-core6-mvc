using System;
using System.Collections.Generic;

namespace ecommerce.DAL;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public int? PaymentId { get; set; }

    public string? IpAddress { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public string ShippingAddress { get; set; } = null!;

    public string? Email { get; set; }

    public string? Message { get; set; }

    public byte IsPaid { get; set; }

    public byte IsCompleted { get; set; }

    public byte IsSeenByAdmin { get; set; }

    public string? TransactionId { get; set; }

    public int? TotalPrice { get; set; }

    public int? TotalPriceWithShippingCost { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual Payment? Payment { get; set; }

    public virtual User? User { get; set; }
}
