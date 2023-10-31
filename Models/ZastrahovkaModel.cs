using Avto.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Avto.Models;

public class ZastrahovkaModel : IModel
{
    [DisplayName("ID №")]
    public int Id { get; set; }

    [DisplayName("Автомобил")]
    public int MotoId { get; set; }

    [DisplayName("Автомобил")]
    public Moto Moto { get; set; }

    [DisplayName("От")]
    [Required, DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly? DataStart { get; set; }

    [DisplayName("До")]
    [Required, DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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
