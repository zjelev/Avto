using System.ComponentModel.DataAnnotations;

namespace Avto.Data;

public partial class Slujitel : BaseEntity
{
    [MaxLength(80)]
    public string? Name { get; set; }

    public int Number { get; set; }
}
