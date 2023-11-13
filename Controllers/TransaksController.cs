using AutoMapper;
using Avto.Data;
using Avto.Models;
using Microsoft.EntityFrameworkCore;

namespace Avto.Controllers;

public class TransaksController : BaseController<TransakModel, Transak>
{
    public TransaksController(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }

    protected override IQueryable<Transak> ApplyCustomIncludes(IQueryable<Transak> dbSet)
    {
        return dbSet.
            Include(t => t.PList)
                .ThenInclude(pl => pl.Moto)
            .Include(t => t.PList)
                .ThenInclude(pl => pl.Slujitel)
            .Include(t => t.Otdel);
    }

    protected override IQueryable<Transak> ApplyCustomSearch(SearchModel searchModel)
    {
        var query = _context.Transaks
            .Where(l => l.PList.Data > DateTime.Today.AddYears(-1));

        if (!string.IsNullOrEmpty(searchModel.Number))
            query = query.Where(l => l.PList.Number.Contains(searchModel.Number));

        if (searchModel.From.HasValue)
            query = query.Where(l => l.PList.Data >= ToNullableDateTime(searchModel.From.Value));

        if (searchModel.To.HasValue)
            query = query.Where(l => l.PList.Data <= ToNullableDateTime(searchModel.To.Value));

        if (!string.IsNullOrEmpty(searchModel.MotoName))
            query = query.Where(l => l.PList.Moto.Name.Contains(searchModel.MotoName));

        if (!string.IsNullOrEmpty(searchModel.MotoNumber))
            query = query.Where(l => l.PList.Moto.Number.Contains(searchModel.MotoNumber));

        if (!string.IsNullOrEmpty(searchModel.SlujitelName))
            query = query.Where(l => l.PList.Slujitel.Name.Contains(searchModel.SlujitelName));

        if (!string.IsNullOrEmpty(searchModel.Otdel))
            query = query.Where(t => t.Otdel.Name.Contains(searchModel.Otdel));

        return query;
    }
}