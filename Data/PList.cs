using System.ComponentModel.DataAnnotations;

namespace Avto.Data;

public class PList
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string? Number { get; set; }

    public DateTime? Data { get; set; }

    public int? Moto { get; set; }

    public int? Slujitel { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? User { get; set; }

    public ICollection<Transak> Transaks { get; }
}
