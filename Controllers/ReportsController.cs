using AutoMapper;
using Avto.Data;
using Avto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        List<TransakModel> transaksModel = GetTransaks(monthsBack);

        var groupByOtdelThenMoto = transaksModel
            .GroupBy(t => new { Otdel = t.Otdel.Name, Moto = t.PList.Moto.NameNumber })
            .Select(group => new ReportModel
            {
                Otdel = group.Key.Otdel,
                Moto = group.Key.Moto,
                TotalKm = group.Sum(t => t.Km),
                TotalLitres = group.Sum(t => t.Litres),
                Transaks = group.ToList()
            })
            .GroupBy(result => result.Otdel)
            .ToList();
        //.ToDictionaryAsync(ng => ng.Key, ng => ng.AsEnumerable());

        ViewData["Title"] = "Отчет по отдели и автомобили";
        return View(groupByOtdelThenMoto);
    }

    public async Task<IActionResult> Otdeli(int monthsBack)
    {
        List<TransakModel> transaksModel = GetTransaks(monthsBack);

        var groupByOtdel = transaksModel
            .GroupBy(t => t.Otdel.Name)
            .ToDictionary(ng => ng.Key, ng => ng.AsEnumerable());

        return View(groupByOtdel);
    }

    private List<TransakModel> GetTransaks(int monthsBack)
    {
        var baseDate = DateTime.Today.AddMonths(-monthsBack);
        var monthStart = new DateTime(baseDate.Year, baseDate.Month, 1);
        var monthEnd = monthStart.AddMonths(1).AddDays(-1);

        var transaks = _context.Transaks
            .Where(l => l.PList.Data >= monthStart && l.PList.Data <= monthEnd)
            .Include(t => t.PList.Moto)
            .Include(t => t.PList.Slujitel)
            .Include(t => t.Otdel);

        var transaksModel = _mapper.Map<List<TransakModel>>(transaks);
        return transaksModel;
    }
}
