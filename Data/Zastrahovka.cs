namespace Avto.Data;

public class Zastrahovka : BaseEntity
{
    public int MotoId { get; set; }
    public Moto Moto { get; set; }

    public DateOnly? DataStart { get; set; }

    public DateOnly? DataEnd { get; set; }

    public int TipZastrahovkaId { get; set; }
}
