using System;
using System.Collections.Generic;

namespace web_thue_laptop.Models;

public partial class Booking
{
    public long Id { get; set; }

    public long LaptopId { get; set; }

    public int TotalTime { get; set; }

    public long CreatedBy { get; set; }

    public long? ApprovedBy { get; set; }

    public long StatusId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual User? ApprovedByNavigation { get; set; }

    public virtual ICollection<BookingTechnicalTicket> BookingTechnicalTickets { get; set; } = new List<BookingTechnicalTicket>();

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Laptop Laptop { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
