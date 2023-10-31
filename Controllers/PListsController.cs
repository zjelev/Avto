using Microsoft.EntityFrameworkCore;
using Avto.Data;
using AutoMapper;
using Avto.Models;

namespace Avto.Controllers;

public class PListsController : BaseController<PListModel, PList>
{
    public PListsController(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }

    protected override IQueryable<PList> ApplyCustomIncludes(DbSet<PList> dbSet)
    {
        // Customize the includes for ZastrahovkiController.
        return dbSet
            .Include(pl => pl.Moto)
            .Include(pl => pl.Slujitel)
            .Include(pl => pl.Transaks)
                .ThenInclude(t => t.Otdel)
            .Include(pl => pl.Transaks)
                .ThenInclude(t => t.Km)
            .OrderByDescending(pl => pl.Id)
            .Take(100);
    }
}
