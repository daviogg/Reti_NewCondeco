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
        public int Add(Resource item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
             ((NewCondecoEntities)Context).Resources.Add(item);
            return item.ResourceID;
        }

        public void Delete(Resource item)
        {
            ((NewCondecoEntities)Context).Resources.Remove(item);
        }

        public Resource Get(int resourceId)
        {
            return ((NewCondecoEntities)Context).Resources.SingleOrDefault(i => i.ResourceID == resourceId);
        }
    }
}
