using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _20_EF_Library.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string? Gender { get; set; }

    public string? Class { get; set; }

    public int? Point { get; set; }

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();


    [NotMapped]
    public string Fullname { get { return Name + " " + Surname; } }
}
