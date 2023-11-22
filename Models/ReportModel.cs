using System.ComponentModel;

namespace Avto.Models;

[Description("Отчет")]
public class ReportModel
{
    [DisplayName("Отдел")]
    public string Otdel { get; set; }

    [DisplayName("Автомобил")]
    public string Moto { get; set; }

    [DisplayName("Рег. №")]
    public string MotoNumber { get; set; }

    [DisplayName("Шофьор")]
    public string Slujitel { get; set; }

    [DisplayName("Общо км")]
    public double TotalKm { get; set; }

    [DisplayName("Общо литри")]
    public double TotalLitres { get; set; }
}
