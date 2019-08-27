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
            try
            {
                ResourceRepository resourceRepo = new ResourceRepository();

                var repo = resourceRepo.Get(resource.ResourceID);
                //TODO: Separate Add and Update logics
                if (repo == null)
                {
                    resourceRepo.Add(resource);
                }
                else
                {
                    resourceRepo.Update(resource);
                }
            }
            catch(Exception ex){
                throw ex;
            }

            GlobalUnitOfWork.Commit();
        }

        public IEnumerable<Resource> ReturnAllResources()
        {
            IEnumerable<Resource> resources = null;
            try { 
                ResourceRepository resourceRepo = new ResourceRepository();

                resources =  resourceRepo.GetAll();
            }catch(Exception ex)
            {
                throw ex;
            }

            return resources;
        }

        public void DeleteResource(Resource resource)
        {
            try
            {
                ResourceRepository resourceRepo = new ResourceRepository();
                resourceRepo.Delete(resource);
                GlobalUnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
