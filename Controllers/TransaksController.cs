using AutoMapper;
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

    public async Task<IActionResult> Index(SearchModel searchModel)
    {
        int pageSize = 100;
        int pageNumber = searchModel.Page;

        ViewData["Title"] = string.Join(" ", PluralizePhraze(_modelDescription));
        ViewData["Search"] = searchModel;
        ViewData["CallingIndexView"] = "Transaks";

        IQueryable<Transak> query = _context.Transaks;
        //.Where(l => l.PList.Data > DateTime.Today.AddYears(-1));

        if (!string.IsNullOrEmpty(searchModel.Otdel))
            query = query.Where(t => t.OtdelId == 3);

        searchModel.TotalPages = (int)Math.Ceiling((double)query.Count() / pageSize);
        
        var pagedData = await query
            .OrderByDescending(t => t.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var mappedData = _mapper.Map<List<TransakModel>>(pagedData);

        return View(mappedData);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [FromForm] SlujitelModel slujitelModel) => await EditBase(id, slujitelModel);
}