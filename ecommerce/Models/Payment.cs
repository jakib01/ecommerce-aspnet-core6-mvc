using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public string? Name { get; set; }

    public string? Image { get; set; }

    public byte Priority { get; set; }

    public string? ShortName { get; set; }

    public string? PaymentNo { get; set; }

    public string? TransectionType { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
