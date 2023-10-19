using AutoMapper;
using Avto.Data;

namespace Avto.Models;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Transak, TransakModel>();

        CreateMap<PList, PListModel>()
            .ForMember(dest => dest.Transaks, opt => opt.MapFrom(src => src.Transaks.ToList()))
            .ForMember(dest => dest.Moto, opt => opt.MapFrom(src => src.Transaks.FirstOrDefault().Moto))
            .ForMember(dest => dest.Slujitel, opt => opt.MapFrom(src => src.Transaks.FirstOrDefault().Slujitel));

        CreateMap<DateTime, DateOnly>().ConvertUsing<DateTimeToDateOnlyConverter>();
    }
}
