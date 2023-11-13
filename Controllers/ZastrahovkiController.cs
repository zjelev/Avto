using Microsoft.EntityFrameworkCore;
using Avto.Data;
using Avto.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Avto.Controllers;

public class ZastrahovkiController : BaseController<ZastrahovkaModel, Zastrahovka>
{
    public ZastrahovkiController(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }

    protected override IQueryable<Zastrahovka> ApplyCustomIncludes(IQueryable<Zastrahovka> dbSet)
    {
        // Customize the includes for ZastrahovkiController.
        return dbSet.Include(z => z.Moto);
    }
    
}
