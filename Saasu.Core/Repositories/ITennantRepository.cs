using System.Collections.Generic;

namespace Saasu.Core.Repositories
{
    public interface ITennantRepository
    {
        IEnumerable<Tennant> GetTennants();
    }
}
