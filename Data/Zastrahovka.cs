using System;
using System.Collections.Generic;

namespace Avto.Data;

public partial class Zastrahovka
{
    public int ZastrahovkiId { get; set; }

    public int? MotoId { get; set; }

    public DateTime? DataStart { get; set; }

    public DateTime? DataEnd { get; set; }

    public int? TipZastrahovkaId { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? UserList { get; set; }
}
