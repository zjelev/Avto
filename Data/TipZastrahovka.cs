using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avto.Data;

public partial class TipZastrahovka
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [MaxLength(255)]
    public string? Name { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? User { get; set; }

    public ICollection<Zastrahovka> Zastrahovki { get; }
}
