namespace Avto.Data;

public interface IEntity
{
    int Id { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? User { get; set; }
}
