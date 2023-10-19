using Avto.Data;

namespace Avto.Model;

public class TransakModel
{
    public int Id { get; set; }

    public int OtdelId { get; set; }
    public Otdel Otdel { get; set; }

    public int KmId { get; set; }
    public Kilometri Km { get; set; }

    public int PListId { get; set; }
    public PList PList { get; set; }

    public DateTime? DateTrans { get; set; }

    public string? TransNumber { get; set; }

    public double? KmKm { get; set; }

    public string? User { get; set; }

    public DateTime? TekushtaData { get; set; }
}
