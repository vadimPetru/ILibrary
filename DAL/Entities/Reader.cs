using System;
using System.Collections.Generic;

namespace ILibrary.DAL.Entities;

public partial class Reader
{
    public string Code { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public int? Number { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual ICollection<Issuance> Issuances { get; } = new List<Issuance>();
}
