using Dapper;
using Saasu.Core;
using Saasu.Core.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Saasu.Lib.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        public IEnumerable<Tenant> GetTenants()
        {
            return FetchTenants();
        }

        private IList<Tenant> FetchTenants()
        {
            List<Tenant> tenants;

            using (IDbConnection connection = ConnectionFactory.GetConnection())
            using (var reader = connection.QueryMultiple(
                                 @"SELECT tn.tenant_id AS id, tn.name AS name, tn.email AS email FROM tenants tn WHERE tn.active = true;
                                   SELECT tenant_id AS id, key, value FROM tenant_settings;"))
            { 
                tenants = reader.Read<dynamic>().Select(t => new Tenant { Id = t.id, Name = t.name }).ToList();
                var settings = reader.Read<dynamic>().Select(s => new { TenantId = s.id, Key = s.key, Value = s.value }).ToList();

                tenants.ForEach(t => t.Settings = settings.Where(s => s.TenantId == t.Id).ToDictionary(k => (string) k.Key, v => (string) v.Value));
            }

            return tenants;
        }
    }
}