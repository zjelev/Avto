using AutoMapper;

namespace Avto.Models;

public class DateTimeToDateOnlyConverter : ITypeConverter<DateTime, DateOnly>
{
    public DateOnly Convert(DateTime source, DateOnly destination, ResolutionContext context)
            => new DateOnly(source.Year, source.Month, source.Day);
}

public class DateOnlyToDateTimeConverter : ITypeConverter<DateOnly, DateTime>
{
    public DateTime Convert(DateOnly source, DateTime destination, ResolutionContext context)
            => new DateTime(source.Year, source.Month, source.Day);
}
