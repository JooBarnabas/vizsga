using System;
using System.Collections.Generic;

namespace RealEstate3.Models;

public partial class Category
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Realestate> Realestates { get; set; } = new List<Realestate>();
}
