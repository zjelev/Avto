using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Avto.Models;

[Description("Търсене")]
public class SearchModel : BaseModel
{
    [DisplayName("Пътен лист №")]
    public string Number { get; set; } //= string.Empty;

    [Required, DisplayName("От"), DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly? From { get; set; } // = DateOnly.FromDateTime(DateTime.MinValue);

    [Required, DisplayName("До"), DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly? To { get; set; } // = DateOnly.FromDateTime(DateTime.MaxValue);

    [DisplayName("Марка автомобил")]
    public string MotoName { get; set; } //= string.Empty;

    [DisplayName("Рег. №")]
    public string MotoNumber { get; set; } //= string.Empty;

    [DisplayName("Раб. № шофьор")]
    public int SlujitelId { get; set; } //= 0;

    [DisplayName("Име шофьор")]
    public string SlujitelName { get; set; } //= string.Empty;

    [DisplayName("Отдел")]
    public int OtdelId { get; set; } //= 0;
    
    [DisplayName("Отдел")]
    public string Otdel { get; set; } //= string.Empty;

    [DisplayName("Вид маршрут")]
    public string Route { get; set; } //= string.Empty;

    [DisplayName("Минимум км")]
    public int KmMin { get; set; } //= 0;

    [DisplayName("Максимум км")]
    public int KmMax { get; set; } //= 0;

    public int Page { get; set; } = 1;

    public int TotalPages { get; set; } = 1;

}
