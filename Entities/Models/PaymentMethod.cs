using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
