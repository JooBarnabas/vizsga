using System;
using System.Collections.Generic;

namespace _20_EF_Library.Models;

public partial class Types
{
    public int TypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
