using AutoMapper;
using Avto.Data;
using Avto.Model;

namespace Avto.Models;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Transak, TransakModel>();

        CreateMap<PList, PListModel>()
            .ForMember(dest => dest.Transaks, opt => opt.MapFrom(src => src.Transaks.ToList()));
    }
}
