using System;
using System.Collections.Generic;

namespace Avto.Data;

public partial class Otdel
{
    public int OtdelId { get; set; }

    public string? OtdelName { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? UserList { get; set; }
}
