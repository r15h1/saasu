using System.Collections.Generic;

namespace Saasu.Core.Repositories
{
    public interface ITenantRepository
    {
        IEnumerable<Tenant> GetTenants();
    }
}