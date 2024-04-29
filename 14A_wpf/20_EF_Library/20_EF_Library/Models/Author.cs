using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _20_EF_Library.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();


    [NotMapped]
    public string Fullname { get { return string.Format("{0} {1}", Name, Surname); }  }
}
