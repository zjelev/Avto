using Avto.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Avto.Models;

public class PListModel
{
    [DisplayName("ID №")]
    public int Id { get; set; }

    [DisplayName("Пътен лист №")]
    public string? Number { get; set; }

    [Required, DisplayName("От"), DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly? Data { get; set; }

    [DisplayName("Автомобил")]
    public Moto? Moto { get; set; }

    [DisplayName("Служител")]
    public Slujitel? Slujitel { get; set; }

    [DisplayName("Въведен на")]
    public DateTime? TekushtaData { get; set; }

    [DisplayName("От")]
    public string? User { get; set; }

    [DisplayName("Маршрут")]
    public ICollection<Transak> Transaks { get; set; }

    [DisplayName("Въведи маршрут")]
    public TransakModel Transak { get; set; }
}
