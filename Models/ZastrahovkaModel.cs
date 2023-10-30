using Avto.Data;
using System.ComponentModel;

namespace Avto.Models;

public class ZastrahovkaModel
{
    public int Id { get; set; }

    public int MotoId { get; set; }
    public Moto Moto { get; set; }

    public DateOnly? DataStart { get; set; }

    public DateOnly? DataEnd { get; set; }

    public int TipZastrahovkaId { get; set; }

    public TipZastrahovka TipZastrahovka { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? User { get; set; }
}

public enum TipZastrahovka
{
    [Description("Преглед")]
    Pregled = 1,
    [Description("ГО")]
    Go = 3
}
