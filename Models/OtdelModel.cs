using Avto.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Avto.Models;

public class OtdelModel : IModel
{
    public int Id { get; set; }

    [MaxLength(50)]
    [DisplayName("Име")]
    public string? Name { get; set; }

    [DisplayName("Въведен на")]
    public DateTime? TekushtaData { get; set; }

    [DisplayName("От потребител")]
    public string? User { get; set; }

    public ICollection<Transak> Transaks { get; }
}
