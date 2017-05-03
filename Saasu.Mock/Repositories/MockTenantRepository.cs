using System;
using System.Collections.Generic;
using Saasu.Core;
using Saasu.Core.Repositories;

namespace Saasu.Mock.Repositories
{
    public class MockTenantRepository : ITenantRepository
    {
        public IEnumerable<Tenant> GetTenants()
        {
            return new List<Tenant>
            {
                new Tenant(){
                    Id = 1,
                    Name = "Tennant1",
                    Theme = new Theme(){ Name = "Default" },
                    Hostnames = new List<string>{ "localhost:56819", "localhost:8000", "localhost:8001" }
                },
                new Tenant(){
                    Id = 2,
                    Name = "Tennant2",
                    Theme = new Theme(){ Name = "Rocky" },
                    Hostnames = new List<string>{ "localhost:56817" }
                }
            };
        }
    }
}
