﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Avto.Data;

public partial class Norma
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public double? NormaKlimatronik { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? User { get; set; }
}
