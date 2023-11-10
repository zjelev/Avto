using System.ComponentModel.DataAnnotations;

namespace Avto.Data.Enums;

public enum KmId
{
    [Display(Name="Основни км")]
    Основни = 1,
    [Display(Name="Областни градове км")]
    Областни = 2,
    [Display(Name="Рудник км")]
    Рудник = 3,
    [Display(Name="София км")]
    София = 4,
    [Display(Name="Теглене ремарке")]
    Ремарке = 5,
    [Display(Name="Работа на място")]
    Място = 6, 
    [Display(Name="Работа с климатик")]
    Климатик = 7,
    [Display(Name="Работа с агрегат")]
    Агрегат = 8,
    [Display(Name="Работа с климатроник")]
    Климатроник = 14,
    [Display(Name="Работа с печка")]
    Печка = 15
}
