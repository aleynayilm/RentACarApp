using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Dealership
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
