using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Avto.Data;
using AutoMapper;
using Avto.Models;

namespace Avto.Controllers;

public class PListsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public PListsController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: PLists
    public async Task<IActionResult> Index()
    {
         var lists = await _context.Lists
            .Include(pl => pl.Transaks)
            .OrderByDescending(pl => pl.Id)
            .Take(10)
            .ToListAsync();

        if (lists != null)
        {
            var listsM = _mapper.Map<List<PListModel>>(lists);
            return View(listsM);
        }

        return Problem("Entity set 'ApplicationDbContext.Lists'  is null.");
    }

    // GET: PLists/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Lists == null)
        {
            return NotFound();
        }

        var pList = await _context.Lists
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pList == null)
        {
            return NotFound();
        }

        return View(pList);
    }

    // GET: PLists/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PLists/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Number,Data,Moto,Slujitel,Zarabotka,Izvan,Doma,TekushtaData,User")] PList pList)
    {
        if (ModelState.IsValid)
        {
            _context.Add(pList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(pList);
    }

    // GET: PLists/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Lists == null)
        {
            return NotFound();
        }

        var pList = await _context.Lists.FindAsync(id);
        if (pList == null)
        {
            return NotFound();
        }
        return View(pList);
    }

    // POST: PLists/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Data,Moto,Slujitel,Zarabotka,Izvan,Doma,TekushtaData,User")] PList pList)
    {
        if (id != pList.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(pList);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PListExists(pList.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(pList);
    }

    // GET: PLists/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Lists == null)
        {
            return NotFound();
        }

        var pList = await _context.Lists
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pList == null)
        {
            return NotFound();
        }

        return View(pList);
    }

    // POST: PLists/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Lists == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Lists'  is null.");
        }
        var pList = await _context.Lists.FindAsync(id);
        if (pList != null)
        {
            _context.Lists.Remove(pList);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PListExists(int id)
    {
      return (_context.Lists?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
