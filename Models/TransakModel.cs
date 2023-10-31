using System.ComponentModel;

namespace Avto.Models;

public class TransakModel
{
    public int Id { get; set; }

    [DisplayName("Отдел")]
    public int OtdelId { get; set; }

    //[DisplayName("Отдел")]
    //public Otdel Otdel { get; set; }

    [DisplayName("Описание км")]
    public KmId KmId { get; set; }

    //[DisplayName("Описание км")]
    //public Kilometri Km { get; set; }

    public int PListId { get; set; }

    public double? KmKm { get; set; }

    public string? User { get; set; }

    public DateTime? TekushtaData { get; set; }
}

public enum KmId
{
    Основни = 1,
    Рудник = 2,
    Областни = 3,
    София = 4,
    Ремарке = 5,
    Място = 6,
    Климатик = 7,
    Агрегат = 8,
    Климатроник = 14,
    Печка = 15
}
