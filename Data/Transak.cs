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

    public int KmId { get; set; }
    public Kilometri Km { get; set; }

    public int PListId { get; set; }
    public PList PList { get; set; }

    //public DateTime? DateTrans { get; set; }

    // public string? TransNumber { get; set; } // Номер на пътен лист - има го в PList

    public double? KmKm { get; set; }

    // Всички тези са излишни, те са KmKм за съответното KmId
    //public double? OsnovnaTrans { get; set; }

    //public double? RudnikTrans { get; set; }

    //public double? OkragTrans { get; set; }

    //public double? StolicaTrans { get; set; }

    //public double? GradskaTrans { get; set; }

    //public double? MqstoTrans { get; set; }

    //public double? KlimaTrans { get; set; }

    //public double? AgregatTrans { get; set; }

    //public double? Zarabotka { get; set; }

    //public double? Izvan { get; set; }

    //public double? Doma { get; set; }

    //public double? KlimatikTrans { get; set; }

    //public double? PechkaTrans { get; set; }

    public string? User { get; set; }

    public DateTime? TekushtaData { get; set; }
}
