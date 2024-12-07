using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record UserDtoForUpdate
    {

        public string Name { get; init; } = null!;

        public string Lastname { get; init; } = null!;

        public DateTime BirthDate { get; init; }

        public string Email { get; init; } = null!;

        public string Password { get; init; } = null!;

        public string PhoneNumber { get; init; } = null!;

        public string LicenseNumber { get; init; } = null!;

        public string Address { get; init; } = null!;
    }
}
