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
    public class TenantViewLocationExpander: IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values[Constants.Tenant_Theme_Key]
                = context.ActionContext.HttpContext.GetTenant<Tenant>()?.Theme.Name ?? "Default";

            context.Values[Constants.Tenant_Id_Key]
                = context.ActionContext.HttpContext.GetTenant<Tenant>()?.Id.ToString();
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            string theme = null;
            if (context.Values.TryGetValue(Constants.Tenant_Theme_Key, out theme))
            {
                IEnumerable<string> themeLocations = new[]
                {
                    $"/Themes/{theme}/{{1}}/{{0}}.cshtml",
                    $"/Themes/{theme}/Shared/{{0}}.cshtml"
                };

                string tenant;
                if (context.Values.TryGetValue(Constants.Tenant_Id_Key, out tenant))
                {
                    themeLocations = ExpandTenantLocations(tenant, themeLocations);
                }

                viewLocations = themeLocations.Concat(viewLocations);
            }


            return viewLocations;
        }

        private IEnumerable<string> ExpandTenantLocations(string tenant, IEnumerable<string> defaultLocations)
        {
            foreach (var location in defaultLocations)
            {
                if (!string.IsNullOrWhiteSpace(tenant))
                    yield return location.Replace("{0}", $"{{0}}_{tenant}");
                yield return location;
            }
        }    
    }
}