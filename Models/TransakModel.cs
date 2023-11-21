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
    public string? PListNumber { get; set; }

    [DisplayName("Автомобил")]
    public Moto Moto { get; set; }

    [DisplayName("Служител")]
    public Slujitel Slujitel { get; set; }

    [DisplayName("Дата")]
    public DateTime? Data { get; set; }

    [DisplayName("Отдел")]
    public int OtdelId { get; set; }

    [DisplayName("Отдел")]
    public string Otdel { get; set; }

    [DisplayName("Описание км")]
    public KmId KmId { get; set; }

    [DisplayName("Kм")]
    public double? KmKm { get; set; }

    [DisplayName("км")]
    public double Km 
    { 
        get
        {
            if (KmId == KmId.Основни || KmId == KmId.Областни || KmId == KmId.Рудник || KmId == KmId.София)
                return (double)KmKm;
            
            return 0;
        }
    }

    [DisplayName("Норма км")]
    private double? NormaKm
    {
        get
        {
            if (PListId != 0)
                return KmId switch
                {
                    KmId.Основни => Moto.OsnovnaNorma,
                    KmId.Областни => Moto.OkragNorma,
                    KmId.Рудник => Moto.RudnikNorma,
                    KmId.София => Moto.StolicaNorma,
                    _ => 0
                };
            else
                return 0;
        }
    }

    [DisplayName("Допълнителна норма")]
    private double? NormaOther
    {
        get
        {
            if (PListId != 0)
                return KmId switch
                {
                    KmId.Ремарке => 0,
                    KmId.Място => Moto.MqstoNorma,
                    KmId.Климатик => Moto.KlimatikNorma,
                    KmId.Агрегат => Moto.AgregatNorma,
                    KmId.Климатроник => Moto.KlimaNorma,
                    KmId.Печка => Moto.PechkaNorma,
                    _ => 0
                };
            else
                return 0;
        }
    }

    [DisplayName("Литри")]
    public double Litres => Math.Round((double)((NormaKm + NormaOther) * KmKm / 100), 2);
}
