using Avto.Data;
using Avto.Model;
using System.ComponentModel;

namespace Avto.Models;

public class PListModel
{
    [DisplayName("ID №")]
    public int Id { get; set; }

    [DisplayName("Пътен лист №")]
    public string? Number { get; set; }

    [DisplayName("Дата")]
    public DateTime? Data { get; set; }

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
}
