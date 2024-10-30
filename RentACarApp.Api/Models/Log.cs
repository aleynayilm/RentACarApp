using System;
using System.Collections.Generic;

namespace RentACarApp.Api.Models;

public partial class Log
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string? UserId { get; set; }

    public string? AdminId { get; set; }

    public string Messaage { get; set; } = null!;

    public virtual Admin? Admin { get; set; }

    public virtual User? User { get; set; }
}
