using System.ComponentModel.DataAnnotations;

namespace Avto.Data;

public class Otdel : BaseEntity
{
    [MaxLength(50)]
    public string? Name { get; set; }

    public ICollection<Transak> Transaks { get; }
}
