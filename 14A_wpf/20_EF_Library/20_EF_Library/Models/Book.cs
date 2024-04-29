using System;
using System.Collections.Generic;

namespace _20_EF_Library.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? Name { get; set; }

    public int? Pagecount { get; set; }

    public int? Point { get; set; }

    public int? AuthorId { get; set; }

    public int? TypeId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();

    public virtual Types? Types { get; set; }
}
