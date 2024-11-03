using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string CarId { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal TotalPrice { get; set; }

    public int Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ReservationStatus StatusNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
