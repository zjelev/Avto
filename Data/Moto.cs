using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Avto.Data;

public partial class Moto : BaseEntity
{
    [MaxLength(50)]
    public string? Name { get; set; }

    [MaxLength(8)]
    public string? Number { get; set; }

    [DisplayName("Автомобил")]
    public string NameNumber => $"{Name} {Number}";

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

    public bool Brak { get; set; }

    public ICollection<Zastrahovka> Zastrahovki { get; }
}
