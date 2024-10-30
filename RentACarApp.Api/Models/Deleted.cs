using System;
using System.Collections.Generic;

namespace RentACarApp.Api.Models;

public partial class Deleted
{
    public int Id { get; set; }

    public string CarId { get; set; } = null!;

    public DateTime DeleteTime { get; set; }

    public string? AdminId { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual Car Car { get; set; } = null!;
}
