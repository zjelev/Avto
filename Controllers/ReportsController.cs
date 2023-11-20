using AutoMapper;
using Avto.Data;
using Avto.Models;
using Avto.Services;
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

    public async Task<IActionResult> Index(SearchModel searchModel)
    {
        List<Transak> transaks = await GetTransaks(searchModel).ToListAsync();

        var transaksModel = _mapper.Map<List<TransakModel>>(transaks);

        var groupByOtdelThenMoto = transaksModel
            .GroupBy(t => new { Otdel = t.Otdel.Name, Moto = t.PList.Moto.NameNumber })
            .Select(group => new ReportModel
            {
                Otdel = group.Key.Otdel,
                Moto = group.Key.Moto,
                TotalKm = group.Sum(t => t.Km),
                TotalLitres = Math.Round(group.Sum(t => t.Litres), 2),
                Transaks = group.ToList()
            })
            .GroupBy(result => result.Otdel)
            .ToList();

        return View(groupByOtdelThenMoto);
    }

    public async Task<IActionResult> Otdeli(SearchModel searchModel)
    {
        List<Transak> transaks = await GetTransaks(searchModel).ToListAsync();

        var groupByOtdel = transaks
            .GroupBy(t => t.Otdel.Name)
            .ToDictionary(ng => ng.Key, ng => ng.AsEnumerable());

        return View(groupByOtdel);
    }

    private IQueryable<Transak> GetTransaks(SearchModel searchModel)
    {
        ViewData["CallingIndexView"] = ControllerContext.ActionDescriptor.ControllerName;
        var baseDate = DateTime.Today.AddMonths(-searchModel.MonthsBack);
        var monthStart = new DateTime(baseDate.Year, baseDate.Month, 1);
        var monthEnd = monthStart.AddMonths(1).AddDays(-1);
        var yearStart = new DateTime(baseDate.Year, 1, 1);

        ViewData["Title"] = "Отчет по отдели от ";
        if (searchModel.From == null)
            ViewData["Title"] += yearStart.ToString("D");
        else
            ViewData["Title"] += searchModel.From.ToString();

        if (searchModel.To == null)
            ViewData["Title"] += " до " + DateTime.Now.ToString("D");
        else
            ViewData["Title"] += " до " + searchModel.To.ToString();

        IQueryable<Transak> query = _context.Transaks
            .Where(l => l.PList.Data >= yearStart
            //monthStart && l.PList.Data <= monthEnd
            );

        if (searchModel.From.HasValue)
            query = query.Where(l => l.PList.Data >= ViewService.ToNullableDateTime(searchModel.From.Value));

        if (searchModel.To.HasValue)
            query = query.Where(l => l.PList.Data <= ViewService.ToNullableDateTime(searchModel.To.Value));

        if (!string.IsNullOrEmpty(searchModel.MotoName))
            query = query.Where(l => l.PList.Moto.Name.Contains(searchModel.MotoName));

        if (!string.IsNullOrEmpty(searchModel.MotoNumber))
            query = query.Where(l => l.PList.Moto.Number.Contains(searchModel.MotoNumber));

        var transaks = query
            .Include(t => t.PList.Moto)
            .Include(t => t.PList.Slujitel)
            .Include(t => t.Otdel);

        return transaks;
    }
}
