using Avto.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Avto.Models;

[Description("Автомобил")]
public class MotoModel : BaseModel
{
    [MaxLength(50)]
    [DisplayName("Марка")]
    public string? Name { get; set; }

    [MaxLength(8)]
    [DisplayName("Рег. №")]
    public string? Number { get; set; }

    public string NumberAndName => $"{Number} - {Name}";

    [DisplayName("Осн. норма")]
    public double OsnovnaNorma { get; set; }

    [DisplayName("Градска норма")]
    public double? GradskaNorma { get; set; }

    [DisplayName("Норма рудник")]
    public double? RudnikNorma { get; set; }

    [DisplayName("Норма обл. град")]
    public double? OkragNorma { get; set; }

    [DisplayName("Норма София")]
    public double? StolicaNorma { get; set; }

    [DisplayName("Норма на място")]
    public double? MqstoNorma { get; set; }

    [DisplayName("Норма климатроник")]
    public double? KlimaNorma { get; set; }

    [DisplayName("Норма агрегат")]
    public double? AgregatNorma { get; set; }

    [DisplayName("Норма климатик")]
    public double? KlimatikNorma { get; set; }

    [DisplayName("Норма печка")]
    public double? PechkaNorma { get; set; }

    [DisplayName("Бракуван")]
    public bool Brak { get; set; }

    public ICollection<Zastrahovka> Zastrahovki { get; }
}
