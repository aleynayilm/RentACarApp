using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record ReservationsDtoForCreate
    {
        public string UserId { get; init; } = null!;

        public string CarId { get; init; } = null!;

        public DateTime StartDate { get; init; }

        public DateTime EndDate { get; init; }

        public decimal TotalPrice { get; init; }

        public int Status { get; init; }
    }
}
