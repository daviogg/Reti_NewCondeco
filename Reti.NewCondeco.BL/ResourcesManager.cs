using Reti.NewCondeco.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reti.NewCondeco.Repositories;

namespace Reti.NewCondeco.BL
{
    public class ResourcesManager
    {
        public object DAL { get; private set; }

        //TODO: Define return type
        public void UpdateResource(Resource resource)
        {

            //TODO: Try Catch
            ResourceRepository resourceRepo = new ResourceRepository();

            _ = resourceRepo.Get(resource.ResourceID);

            if (resourceRepo == null)
            {
                resourceRepo.Add(resource);
            }
            else
            {
                resourceRepo.Update(resource);
            }

            GlobalUnitOfWork.Commit();
        }

    }
}
