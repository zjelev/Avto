using Microsoft.EntityFrameworkCore;
using Avto.Data;
using Avto.Models;
using AutoMapper;

namespace Avto.Controllers;

public class ZastrahovkiController : BaseController<ZastrahovkaModel, Zastrahovka>
{
    public ZastrahovkiController(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }

    protected override IQueryable<Zastrahovka> ApplyCustomIncludes(IQueryable<Zastrahovka> dbSet)
    {
        return dbSet.Include(z => z.Moto);
    }
    
}
