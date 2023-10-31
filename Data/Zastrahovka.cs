namespace Avto.Data;

public class Zastrahovka : IEntity
{
    public int Id { get; set; }

    public int MotoId { get; set; }
    public Moto Moto { get; set; }

    public DateOnly? DataStart { get; set; }

    public DateOnly? DataEnd { get; set; }

    public int TipZastrahovkaId { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? User { get; set; }
}
