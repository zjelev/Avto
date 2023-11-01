using Avto.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Avto.Models;

[Description("Пътен лист")]
public class PListModel : BaseModel
{
    public PListModel()
    {
        TransaksModel = new List<TransakModel> { new TransakModel() };
    }

    [DisplayName("Пътен лист №")]
    public string? Number { get; set; }

    [Required, DisplayName("От"), DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly? Data { get; set; }

    [DisplayName("Автомобил")]
    public int MotoId { get; set; }

    [DisplayName("Автомобил")]
    public Moto? Moto { get; set; }

    [DisplayName("Служител")]
    public int SlujitelId { get; set; }

    [DisplayName("Служител")]
    public Slujitel? Slujitel { get; set; }

    [DisplayName("Маршрут")]
    public IList<TransakModel> TransaksModel { get; set; }

    [DisplayName("Вид | Отдел | км")]
    public ICollection<Transak> Transaks { get; set; }
}
