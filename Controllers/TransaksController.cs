using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Avto.Data;

namespace Avto.Controllers;

public class TransaksController : Controller
{
    private readonly ApplicationDbContext _context;

    public TransaksController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Transaks
    public async Task<IActionResult> Index()
    {
        var transaks = await _context.Transaks.Take(100).ToListAsync();

        return transaks != null ?
                      View(transaks) :
                      Problem("Entity set 'ApplicationDbContext.Transaks'  is null.");
    }

    // GET: Transaks/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Transaks == null)
        {
            return NotFound();
        }

        var transak = await _context.Transaks
            .FirstOrDefaultAsync(m => m.Id == id);
        if (transak == null)
        {
            return NotFound();
        }

        return View(transak);
    }

    // GET: Transaks/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Transaks/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("TransId,MotoId,OtdelId,SlujitelId,Kmid,ListId,DateTrans,TransNumber,KmKm,OsnovnaTrans,RudnikTrans,OkragTrans,StolicaTrans,GradskaTrans,MqstoTrans,KlimaTrans,AgregatTrans,Zarabotka,Izvan,Doma,KlimatikTrans,PechkaTrans,UserList,TekushtaData")] Transak transak)
    {
        if (ModelState.IsValid)
        {
            _context.Add(transak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(transak);
    }

    // GET: Transaks/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Transaks == null)
        {
            return NotFound();
        }

        var transak = await _context.Transaks.FindAsync(id);
        if (transak == null)
        {
            return NotFound();
        }
        return View(transak);
    }

    // POST: Transaks/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,MotoId,OtdelId,SlujitelId,Kmid,ListId,DateTrans,TransNumber,KmKm,OsnovnaTrans,RudnikTrans,OkragTrans,StolicaTrans,GradskaTrans,MqstoTrans,KlimaTrans,AgregatTrans,Zarabotka,Izvan,Doma,KlimatikTrans,PechkaTrans,UserList,TekushtaData")] Transak transak)
    {
        if (id != transak.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(transak);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransakExists(transak.Id))
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
        return View(transak);
    }

    // GET: Transaks/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Transaks == null)
        {
            return NotFound();
        }

        var transak = await _context.Transaks
            .FirstOrDefaultAsync(m => m.Id == id);
        if (transak == null)
        {
            return NotFound();
        }

        return View(transak);
    }

    // POST: Transaks/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Transaks == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Transaks'  is null.");
        }
        var transak = await _context.Transaks.FindAsync(id);
        if (transak != null)
        {
            _context.Transaks.Remove(transak);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TransakExists(int id)
    {
      return (_context.Transaks?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
