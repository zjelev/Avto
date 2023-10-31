using Avto.Models;

namespace Avto.Data;

public class Transak
{
    public int Id { get; set; }

    //public int MotoId { get; set; }
    //public Moto Moto { get; set; }

    public int OtdelId { get; set; }
    public Otdel Otdel { get; set; }

    //public int SlujitelId { get; set; }
    //public Slujitel Slujitel { get; set; }

    public KmId KmId { get; set; }

    public int PListId { get; set; }
    public PList PList { get; set; }

    //public DateTime? DateTrans { get; set; }

    // public string? TransNumber { get; set; } // Номер на пътен лист - има го в PList

    public double? KmKm { get; set; }

    // OsnovnaTrans, RudnikTrans, OkragTrans и т.н. (12 бр.) са излишни, те са KmKм за съответното KmId

    public string? User { get; set; }

    public DateTime? TekushtaData { get; set; }
}
