namespace Avto.Data;

public class BaseEntity : IEntity
{
    public int Id { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? User { get; set; }
}
