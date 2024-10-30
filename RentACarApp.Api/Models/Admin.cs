using System;
using System.Collections.Generic;

namespace RentACarApp.Api.Models;

public partial class Admin
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Deleted> Deleteds { get; set; } = new List<Deleted>();

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
