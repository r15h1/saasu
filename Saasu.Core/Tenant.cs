using System.Collections.Generic;

namespace Saasu.Core
{
    public class Tenant
    {
        public Tenant()
        {
            Settings = new Dictionary<string, string>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Settings { get; set; }
        public IEnumerable<string> HostNames
        {
            get
            {
                if (Settings.ContainsKey(Constants.Tenant_Host_Key) && !string.IsNullOrWhiteSpace(Settings[Constants.Tenant_Host_Key]))
                    return Settings[Constants.Tenant_Host_Key].Split(new char[] { ',', ';' });
                        
                return new List<string>();
            }
        }

        public string Theme
        {
            get
            {
                if (Settings.ContainsKey(Constants.Tenant_Theme_Key) && !string.IsNullOrWhiteSpace(Settings[Constants.Tenant_Theme_Key]))
                    return Settings[Constants.Tenant_Theme_Key];

                return null;
            }
        }

    }
}
