using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Avto.Data;
using AutoMapper;
using Avto.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace Avto.Controllers;

public class BaseController<TModel, TEntity> : Controller where TModel : class where TEntity : class, IEntity
{
    protected readonly ApplicationDbContext _context;
    protected readonly IMapper _mapper;
    protected readonly string _modelDescription;

    public BaseController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        var modelType = typeof(TModel);
        var descriptionAttribute = modelType.GetCustomAttribute<DescriptionAttribute>();
        _modelDescription = descriptionAttribute?.Description ?? modelType.Name;
    }

    protected virtual IQueryable<TEntity> ApplyCustomIncludes(IQueryable<TEntity> dbSet)
    {
        // By default, do nothing. Subclasses can override this method to customize includes.
        return dbSet;
    }

    protected virtual IQueryable<TEntity> ApplyCustomSearch(SearchModel searchModel)
    {
        // By default, return the whole dbSet. Subclasses can override this method to customize search.
        return _context.Set<TEntity>();
    }

    public async Task<IActionResult> Index(SearchModel searchModel)
    {
        int pageSize = 100;
        int pageNumber = searchModel.Page;

        var query = ApplyCustomSearch(searchModel);

        var items = await ApplyCustomIncludes(query)
            .OrderByDescending(pl => pl.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        searchModel.TotalPages = (int)Math.Ceiling((double)query.Count() / pageSize);
        ViewData["Title"] = string.Join(" ", PluralizePhraze(_modelDescription));
        ViewData["Search"] = searchModel;
        ViewData["CallingIndexView"] = ControllerContext.ActionDescriptor.ControllerName;

        return items != null ?
            View(_mapper.Map<List<TModel>>(items)) :
            Problem($"В '{typeof(PList).Name}' няма записи отговарящи на зададените критерии.");
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
        SetViews();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TModel model)
    {
        SetViews();

        //if (ModelState.IsValid)
        {
            var entity = _mapper.Map<TEntity>(model);
            entity.TekushtaData = DateTime.Now;
            entity.User = User.Identity.Name;
            _context.Add(entity); // For PLists // In SSMS delete FK_Transaks_Motos_MotoId & FK_Transaks_Slujiteli_SlujitelId
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["Title"] = "Добавяне на " + _modelDescription;

        return View(model);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var entity = await ApplyCustomIncludes(_context.Set<TEntity>()).Where(e => e.Id == id).FirstOrDefaultAsync();

        if (entity == null)
            return NotFound();

        ViewData["Title"] = "Редактиране на " + _modelDescription;

        SetViews();

        return View(_mapper.Map<TModel>(entity));
    }

    public async Task<IActionResult> EditBase(int id, [FromForm] IModel model)
    {
        if (id != model.Id)
            return NotFound();

        //if (ModelState.IsValid)
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

        ViewData["Title"] = "Редактиране на " + _modelDescription;
        return View(model);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var entity = await ApplyCustomIncludes(_context.Set<TEntity>()).Where(e => e.Id == id).FirstOrDefaultAsync();

        if (entity == null)
            return NotFound();

        ViewData["Title"] = "Изтриване на " + _modelDescription;
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

        ViewData["Title"] = "Изтриване на " + _modelDescription;
        return RedirectToAction(nameof(Index));
    }

    internal bool EntityExists(int id) =>
        _context.Set<TEntity>().Any(e => e.Id == id);

    public List<string> PluralizePhraze(string modelDescription)
    {
        var modelDescriptionWords = modelDescription.Split(" ").ToList();
        var modelDescriptionPlural = new List<string>();

        foreach (var word in modelDescriptionWords)
            modelDescriptionPlural.Add(PluralizeBulgarian(word));

        return modelDescriptionPlural;
    }

    public string PluralizeBulgarian(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return word;
        
        if (word.EndsWith("а") || word.EndsWith("я")) // Feminine nouns
            return word.Substring(0, word.Length - 1) + "и";
        
        if (word.EndsWith("ен")) // Masculine nouns
            return word.Substring(0, word.Length - 2) + "ни";
        
        if (word.EndsWith("о") || word.EndsWith("е")) // Neutral nouns
            return word.Substring(0, word.Length - 1) + "а";
        
        if (word.EndsWith("ът") || word.EndsWith("ят")) // Definite article endings
        {
            // Handle definite article endings by pluralizing the base word
            string baseWord = word.Substring(0, word.Length - 2);
            return PluralizeBulgarian(baseWord) + "те";
        }
        
        if (word.EndsWith("че") || word.EndsWith("ще")) // Some irregular cases
            return word + "та";
        
        if (word.EndsWith("ко") || word.EndsWith("го")) // Neutral nouns
            return word.Substring(0, word.Length - 2) + "та";
        
        if (word.EndsWith("о") || word.EndsWith("е")) // Neutral nouns
            return word.Substring(0, word.Length - 1) + "а";
        
        if (word.EndsWith("ец")) // Masculine nouns
            return word.Substring(0, word.Length - 2) + "ци";
        
        if (word.EndsWith("ка")) // Feminine nouns
            return word.Substring(0, word.Length - 2) + "ки";
       
        // For all other cases, simply add "и" to the end
        return word + "и";
    }

    public DateTime ToNullableDateTime(DateOnly? dateOnly)
    {
        if (dateOnly == null)
            return DateTime.MinValue;

        return new DateTime((int)dateOnly?.Year, (int)dateOnly?.Month, (int)dateOnly?.Day);
    }

    private void SetViews()
    {
        if (ControllerContext.ActionDescriptor.ControllerName.Equals("Zastrahovki"))
        {
            ViewData["MotoId"] = new SelectList(_context.Motos, "Id", "Name");
            ModelState.Remove("Moto");
        }

        if (ControllerContext.ActionDescriptor.ControllerName.Equals("PLists"))
        {
            ViewData["Motos"] = new SelectList(_context.Motos.Where(m => !m.Brak), "Id", "NumberAndName");
            ViewData["Slujiteli"] = new SelectList(_context.Slujiteli, "Id", "Name");
            ViewData["Otdeli"] = new SelectList(_context.Otdels, "Id", "Name");
            ModelState.Remove("Transaks");
        }

        if (ControllerContext.ActionDescriptor.ControllerName.Equals("Motos"))
        {
            ModelState.Remove("Zastrahovki");
        }
    }

}
