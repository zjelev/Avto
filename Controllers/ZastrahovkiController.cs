using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Avto.Data;
using Avto.Models;
using AutoMapper;

namespace Avto.Controllers;

public class ZastrahovkiController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ZastrahovkiController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var zastrahovki = await _context.Zastrahovki
            .Include(z => z.Moto)
            .ToListAsync();

        if (zastrahovki != null)
            return View(_mapper.Map<List<ZastrahovkaModel>>(zastrahovki));

        return Problem("Entity set 'Zastrahovki' is null.");
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Zastrahovki == null)
            return NotFound();

        var zastrahovka = await _context.Zastrahovki
            .Include(z => z.Moto)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (zastrahovka == null)
            return NotFound();

        return View(_mapper.Map<ZastrahovkaModel>(zastrahovka));
    }

    public IActionResult Create()
    {
        ViewData["MotoId"] = new SelectList(_context.Motos, "Id", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ZastrahovkaModel zastrahovkaModel)
    {
        ModelState.Remove("Moto");

        if (ModelState.IsValid)
        {
            Zastrahovka zastrahovka = _mapper.Map<Zastrahovka>(zastrahovkaModel);
            zastrahovka.TekushtaData = DateTime.Now;
            zastrahovka.User = User.Identity.Name;
            _context.Add(zastrahovka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["MotoId"] = new SelectList(_context.Motos, "Id", "Id", zastrahovkaModel.MotoId);
        return View(zastrahovkaModel);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Zastrahovki == null)
            return NotFound();

        var zastrahovka = await _context.Zastrahovki
            .Include(z => z.Moto)
            .FirstOrDefaultAsync(pl => pl.Id == id);

        if (zastrahovka == null)
            return NotFound();

        ViewData["MotoId"] = new SelectList(_context.Motos, "Id", "Name", zastrahovka.MotoId);

        var zastrahovkaModel = _mapper.Map<ZastrahovkaModel>(zastrahovka);

        return View(zastrahovkaModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [FromForm] ZastrahovkaModel zastrahovkaModel)
    {
        if (id != zastrahovkaModel.Id)
            return NotFound();

        ModelState.Remove("Moto");

        if (ModelState.IsValid)
        {
            var zastrahovka = _mapper.Map<Zastrahovka>(zastrahovkaModel);
            try
            {
                zastrahovka.TekushtaData = DateTime.Now;
                zastrahovka.User = User.Identity.Name;
                _context.Update(zastrahovka);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZastrahovkaModelExists(zastrahovka.Id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["MotoId"] = new SelectList(_context.Motos, "Id", "Id", zastrahovkaModel.MotoId);
        return View(zastrahovkaModel);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Zastrahovki == null)
            return NotFound();

        var zastrahovka = await _context.Zastrahovki
            .Include(z => z.Moto)
            .FirstOrDefaultAsync(m => m.Id == id);
        
        if (zastrahovka == null)
            return NotFound();

        return View(_mapper.Map<ZastrahovkaModel>(zastrahovka));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Zastrahovki == null)
            return Problem("Entity set 'ApplicationDbContext.ZastrahovkaModel'  is null.");

        var zastrahovka = await _context.Zastrahovki.FindAsync(id);
        if (zastrahovka != null)
            _context.Zastrahovki.Remove(zastrahovka);
        
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private bool ZastrahovkaModelExists(int id)
        => (_context.Zastrahovki?.Any(e => e.Id == id)).GetValueOrDefault();
}
