using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int ReservationId { get; set; }

    public decimal Amount { get; set; }

    public int PaymentMethod { get; set; }

    public DateTime PaymentDate { get; set; }

    public int PaymentStatus { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual PaymentMethod PaymentMethodNavigation { get; set; } = null!;

    public virtual PaymentStatus PaymentStatusNavigation { get; set; } = null!;

    public virtual Reservation Reservation { get; set; } = null!;
}
