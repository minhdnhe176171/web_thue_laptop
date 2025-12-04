using System;
using System.Collections.Generic;

namespace web_thue_laptop.Models;

public partial class Laptop
{
    public long Id { get; set; }

    public long OwnerId { get; set; }

    public string LaptopName { get; set; } = null!;

    public long LaptopBrand { get; set; }

    public decimal? PricePerHour { get; set; }

    public long StatusId { get; set; }

    public string? ImgUrl { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? ApprovedBy { get; set; }

    public virtual User? ApprovedByNavigation { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Brand LaptopBrandNavigation { get; set; } = null!;

    public virtual User Owner { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
