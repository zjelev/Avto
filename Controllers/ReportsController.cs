using AutoMapper;
using Avto.Data;
using Microsoft.AspNetCore.Mvc;

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

    public IActionResult Index()
    {
        return View();
    }
}
