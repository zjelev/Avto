using Avto.Data;
using Avto.Data.Enums;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Avto.Models;

[Description("Маршрут")]
public class TransakModel : BaseModel
{
    [DisplayName("П. лист №")]
    public int PListId { get; set; }

    [DisplayName("П. лист №")]
    public PList? PList { get; set; }

    [DisplayName("П. лист дата")]
    public DateTime? Data { get; set; }

    [DisplayName("Отдел")]
    public int OtdelId { get; set; }

    [DisplayName("Отдел")]
    public Otdel? Otdel { get; set; }

    [DisplayName("Отдел")]
    public string OtdelName { get; set; }

    [DisplayName("Автомобил")]
    public int MotoId { get; set; }

    [DisplayName("Автомобил")]
    public Moto Moto { get; set; }

    [DisplayName("Марка")]
    public string MotoName => $"{Moto.Name}";

    [DisplayName("Рег. №")]
    public string MotoNumber => $"{Moto.Number}";

    [DisplayName("Описание км")]
    public KmId KmId { get; set; }

    [DisplayName("Автомобил")]
    public string MotoNameNumber => $"{MotoName} {MotoNumber}";

    [DisplayName("Осн. норма")]
    public double OsnovnaNorma { get; set; }

    [DisplayName("Градска норма")]
    public double? GradskaNorma { get; set; }

    [DisplayName("Норма рудник")]
    public double? RudnikNorma { get; set; }

    [DisplayName("Норма обл. град")]
    public double? OkragNorma { get; set; }

    [DisplayName("Норма София")]
    public double? StolicaNorma { get; set; }

    [DisplayName("Норма на място")]
    public double? MqstoNorma { get; set; }

    [DisplayName("Норма климатроник")]
    public double? KlimaNorma { get; set; }

    [DisplayName("Норма агрегат")]
    public double? AgregatNorma { get; set; }

    [DisplayName("Норма климатик")]
    public double? KlimatikNorma { get; set; }

    [DisplayName("Норма печка")]
    public double? PechkaNorma { get; set; }

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
