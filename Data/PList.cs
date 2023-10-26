using System.ComponentModel.DataAnnotations;

namespace Avto.Data;

public class PList
{
    public PList()
    {
        Transaks = new HashSet<Transak>();
    }

    public int Id { get; set; }

    [MaxLength(50)]
    public string? Number { get; set; }

    public DateTime? Data { get; set; }

    public int MotoId { get; set; }
    public Moto Moto { get; set; }


    public int SlujitelId { get; set; }
    public Slujitel Slujitel { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? User { get; set; }

    public ICollection<Transak> Transaks { get; }
}
