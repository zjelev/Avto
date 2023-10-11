using System.ComponentModel.DataAnnotations;

namespace Avto.Data;

public partial class TipZastrahovka
{
    public int Id { get; set; }

    [MaxLength(255)]
    public string? Name { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? User { get; set; }

    public ICollection<Zastrahovka> Zastrahovki { get; }
}
