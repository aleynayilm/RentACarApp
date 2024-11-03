using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class ReservationStatus
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
