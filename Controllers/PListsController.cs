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
        // Customize the includes for ZastrahovkiController.
        return dbSet
            .Include(pl => pl.Moto)
            .Include(pl => pl.Slujitel)
            .Include(pl => pl.Transaks)
                .ThenInclude(t => t.Otdel)
            .Include(pl => pl.Transaks)
            .OrderByDescending(pl => pl.Id)
            .Take(100);
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

    public async Task<IActionResult> Search(SearchModel searchModel)
    {
        // Perform the search based on the criteria in searchModel

        // Build the query to filter the data from database

        // Return the filtered data to the view
        var filteredData = _context.Lists.FirstOrDefault(); // Query the database
        return View("Index", filteredData);
    }
}
