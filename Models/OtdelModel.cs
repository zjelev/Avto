using Avto.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Avto.Models;

[Description("Отдел")]
public class OtdelModel : BaseModel
{
    [MaxLength(50)]
    [DisplayName("Име")]
    public string? Name { get; set; }

    public ICollection<Transak> Transaks { get; }
}
