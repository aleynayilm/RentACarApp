using System;
using System.Collections.Generic;

namespace RentACarApp.Api.Models;

public partial class GearType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
