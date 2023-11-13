using Avto.Data;
using Avto.Data.Enums;
using System.ComponentModel;

namespace Avto.Models;

[Description("Отчет")]
public class ReportModel
{
    [DisplayName("Автомобил")]
    public string MotoNumberAndName { get; set; }

    [DisplayName("Шофьор")]
    public string? SlujitelName { get; set; }

    [DisplayName("Отдел")]
    public string OtdelName { get; set; }

    [DisplayName("Описание км")]
    public KmId KmId { get; set; }

    [DisplayName("км")]
    public double? KmKm { get; set; }

    [DisplayName("Литри")]
    public double? Litres { get; set; }
}
