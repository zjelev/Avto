using Avto.Data;
using Avto.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Avto.Controllers;

public class SlujiteliController : BaseController<SlujitelModel, Slujitel>
{
    public SlujiteliController(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }

    public async Task<IActionResult> Index(SearchModel searchModel) => await IndexBase(searchModel);

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [FromForm] SlujitelModel slujitelModel) => await EditBase(id, slujitelModel);
}
