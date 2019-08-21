using Reti.NewCondeco.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reti.NewCondeco.Repositories
{
    public class ResourceRepository : EFRepository<Resource>, IResourceRepository
    {
        public int Add(int resourceId, string username, string surname, string firstname, string mail, bool isAvaible)
        {
            throw new NotImplementedException();
        }

        public void Delete(int resourceId)
        {
            throw new NotImplementedException();
        }

        public Resource Get(int resourceId)
        {
            throw new NotImplementedException();
        }
    }
}
