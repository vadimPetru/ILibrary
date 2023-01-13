using System;
using System.Collections.Generic;

namespace ILibrary.DAL.Entities;

public partial class Publishing
{
    public int Code { get; set; }

    public string Title { get; set; } = null!;

    public int? CityCode { get; set; }

    public virtual ICollection<Book> Books { get; } = new List<Book>();

    public virtual City? CityCodeNavigation { get; set; }
}
