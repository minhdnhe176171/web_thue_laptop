using System;
using System.Collections.Generic;

namespace web_thue_laptop.Models;

public partial class BookingTechnicalTicket
{
    public long Id { get; set; }

    public long BookingId { get; set; }

    public long CreatedBy { get; set; }

    public long? ApprovedBy { get; set; }

    public string? Description { get; set; }

    public string? Response { get; set; }

    public long StatusId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual User? ApprovedByNavigation { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
