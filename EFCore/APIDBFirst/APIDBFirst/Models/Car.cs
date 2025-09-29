using System;
using System.Collections.Generic;

namespace APIDBFirst.Models;

public partial class Car
{
    public int CarId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Year { get; set; }

    public int? ManufacturerId { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }
}
