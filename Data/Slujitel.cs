﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avto.Data;

public partial class Slujitel
{
    public int Id { get; set; }

    [MaxLength(80)]
    public string? Name { get; set; }

    public int Number { get; set; }

    public DateTime? TekushtaData { get; set; }

    public string? User { get; set; }

    public ICollection<Transak> Transaks { get; }
}
