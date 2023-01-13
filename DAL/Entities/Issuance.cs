using System;
using System.Collections.Generic;

namespace ILibrary.DAL.Entities;

public partial class Issuance
{
    public int Code { get; set; }

    public string? BookCode { get; set; }

    public string? ReaderCode { get; set; }

    public DateTime? DateOfIssue { get; set; }

    public DateTime? DateOfReturned { get; set; }

    public virtual Book? BookCodeNavigation { get; set; }

    public virtual Reader? ReaderCodeNavigation { get; set; }
}
