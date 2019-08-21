using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reti.NewCondeco.Interfaces
{
    public interface IResourceRepository
    {
        Resource Get(int resourceId);
        IEnumerable<Resource> GetAll();
        int Add(Resource item);
        void Delete(Resource item);
    }
}
