﻿using AutoMapper;
using Avto.Data;

namespace Avto.Models;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Transak, TransakModel>();
        
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
