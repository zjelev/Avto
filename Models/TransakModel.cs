using Avto.Data;
using Avto.Data.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avto.Models;

[Description("Маршрут")]
public class TransakModel : BaseModel
{
    [DisplayName("П. лист №")]
    public int PListId { get; set; }

    [DisplayName("П. лист №")]
    public PList? PList { get; set; }

    [DisplayName("Отдел")]
    public int OtdelId { get; set; }

    [DisplayName("Отдел")]
    public Otdel? Otdel { get; set; }

    [DisplayName("Описание км")]
    public KmId KmId { get; set; }

    [DisplayName("Kм")]
    public double? KmKm { get; set; }

    [DisplayName("км")]
    public double Km => (KmId == KmId.Основни || KmId == KmId.Областни || KmId == KmId.Рудник || KmId == KmId.София) ?
                 (double)KmKm : 0;

    [DisplayName("Литри")]
    public double Litres { get; set; }
}
