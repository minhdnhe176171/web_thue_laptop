using System;
using System.Collections.Generic;

namespace web_thue_laptop.Models;

public partial class Status
{
    public long Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<BookingTechnicalTicket> BookingTechnicalTickets { get; set; } = new List<BookingTechnicalTicket>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<LaptopApproval> LaptopApprovals { get; set; } = new List<LaptopApproval>();

    public virtual ICollection<Laptop> Laptops { get; set; } = new List<Laptop>();
}
