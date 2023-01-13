using System;
using System.Collections.Generic;

namespace ILibrary.DAL.Entities;

public partial class Book
{
    public string Code { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int? AuthorCode { get; set; }

    public int? PublishingCode { get; set; }

    public DateTime? PublishingYear { get; set; }

    public decimal? Price { get; set; }

    public int? Volume { get; set; }

    public virtual Author? AuthorCodeNavigation { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual ICollection<Issuance> Issuances { get; } = new List<Issuance>();

    public virtual Publishing? PublishingCodeNavigation { get; set; }
}
