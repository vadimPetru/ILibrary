using System;
using System.Collections.Generic;

namespace ILibrary.DAL.Entities;

public partial class City
{
    public int Code { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Publishing> Publishings { get; } = new List<Publishing>();
}
