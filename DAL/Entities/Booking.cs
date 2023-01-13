using System;
using System.Collections.Generic;

namespace ILibrary.DAL.Entities;

public partial class Booking
{
    public int Code { get; set; }

    public string? BookCode { get; set; }

    public string? ReaderCode { get; set; }

    public DateTime? DateOfOrder { get; set; }

    public virtual Book? BookCodeNavigation { get; set; }

    public virtual Reader? ReaderCodeNavigation { get; set; }
}
