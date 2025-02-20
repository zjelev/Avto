﻿using Microsoft.EntityFrameworkCore;
using Avto.Data;
using AutoMapper;
using Avto.Models;
using Avto.Services;

namespace Avto.Controllers;

public class PListsController : BaseController<PListModel, PList>
{
    public PListsController(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }

    protected override IQueryable<PList> ApplyCustomIncludes(IQueryable<PList> dbSet)
    {
        // Customize the includes for this Controller's actions.
        return dbSet
            .Include(pl => pl.Transaks)
            .Include(pl => pl.Moto)
            .Include(pl => pl.Slujitel)
            .Include(pl => pl.Transaks)
                .ThenInclude(t => t.Otdel);
    }

    protected override IQueryable<PList> ApplyCustomSearch(SearchModel searchModel)
    {
        var query = _context.Lists
            .Where(l => l.Data > DateTime.Today.AddYears(-3));

        if (!string.IsNullOrEmpty(searchModel.Number))
            query = query.Where(l => l.Number.Contains(searchModel.Number));

        if (searchModel.From.HasValue)
            query = query.Where(l => l.Data >= ViewService.ToNullableDateTime(searchModel.From.Value));

        if (searchModel.To.HasValue)
            query = query.Where(l => l.Data <= ViewService.ToNullableDateTime(searchModel.To.Value));

        if (!string.IsNullOrEmpty(searchModel.MotoName))
            query = query.Where(l => l.Moto.Name.Contains(searchModel.MotoName));

        if (!string.IsNullOrEmpty(searchModel.MotoNumber))
            query = query.Where(l => l.Moto.Number.Contains(searchModel.MotoNumber));

        if (searchModel.SlujitelId != 0)
            query = query.Where(l => l.Slujitel.Number == searchModel.SlujitelId);

        if (!string.IsNullOrEmpty(searchModel.SlujitelName))
            query = query.Where(l => l.Slujitel.Name.Contains(searchModel.SlujitelName));

        return query;
    }

}
