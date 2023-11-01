using Avto.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avto.ViewComponents;

public class Search : ViewComponent
{
    public IViewComponentResult Invoke(PListModel searchModel)
    {
        ViewData["SearchModel"] = searchModel;
        return View(searchModel);
    }
}
