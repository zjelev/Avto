using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avto.Data;

public partial class Moto
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [MaxLength(50)]
    public string? Name { get; set; }

    [MaxLength(8)]
    public string? Number { get; set; }

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

    public string? User { get; set; }

    public bool Brak { get; set; }

    public ICollection<Transak> Transaks { get; }

    public ICollection<Zastrahovka> Zastrahovki { get; }
}
