using Microsoft.AspNetCore.Mvc;
using Avto.Data;
using Avto.Models;
using AutoMapper;

namespace Avto.Controllers;

public class OtdelsController : BaseController<OtdelModel, Otdel>
{
    public OtdelsController(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [FromForm] OtdelModel otdelModel)
    {
        ModelState.Remove("Transaks");
        return await EditBase(id, otdelModel);
    }
}
