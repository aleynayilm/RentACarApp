using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class PaymentStatus
{
    public int Id { get; set; }

    public bool IsSuccessful { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
