using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record CarDtoForUpdate
    {

        public string? Brand { get; init; }

        public string? Model { get; init; }

        public short Year { get; init; }

        public int FuelType { get; init; }

        public int GearType { get; init; }

        public string? LicensePlate { get; init; }

        public byte SeatCount { get; init; }

        public double PricePerDay { get; init; }

        public bool AvailabilityStatus { get; init; }

        public byte MinAge { get; init; }

        public int Kilometer { get; init; }

        public int DealershipId { get; init; }

    }
}
