using Avto.Data;
using System.ComponentModel;

namespace Avto.Models;

public class ListInputModel
{
    [DisplayName("ID №")]
    public int? ListId { get; set; }

    [DisplayName("Автомобил")]
    public int? MotoId { get; set; }

    [DisplayName("Служител")]
    public int? SlujitelId { get; set; }

    [DisplayName("Пътен лист №")]
    public string? TransNumber { get; set; }

    [DisplayName("Дата")]
    public DateTime? DateTrans { get; set; }

    [DisplayName("Заработка")]
    public double? Zarabotka { get; set; }

    [DisplayName("Изв.труд")]
    public double? Izvan { get; set; }

    [DisplayName("Дом.дежурство")]
    public double? Doma { get; set; }

    [DisplayName("Движение")]
    public ICollection<Zastrahovka> Zastrahovki { get; set; }

}
