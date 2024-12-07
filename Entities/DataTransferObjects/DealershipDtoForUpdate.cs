using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record DealershipDtoForUpdate
    {
        public string Name { get; init; } = null!;

        public string Address { get; init; } = null!;

        public string Phone { get; init; } = null!;
    }
}
