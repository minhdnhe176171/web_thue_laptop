using System;
using System.Collections.Generic;

namespace web_thue_laptop.Models;

public partial class Brand
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<LaptopApproval> LaptopApprovals { get; set; } = new List<LaptopApproval>();

    public virtual ICollection<Laptop> Laptops { get; set; } = new List<Laptop>();
}
