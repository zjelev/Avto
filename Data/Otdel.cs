using System.ComponentModel.DataAnnotations;

namespace Avto.Data;

public partial class Otdel
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string? Name { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? User { get; set; }

    public ICollection<Transak> Transaks { get; }
}
