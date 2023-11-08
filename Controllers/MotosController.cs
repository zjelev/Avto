using Avto.Data;
using Avto.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Avto.Controllers;

public class MotosController : BaseController<MotoModel, Moto>
{
    public MotosController(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }

    public async Task<IActionResult> Index(SearchModel searchModel) => await IndexBase(searchModel);

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [FromForm] MotoModel motoModel)
    {
        ModelState.Remove("Zastrahovki");
        return await EditBase(id, motoModel);
    }
}
