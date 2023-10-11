using AutoMapper;
using Avto.Data;

namespace Avto.Models;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<PList, PListModel>();
    }
}
