using AutoMapper;

namespace Avto.Models;

public class DateTimeToDateOnlyConverter : ITypeConverter<DateTime, DateOnly>
{
    public DateOnly Convert(DateTime source, DateOnly destination, ResolutionContext context)
            => new DateOnly(source.Year, source.Month, source.Day);
}
