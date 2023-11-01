using System.ComponentModel;

namespace Avto.Models;

public class BaseModel : IModel
{
    [DisplayName("ID №")]
    public int Id { get; set; }

    [DisplayName("Въведен на")]
    public DateTime? TekushtaData { get; set; }

    [DisplayName("От")]
    public string? User { get; set; }
}
