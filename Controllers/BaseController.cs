using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Avto.Data;
using AutoMapper;
using Avto.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Avto.Controllers;

public class BaseController<TModel, TEntity> : Controller where TModel : class where TEntity : class, IEntity
{
    protected readonly ApplicationDbContext _context;
    protected readonly IMapper _mapper;

    public BaseController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    protected virtual IQueryable<TEntity> ApplyCustomIncludes(DbSet<TEntity> dbSet)
    {
        // By default, do nothing. Subclasses can override this method to customize includes.
        return dbSet;
    }

    public async Task<IActionResult> Index()
    {
        var query = _context.Set<TEntity>();
        var items = await ApplyCustomIncludes(query).ToListAsync();
        return items != null ?
            View(_mapper.Map<List<TModel>>(items)) :
            Problem($"Entity set '{typeof(TEntity).Name}' is null.");
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var entity = await ApplyCustomIncludes(_context.Set<TEntity>())
            .FirstOrDefaultAsync(e => e.Id == id);

        if (entity == null)
            return NotFound();

        return View(_mapper.Map<TModel>(entity));
    }

    public IActionResult Create()
    {
        // Zastrahovki:
        ViewData["MotoId"] = new SelectList(_context.Motos, "Id", "Name");
        // Plists
        ViewData["Motos"] = new SelectList(_context.Motos.Where(m => !m.Brak), "Id", "NumberAndName");
        ViewData["Slujiteli"] = new SelectList(_context.Slujiteli, "Id", "Name");
        ViewData["Km"] = new SelectList(_context.Kilometris, "Id", "Name");
        ViewData["Otdeli"] = new SelectList(_context.Otdels, "Id", "Name");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TModel model)
    {
        // Zastrahovki:
        ModelState.Remove("Moto");
        // Plists
        ModelState.Remove("Transaks");

        if (ModelState.IsValid)
        {
            var entity = _mapper.Map<TEntity>(model);
            entity.TekushtaData = DateTime.Now;
            entity.User = User.Identity.Name;
            _context.Add(entity); // For PLists // In SSMS delete FK_Transaks_Motos_MotoId & FK_Transaks_Slujiteli_SlujitelId
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        // Zastrahovki
        ViewData["MotoId"] = new SelectList(_context.Motos, "Id", "Name"); // Zastrahovki
        // Plists
        ViewData["Motos"] = new SelectList(_context.Motos.Where(m => !m.Brak), "Id", "NumberAndName");
        ViewData["Slujiteli"] = new SelectList(_context.Slujiteli, "Id", "Name");
        ViewData["Km"] = new SelectList(_context.Kilometris, "Id", "Name");
        ViewData["Otdeli"] = new SelectList(_context.Otdels, "Id", "Name");

        return View(model);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var entity = await ApplyCustomIncludes(_context.Set<TEntity>()).Where(e => e.Id == id).FirstOrDefaultAsync();

        if (entity == null)
            return NotFound();

        // Zastrahovki
        ViewData["MotoId"] = new SelectList(_context.Motos, "Id", "Name");
        // Plists
        ViewData["Motos"] = new SelectList(_context.Motos.Where(m => !m.Brak), "Id", "NumberAndName");
        ViewData["Slujiteli"] = new SelectList(_context.Slujiteli, "Id", "Name");
        ViewData["Km"] = new SelectList(_context.Kilometris, "Id", "Name");
        ViewData["Otdeli"] = new SelectList(_context.Otdels, "Id", "Name");

        return View(_mapper.Map<TModel>(entity));
    }

    public async Task<IActionResult> EditBase(int id, [FromForm] IModel model)
    {
        if (id != model.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            var entity = _mapper.Map<TEntity>(model);
            try
            {
                entity.TekushtaData = DateTime.Now;
                entity.User = User.Identity.Name;
                _context.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var entity = await ApplyCustomIncludes(_context.Set<TEntity>()).Where(e => e.Id == id).FirstOrDefaultAsync();

        if (entity == null)
            return NotFound();

        return View(_mapper.Map<TModel>(entity));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!EntityExists(id))
            return NotFound();

        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity != null)
            _context.Remove(entity);

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    internal bool EntityExists(int id) =>
        _context.Set<TEntity>().Any(e => e.Id == id);
}

