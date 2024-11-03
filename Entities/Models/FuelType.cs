using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class FuelType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
