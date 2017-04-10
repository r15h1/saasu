using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Saasu.Core;
using System.Collections.Generic;
using System.Linq;


namespace Saasu.Web.Middleware
{
    /// <summary>
    /// override the default locations for views
    /// </summary>
    public class TennantViewLocationExpander: IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values[Constants.Tennant_Theme_Context_Key]
                = context.ActionContext.HttpContext.GetTenant<Tennant>()?.Theme.Name;

            context.Values[Constants.Tennant_Context_Key]
                = context.ActionContext.HttpContext.GetTenant<Tennant>()?.Name.Replace(" ", "-");
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            string theme = null;
            if (context.Values.TryGetValue(Constants.Tennant_Context_Key, out theme)) theme = "Default";

            return new[]
            {
                $"/Views/Themes/{theme}/{{1}}/{{0}}.cshtml",
                $"/Views/Themes/{theme}/Shared/{{0}}.cshtml",
                $"/Views/Themes/Shared/{{0}}.cshtml",
                $"/Views/Shared/{{0}}.cshtml"
            };
        }
    }
}