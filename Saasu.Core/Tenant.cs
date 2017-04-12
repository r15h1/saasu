using System;
using System.Collections.Generic;

namespace Saasu.Core
{
    public class Tenant
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Theme Theme { get; set; }
        public IEnumerable<string> Hostnames { get; set; }
    }
}
