using Avto.Data;
using Avto.Models;
using AutoMapper;

namespace Avto.Controllers;

public class MotosController : BaseController<MotoModel, Moto>
{
    public MotosController(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }

}
