namespace Avto.Data;

public partial class List
{
    public int ListId { get; set; }

    public string? ListNumber { get; set; }

    public DateTime? ListData { get; set; }

    public double? ListMoto { get; set; }

    public double? ListSlujitel { get; set; }

    public double? ListZarabotka { get; set; }

    public double? ListIzvan { get; set; }

    public double? ListDoma { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? UserList { get; set; }

    public ICollection<Transak> Transaks { get; }
}
