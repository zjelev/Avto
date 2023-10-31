using System.ComponentModel;

namespace Avto.Data.Enums;

public enum KmId
{
    [Description("Основни км")]
    Основни = 1,
    [Description("Областни градове км")]
    Рудник = 2,
    [Description("Рудник км")]
    Областни = 3,
    [Description("София км")]
    София = 4,
    [Description("Теглене ремарке")]
    Ремарке = 5,
    [Description("Работа на място")]
    Място = 6, 
    [Description("Работа с климатик")]
    Климатик = 7,
    [Description("Работа с агрегат")]
    Агрегат = 8,
    [Description("Работа с климатроник")]
    Климатроник = 14,
    [Description("Работа с печка")]
    Печка = 15
}
