using System;
using System.Collections.Generic;

namespace APIDBFirst.Models;

public partial class Manufacturer
{
    public int ManufacturerId { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
