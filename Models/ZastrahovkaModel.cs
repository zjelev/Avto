﻿using Avto.Data;
using Avto.Data.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Avto.Models;

[Description("Застраховка")]
public class ZastrahovkaModel : BaseModel
{
    [DisplayName("Автомобил")]
    public int MotoId { get; set; }

    [DisplayName("Автомобил")]
    public Moto Moto { get; set; }

    [DisplayName("От")]
    [Required, DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly? DataStart { get; set; }

    [DisplayName("До")]
    [Required, DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly? DataEnd { get; set; }

    [DisplayName("Тип")]
    public TipZastrahovkaId TipZastrahovkaId { get; set; }
}
