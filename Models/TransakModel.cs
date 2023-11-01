using Avto.Data.Enums;
using System.ComponentModel;

namespace Avto.Models;

[Description("Маршрут")]
public class TransakModel : BaseModel
{
    [DisplayName("Отдел")]
    public int OtdelId { get; set; }

    [DisplayName("Описание км")]
    public KmId KmId { get; set; }

    public int PListId { get; set; }

    public double? KmKm { get; set; }
}
