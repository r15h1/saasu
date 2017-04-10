using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using SaasKit.Multitenancy;
using Saasu.Core;
using Saasu.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saasu.Web.Middleware
{
    public class TennantResolver : ITenantResolver<Tennant>
    {
        private List<Tennant> tennants;

        public TennantResolver(ITennantRepository repository, IOptions<RequestLocalizationOptions> localizationOptions, IMemoryCache cache)
        {
            if (!cache.TryGetValue(Constants.Tennant_List_Cache_Key, out tennants))
            {
                tennants = new List<Tennant>();
                tennants.AddRange(repository.GetTennants());
                cache.Set(Constants.Tennant_List_Cache_Key, tennants, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(5)));
            }
        }

        public Task<TenantContext<Tennant>> ResolveAsync(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
