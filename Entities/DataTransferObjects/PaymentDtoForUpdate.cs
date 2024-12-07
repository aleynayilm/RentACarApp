using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record PaymentDtoForUpdate
    {

        public int ReservationId { get; init; }

        public decimal Amount { get; init; }

        public int PaymentMethod { get; init; }

        public DateTime PaymentDate { get; init; }

        public int PaymentStatus { get; init; }
    }
}
