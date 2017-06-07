using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using SaasKit.Multitenancy;
using Saasu.Core;
using Saasu.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saasu.Web.Middleware
{
    public class TenantResolver : ITenantResolver<Tenant>
    {
        private List<Tenant> tenants;

        public TenantResolver(ITenantRepository repository, IOptions<RequestLocalizationOptions> localizationOptions, IMemoryCache cache)
        {
            if (!cache.TryGetValue(Constants.Tenant_List_Cache_Key, out tenants))
            {
                tenants = new List<Tenant>();
                tenants.AddRange(repository.GetTenants());
                cache.Set(Constants.Tenant_List_Cache_Key, tenants, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(5)));
            }
        }

        public Task<TenantContext<Tenant>> ResolveAsync(HttpContext context)
        {
            TenantContext<Tenant> tenantContext = null;

            var tenant = tenants.FirstOrDefault(t => t.HostNames.Any(h => h.Equals(context.Request.Host.Value.ToLower()))) ?? new Tenant();

            if (tenant != null)
                tenantContext = new TenantContext<Tenant>(tenant);

            return Task.FromResult(tenantContext);
        }
    }
}
