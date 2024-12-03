using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Car
{
    public string VinNumber { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public short Year { get; set; }

    public int FuelType { get; set; }

    public int GearType { get; set; }

    public string LicensePlate { get; set; } = null!;

    public byte SeatCount { get; set; }

    public double PricePerDay { get; set; }

    public bool AvailabilityStatus { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public byte MinAge { get; set; }

    public int Kilometer { get; set; }

    public int DealershipId { get; set; }

    public virtual Dealership Dealership { get; set; } = null!;

    public virtual ICollection<Deleted> Deleteds { get; set; } = new List<Deleted>();

    public virtual FuelType FuelTypeNavigation { get; set; } = null!;

    public virtual GearType GearTypeNavigation { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
