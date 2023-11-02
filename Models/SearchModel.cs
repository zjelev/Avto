using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Avto.Models;

[Description("Пътен лист")]
public class SearchModel : BaseModel
{
    [DisplayName("Пътен лист №")]
    public string? Number { get; set; }

    [Required, DisplayName("От"), DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly? Data { get; set; }

    [DisplayName("Автомобил")]
    public string? Moto { get; set; }

    [DisplayName("Раб. № шофьор")]
    public int? SlujitelId { get; set; }

    [DisplayName("Име шофьор")]
    public string? Slujitel { get; set; }

    [DisplayName("Отдел")]
    public string? Otdel { get; set; }

    [DisplayName("Вид маршрут")]
    public string? Route { get; set; }

    [DisplayName("Минимум км")]
    public int? KmMin { get; set; }

    [DisplayName("Максимум км")]
    public int? KmMax { get; set; }
}
