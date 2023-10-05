using System;
using System.Collections.Generic;

namespace Avto.Data;

public partial class Norma
{
    public int Id { get; set; }

    public double? NormaKlimatronik { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? UserList { get; set; }
}
