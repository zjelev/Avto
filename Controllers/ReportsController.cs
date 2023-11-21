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
        var transaksModel = await GetTransaks(searchModel)
            .Include(t => t.PList.Moto)
            .Include(t => t.Otdel)
            .Select(t => new TransakModel()
            {
                KmId = t.KmId,
                KmKm = t.KmKm,
                OtdelId = t.OtdelId,
                OtdelName = t.Otdel.Name,
                PListId = t.PListId,
                Data = t.PList.Data,
                MotoId = t.PList.MotoId,
                Moto = t.PList.Moto,
                OsnovnaNorma = t.PList.Moto.OsnovnaNorma,
                GradskaNorma = t.PList.Moto.GradskaNorma,
                RudnikNorma = t.PList.Moto.RudnikNorma,
                OkragNorma = t.PList.Moto.OkragNorma,
                StolicaNorma = t.PList.Moto.StolicaNorma,
                MqstoNorma = t.PList.Moto.MqstoNorma,
                KlimaNorma = t.PList.Moto.KlimaNorma,
                AgregatNorma = t.PList.Moto.AgregatNorma,
                KlimatikNorma = t.PList.Moto.KlimatikNorma,
                PechkaNorma = t.PList.Moto.PechkaNorma
            })
            .ToListAsync();

        //var transaksModel = _mapper.Map<List<TransakModel>>(transaks);

        List<IGrouping<string, ReportModel>> groupByOtdelThenMoto = transaksModel
            .GroupBy(t => new { Otdel = t.OtdelName, Moto = t.MotoNameNumber })
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
        List<Transak> transaks = await GetTransaks(searchModel)
            .Include(t => t.Otdel)
            .ToListAsync();

        var groupByOtdel = transaks
            .GroupBy(t => t.Otdel.Name)
            .ToDictionary(ng => ng.Key, ng => ng.AsEnumerable());

        return View(groupByOtdel);
    }

    public async Task<IActionResult> Drivers(SearchModel searchModel)
    {
        List<Transak> transaks = await GetTransaks(searchModel)
            .Include(t => t.PList.Moto)
            .Include(t => t.PList.Slujitel)
            .ToListAsync();

        var transaksModel = _mapper.Map<List<TransakModel>>(transaks);

        List<IGrouping<string, ReportModel>> groupBySlujitelThenMoto = transaksModel
            .GroupBy(t => new { Slujitel = t.PList.Slujitel.Name, Moto = t.PList.Moto.NameNumber })
            .Select(group => new ReportModel
            {
                Slujitel = group.Key.Slujitel,
                Moto = group.Key.Moto,
                TotalKm = group.Sum(t => t.Km),
                TotalLitres = Math.Round(group.Sum(t => t.Litres), 2)
            })
            .GroupBy(result => result.Slujitel)
            .ToList();

        return View(groupBySlujitelThenMoto);
    }

    public async Task<IActionResult> Motos(SearchModel searchModel)
    {
        List<Transak> transaks = await GetTransaks(searchModel)
            .Include(t => t.PList.Moto)
            .Include(t => t.PList.Slujitel)
            .ToListAsync();

        var transaksModel = _mapper.Map<List<TransakModel>>(transaks);

        List<IGrouping<string, ReportModel>> groupBySlujitelThenMoto = transaksModel
            .GroupBy(t => new { Slujitel = t.PList.Slujitel.Name, Moto = t.PList.Moto.NameNumber })
            .Select(group => new ReportModel
            {
                Slujitel = group.Key.Slujitel,
                Moto = group.Key.Moto,
                TotalKm = group.Sum(t => t.Km),
                TotalLitres = Math.Round(group.Sum(t => t.Litres), 2)
            })
            .GroupBy(result => result.Moto)
            .ToList();

        return View(groupBySlujitelThenMoto);
    }

    private IQueryable<Transak> GetTransaks(SearchModel searchModel)
    {
        ViewData["CallingIndexView"] = ControllerContext.ActionDescriptor.ControllerName;
        ViewData["FormAction"] = ControllerContext.ActionDescriptor.ActionName;

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

        if (searchModel.SlujitelId != 0)
            query = query.Where(l => l.PList.SlujitelId == searchModel.SlujitelId);
        
        if (!string.IsNullOrEmpty(searchModel.SlujitelName))
            query = query.Where(l => l.PList.Slujitel.Name.Contains(searchModel.SlujitelName));

        return query;
    }
}
