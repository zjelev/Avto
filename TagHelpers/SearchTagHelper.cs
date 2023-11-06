using Avto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Avto.TagHelpers;

[HtmlTargetElement("a", Attributes = "search")]
public class SearchTagHelper : TagHelper
{
    private readonly IUrlHelperFactory _urlHelperFactory;
    public int? SearchPage { get; set; }

    public SearchModel SearchModel { get; set; } = new SearchModel();

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
                { "Number", SearchModel.Number ?? null},
                { "From", SearchModel.From ?? null },
                { "To", SearchModel.To ?? null },
                { "MotoName", SearchModel.MotoName ?? null },
                { "MotoNumber", SearchModel.MotoNumber ?? null },
                { "SlujitelId", SearchModel.SlujitelId },
                { "SlujitelName", SearchModel.SlujitelName ?? null },
                { "Page", SearchPage ?? null}
            };

        var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
        var url = urlHelper.Action("Index", routeValues);

        output.Attributes.SetAttribute("href", url);
    }
}
