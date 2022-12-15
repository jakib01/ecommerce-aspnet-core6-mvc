using System;
using System.Collections.Generic;

namespace ecommerce.DAL;

public partial class Setting
{
    public int SettingId { get; set; }

    public string? Email { get; set; }

    public string? PhoneNo { get; set; }

    public string? Address { get; set; }

    public int ShippingCost { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
