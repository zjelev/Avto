using System;
using System.Collections.Generic;

namespace Avto.Data;

public partial class Slujiteli
{
    public int SlujitelId { get; set; }

    public string? SlujitelName { get; set; }

    public int SlujitelNumber { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? UserList { get; set; }
}
