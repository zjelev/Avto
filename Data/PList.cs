using System.ComponentModel.DataAnnotations;

namespace Avto.Data;

public partial class PList
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string? Number { get; set; }

    public DateTime? Data { get; set; }

    public int? Moto { get; set; }

    public int? Slujitel { get; set; }

    //public int? Zarabotka { get; set; }

    //public int? Izvan { get; set; }

    //public int? Doma { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? User { get; set; }

    public ICollection<Transak> Transaks { get; }
}
