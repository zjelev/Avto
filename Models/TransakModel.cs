using Avto.Data.Enums;
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
