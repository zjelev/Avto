using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Avto.Data;

public class Otdel : BaseEntity
{
    [MaxLength(50)]
    [DisplayName("Отдел")]
    public string? Name { get; set; }

    public ICollection<Transak> Transaks { get; }
}
