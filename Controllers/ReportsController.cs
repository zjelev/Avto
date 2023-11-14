using AutoMapper;
using Avto.Data;
using Avto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Avto.Controllers;

public class ReportsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ReportsController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(int monthsBack)
    {
        var baseDate = DateTime.Today.AddDays(-monthsBack);
        var monthStart = new DateTime(baseDate.Year, baseDate.Month, 1);
        var monthEnd = monthStart.AddMonths(1).AddDays(-1);
        
        var query = _context.Transaks
            .Where(l => l.PList.Data >= monthStart && l.PList.Data <= monthEnd)
            .Include(t => t.PList)
                .ThenInclude(pl => pl.Moto)
            .Include(t => t.PList)
                .ThenInclude(pl => pl.Slujitel)
            .Include(t => t.Otdel);

        var groupByOtdel = await query
            .GroupBy(g => g.Otdel.Name)
            .ToDictionaryAsync(ng => ng.Key, ng => ng.AsEnumerable());

        return View(groupByOtdel);
    }
}
