using Microsoft.EntityFrameworkCore;
using Avto.Data;
using AutoMapper;
using Avto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Avto.Controllers;

public class PListsController : BaseController<PListModel, PList>
{
    public PListsController(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }

    protected override IQueryable<PList> ApplyCustomIncludes(DbSet<PList> dbSet)
    {
        // Customize the includes for this Controller.
        return dbSet.Include(pl => pl.Transaks);
    }

    // Aplly custom Index with search
    public async Task<IActionResult> Index(SearchModel searchModel)
    {
        int pageSize = 100;
        int pageNumber = searchModel.Page;

        ViewData["Title"] = string.Join(" ", PluralizePhraze(_modelDescription));
        ViewData["Search"] = searchModel;
        ViewData["Page"] = pageNumber;
        ViewData["CallingIndexView"] = "PLists";

        var query = _context.Lists
            .Where(l => l.Data > DateTime.Today.AddYears(-3));

        if (!string.IsNullOrEmpty(searchModel.Number))
            query = query.Where(l => l.Number.Contains(searchModel.Number));

        if (searchModel.From.HasValue)
            query = query.Where(l => l.Data >= ToNullableDateTime(searchModel.From.Value));

        if (searchModel.To.HasValue)
            query = query.Where(l => l.Data <= ToNullableDateTime(searchModel.To.Value));

        if (!string.IsNullOrEmpty(searchModel.MotoName))
            query = query.Where(l => l.Moto.Name.Contains(searchModel.MotoName));

        if (!string.IsNullOrEmpty(searchModel.MotoNumber))
            query = query.Where(l => l.Moto.Number.Contains(searchModel.MotoNumber));

        if (searchModel.SlujitelId != 0)
            query = query.Where(l => l.Slujitel.Number == searchModel.SlujitelId);

        if (!string.IsNullOrEmpty(searchModel.SlujitelName))
            query = query.Where(l => l.Slujitel.Name.Contains(searchModel.SlujitelName));

        query = query
            .Include(pl => pl.Moto)
            .Include(pl => pl.Slujitel)
            .Include(pl => pl.Transaks)
            .ThenInclude(t => t.Otdel);

        ViewData["TotalPages"] = (int)Math.Ceiling((double)query.Count() / pageSize);

        var pagedData = await query
            .OrderByDescending(pl => pl.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var mappedData = _mapper.Map<List<PListModel>>(pagedData);

        return View(mappedData);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [FromForm] PListModel pListModel)
    {
        ViewData["Motos"] = new SelectList(_context.Motos.Where(m => !m.Brak), "Id", "NumberAndName");
        ViewData["Slujiteli"] = new SelectList(_context.Slujiteli, "Id", "Name");
        ViewData["Otdeli"] = new SelectList(_context.Otdels, "Id", "Name");

        ModelState.Remove("Transaks");

        return await EditBase(id, pListModel);
    }
}
