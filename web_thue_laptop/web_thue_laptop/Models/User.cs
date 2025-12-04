using System;
using System.Collections.Generic;

namespace web_thue_laptop.Models;

public partial class User
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Booking> BookingApprovedByNavigations { get; set; } = new List<Booking>();

    public virtual ICollection<Booking> BookingCreatedByNavigations { get; set; } = new List<Booking>();

    public virtual ICollection<BookingTechnicalTicket> BookingTechnicalTicketApprovedByNavigations { get; set; } = new List<BookingTechnicalTicket>();

    public virtual ICollection<BookingTechnicalTicket> BookingTechnicalTicketCreatedByNavigations { get; set; } = new List<BookingTechnicalTicket>();

    public virtual ICollection<LaptopApproval> LaptopApprovals { get; set; } = new List<LaptopApproval>();

    public virtual ICollection<Laptop> LaptopApprovedByNavigations { get; set; } = new List<Laptop>();

    public virtual ICollection<Laptop> LaptopOwners { get; set; } = new List<Laptop>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
