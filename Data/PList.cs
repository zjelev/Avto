using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avto.Data;

public partial class PList
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [MaxLength(50)]
    public string? Number { get; set; }

    public DateTime? Data { get; set; }

    public double? Moto { get; set; }

    public double? Slujitel { get; set; }

    public double? Zarabotka { get; set; }

    public double? Izvan { get; set; }

    public double? Doma { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? User { get; set; }

    public ICollection<Transak> Transaks { get; }
}
