using Avto.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avto.Data;

public class Transak : BaseEntity
{
    public int OtdelId { get; set; }
    public Otdel Otdel { get; set; }

    public KmId KmId { get; set; }

    public int PListId { get; set; }
    public PList PList { get; set; }

    public double? KmKm { get; set; }

    public double Litres { get; set; } // add it in DB as float not null 
}
