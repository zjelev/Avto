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

        List<IGrouping<string, ReportModel>> groupByOtdelThenMoto = transaksModel
            .GroupBy(t => new { Otdel = t.Otdel.Name, Moto = t.PList.Moto.NameNumber })
            .Select(group => new ReportModel
            {
                Otdel = group.Key.Otdel,
                Moto = group.Key.Moto,
                TotalKm = group.Sum(t => t.Km),
                TotalLitres = Math.Round(group.Sum(t => t.Litres), 2)
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

        var from = searchModel.From != null ? ViewService.ToNullableDateTime(searchModel.From) 
            : DateTime.Today.AddMonths(-1);

        var to = searchModel.To != null ? ViewService.ToNullableDateTime(searchModel.To)
            : DateTime.Now;

        ViewData["Title"] = "Отчет за периода " + from.ToString("d") + " - " + to.ToString("d");

        IQueryable<Transak> query = _context.Transaks
            .Where(l => l.PList.Data >= from && l.PList.Data <= to);

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
