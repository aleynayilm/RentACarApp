﻿using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class User
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

    public string LicenseNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
