using System;
using System.Collections.Generic;

namespace ILibrary.DAL.Entities;

public partial class Author
{
    public int Code { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public virtual ICollection<Book> Books { get; } = new List<Book>();
}
