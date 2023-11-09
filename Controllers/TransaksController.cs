﻿using AutoMapper;
using Avto.Data;
using Avto.Models;
using Microsoft.AspNetCore.Mvc;
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
        var query = _context.Transaks.
            Where(l => l.PList.Data > DateTime.Today.AddYears(-1));

        if (!string.IsNullOrEmpty(searchModel.Otdel))
            query = query.Where(t => t.Otdel.Name.Contains(searchModel.Otdel));

        return query;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [FromForm] SlujitelModel slujitelModel) => await EditBase(id, slujitelModel);
}