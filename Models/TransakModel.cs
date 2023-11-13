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

    [DisplayName("Текуща норма")]
    private double? CurrentNorma
    {
        get
        {
            if (PList != null)
                return KmId switch
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
                };
            else
                return 0;
        }
    }

    [DisplayName("Литри")]
    public double? Litres => Math.Round((double)(CurrentNorma * KmKm / 100), 2);
}
