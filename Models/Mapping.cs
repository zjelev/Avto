using AutoMapper;
using Avto.Data;

namespace Avto.Models;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Transak, TransakModel>()
            .ForMember(dest => dest.PListNumber, opt => opt.MapFrom(src => src.PList.Number))
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.PList.Data))
            .ForMember(dest => dest.Otdel, opt => opt.MapFrom(src => src.Otdel.Name))
            .ForMember(dest => dest.Moto, opt => opt.MapFrom(src => src.PList.Moto))
            .ForMember(dest => dest.Slujitel, opt => opt.MapFrom(src => src.PList.Slujitel));

        CreateMap<TransakModel, Transak>();

        CreateMap<PList, PListModel>()
            .ForMember(dest => dest.TransaksModel, opt => opt.MapFrom(src => src.Transaks.ToList()));

        CreateMap<PListModel, PList>()
            .ForMember(dest => dest.Transaks, opt => opt.MapFrom(src => src.TransaksModel.ToList()));
        
        CreateMap<DateTime, DateOnly>().ConvertUsing<DateTimeToDateOnlyConverter>();
        CreateMap<DateOnly, DateTime>().ConvertUsing<DateOnlyToDateTimeConverter>();

        CreateMap<Zastrahovka, ZastrahovkaModel>();

        CreateMap<ZastrahovkaModel, Zastrahovka>();

        CreateMap<Moto, MotoModel>();

        CreateMap<MotoModel, Moto>();

        CreateMap<Otdel, OtdelModel>();

        CreateMap<OtdelModel, Otdel>();

        CreateMap<Slujitel, SlujitelModel>();

        CreateMap<SlujitelModel, Slujitel>();

    }
}
