using Avto.Data;
using Avto.Data.Enums;
using System.ComponentModel;

namespace Avto.Models;

[Description("Маршрут")]
public class TransakModel : BaseModel
{
    [DisplayName("П. лист №")]
    public int PListId { get; set; }

    [DisplayName("П. лист №")]
    public PList PList { get; set; }

    [DisplayName("Отдел")]
    public int OtdelId { get; set; }

    [DisplayName("Отдел")]
    public Otdel Otdel { get; set; }

    [DisplayName("Описание км")]
    public KmId KmId { get; set; }

    [DisplayName("км")]
    public double? KmKm { get; set; }
}
