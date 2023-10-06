namespace Avto.Data;

public partial class TipZastrahovka
{
    public int TipZastrahovkiId { get; set; }

    public string? TipZastrahovki1 { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? UserList { get; set; }

    public ICollection<Zastrahovka> Zastrahovki { get; }
}
