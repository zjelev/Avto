using Avto.Data;
using Avto.Models;
using AutoMapper;

namespace Avto.Controllers;

public class SlujiteliController : BaseController<SlujitelModel, Slujitel>
{
    public SlujiteliController(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }

}
