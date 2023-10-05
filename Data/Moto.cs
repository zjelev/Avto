using System;
using System.Collections.Generic;

namespace Avto.Data;

public partial class Moto
{
    public int MotoId { get; set; }

    public string? MotoName { get; set; }

    public string? MotoNumber { get; set; }

    public double OsnovnaNorma { get; set; }

    public double? GradskaNorma { get; set; }

    public double? RudnikNorma { get; set; }

    public double? OkragNorma { get; set; }

    public double? StolicaNorma { get; set; }

    public double? MqstoNorma { get; set; }

    public double? KlimaNorma { get; set; }

    public double? AgregatNorma { get; set; }

    public double? KlimatikNorma { get; set; }

    public double? PechkaNorma { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? UserList { get; set; }

    public bool Brak { get; set; }
}
