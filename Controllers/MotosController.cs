using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Avto.Data;
using Avto.Models;
using AutoMapper;

namespace Avto.Controllers;

public class MotosController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public MotosController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var motos = await _context.Motos.ToListAsync();
        return motos != null ? 
                    View(_mapper.Map<List<MotoModel>>(motos)) :
                    Problem("Entity set 'Motos' is null.");
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MotoModel motoModel)
    {
        if (ModelState.IsValid)
        {
            Moto moto = _mapper.Map<Moto>(motoModel);
            moto.TekushtaData = DateTime.Now;
            moto.User = User.Identity.Name;
            _context.Add(moto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(motoModel);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Motos == null)
            return NotFound();

        var moto = await _context.Motos.FindAsync(id);
        if (moto == null)
            return NotFound();

        return View(_mapper.Map<MotoModel>(moto));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [FromForm] MotoModel motoModel)
    {
        if (id != motoModel.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            var moto = _mapper.Map<Moto>(motoModel);
            try
            {
                moto.TekushtaData = DateTime.Now;
                moto.User = User.Identity.Name;
                _context.Update(moto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoModelExists(motoModel.Id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(motoModel);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Motos == null)
            return NotFound();

        var moto = await _context.Motos
            .FirstOrDefaultAsync(m => m.Id == id);
        
        if (moto == null)
            return NotFound();

        return View(_mapper.Map<MotoModel>(moto));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Motos == null)
            return Problem("Entity set 'ApplicationDbContext.Motos'  is null.");

        var moto = await _context.Motos.FindAsync(id);
        if (moto != null)
            _context.Motos.Remove(moto);
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MotoModelExists(int id) =>
      (_context.Motos?.Any(e => e.Id == id)).GetValueOrDefault();
}
