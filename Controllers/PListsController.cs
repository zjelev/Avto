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

    // Aplly custom Index with search
    public async Task<IActionResult> Index(SearchModel searchModel, int? page)
    {
        ViewData["Title"] = string.Join(" ", PluralizePhraze(_modelDescription));

        // Paging
        int pageNumber = page ?? 1;
        int pageSize = 100;

        // Perform the search based on the criteria in searchModel
        var query = _context.Lists.Where(l => l.Data > DateTime.Today.AddYears(-3));

        if (searchModel.Number != null)
            query = query.Where(l => l.Number.Contains(searchModel.Number));

        if (searchModel.From != null)
            query = query.Where(l => (DateTime)l.Data >= ToNullableDateTime(searchModel.From));

        if (searchModel.To != null)
            query = query.Where(l => (DateTime)l.Data <= ToNullableDateTime(searchModel.To));

        if (searchModel.MotoName != null)
            query = query.Where(l => l.Moto.Name.Contains(searchModel.MotoName));

        if (searchModel.MotoNumber != null)
            query = query.Where(l => l.Moto.Number.Contains(searchModel.Number));

        if (searchModel.SlujitelId != 0)
            query = query.Where(l => l.Slujitel.Number == searchModel.SlujitelId);
        
        if (searchModel.SlujitelName != null)
            query = query.Where(l => l.Slujitel.Name.Contains(searchModel.SlujitelName));

        // Include navigation properties
        // Build the query to filter the data from database
        query = query
            .Include(pl => pl.Moto)
            .Include(pl => pl.Slujitel)
            .Include(pl => pl.Transaks)
                .ThenInclude(t => t.Otdel)
            .Include(pl => pl.Transaks);

        // Calculate the number of records to skip
        int recordsToSkip = (pageNumber - 1) * pageSize;

        // Apply paging using Take and Skip
        var pagedData = query
            .Skip(recordsToSkip)
            .Take(pageSize)
            .OrderByDescending(pl => pl.Id)
            .ToList();

        var mappedData = _mapper.Map<List<PListModel>>(pagedData);

        // Return the filtered data to the view
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
