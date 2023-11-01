using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Avto.Models;

[Description("Служител")]
public class SlujitelModel : BaseModel
{
    [MaxLength(80)]
    [DisplayName("Име")]
    public string? Name { get; set; }

    [DisplayName("Раб. №")]
    public int Number { get; set; }
}
