using Avto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Avto.TagHelpers;

[HtmlTargetElement("a", Attributes = "search-vm")]
public class SearchTagHelper : TagHelper
{
    private readonly IUrlHelperFactory _urlHelperFactory;

    public SearchModel SearchVm { get; set; } = new SearchModel();

    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; }

    public SearchTagHelper(IUrlHelperFactory urlHelperFactory)
    {
        _urlHelperFactory = urlHelperFactory;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var routeValues = new Dictionary<string, object>
            {
                { "Number", SearchVm.Number ?? null},
                { "From", SearchVm.From ?? null },
                { "To", SearchVm.To ?? null },
                { "MotoName", SearchVm.MotoName ?? null },
                { "MotoNumber", SearchVm.MotoNumber ?? null },
                { "SlujitelId", SearchVm.SlujitelId },
                { "SlujitelName", SearchVm.SlujitelName ?? null },
                { "Otdel", SearchVm.Otdel ?? null },
                { "Page", SearchVm.Page }
            };

        var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
        var url = urlHelper.Action("Index", routeValues);

        output.Attributes.SetAttribute("href", url);
    }
}
