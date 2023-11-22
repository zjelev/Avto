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
    public double Litres => (PList != null) ?
            (double)(KmId switch
            {
                KmId.Основни => PList.Moto.OsnovnaNorma,
                KmId.Областни => PList.Moto.OkragNorma,
                KmId.Рудник => PList.Moto.RudnikNorma,
                KmId.София => PList.Moto.StolicaNorma,
                KmId.Ремарке => 0,
                KmId.Място => PList.Moto.MqstoNorma,
                KmId.Климатик => PList.Moto.KlimatikNorma,
                KmId.Агрегат => PList.Moto.AgregatNorma,
                KmId.Климатроник => PList.Moto.KlimaNorma,
                KmId.Печка => PList.Moto.PechkaNorma,
                _ => 0
            } * KmKm / 100) : 0;
}
