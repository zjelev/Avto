﻿using AutoMapper;
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
        List<TransakModel> transaksModel = await GetTransaks(searchModel)
            .Select(t => _mapper.Map<TransakModel>(t))
            .ToListAsync();

        List<IGrouping<string, ReportModel>> groupByOtdelThenMoto = transaksModel
            .GroupBy(t => new { t.Otdel, Moto = t.Moto.NameNumber })
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

    public async Task<IActionResult> Drivers(SearchModel searchModel)
    {
        List<Transak> transaks = await GetTransaks(searchModel).ToListAsync();

        var transaksModel = _mapper.Map<List<TransakModel>>(transaks);

        List<IGrouping<string, ReportModel>> groupBySlujitelThenMoto = transaksModel
            .GroupBy(t => new { Slujitel = t.Slujitel.Name, Moto = t.Moto.NameNumber })
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
        List<Transak> transaks = await GetTransaks(searchModel).ToListAsync();

        var transaksModel = _mapper.Map<List<TransakModel>>(transaks);

        List<IGrouping<string, ReportModel>> groupBySlujitelThenMoto = transaksModel
            .GroupBy(t => new { Slujitel = t.Slujitel.Name, Moto = t.Moto.NameNumber })
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

        var transaks = query
            .Include(t => t.PList.Moto)
            .Include(t => t.PList.Slujitel)
            .Include(t => t.Otdel);

        return transaks;
    }
}
