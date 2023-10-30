using Avto.Data;
using System.ComponentModel;

namespace Avto.Models;

public class ZastrahovkaModel
{
    [DisplayName("ID №")]
    public int Id { get; set; }

    [DisplayName("Автомобил")]
    public int MotoId { get; set; }

    [DisplayName("Автомобил")]
    public Moto Moto { get; set; }

    [DisplayName("От")]
    public DateOnly? DataStart { get; set; }

    [DisplayName("До")]
    public DateOnly? DataEnd { get; set; }

    [DisplayName("Тип")]
    public TipZastrahovkaId TipZastrahovkaId { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? User { get; set; }
}

public enum TipZastrahovkaId
{
    Преглед = 1,
    ГО = 3
}
