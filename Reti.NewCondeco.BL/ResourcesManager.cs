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

        public Resource GetResourceById(int id)
        {
            Resource result;
            try
            {
                ResourceRepository resourceRepo = new ResourceRepository();
                result = resourceRepo.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public void CreateResource(Resource resource)
        {
            ResourceRepository resourceRepo = new ResourceRepository();
            try
            {
                resource.ResourceID = resourceRepo.GetMaxId() + 1;
                resourceRepo.Add(resource);
                GlobalUnitOfWork.Commit();
            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

        public IEnumerable<Resource> ReturnAllResources()
        {
            IEnumerable<Resource> resources;
            try { 
                ResourceRepository resourceRepo = new ResourceRepository();

                resources =  resourceRepo.GetAll();
            }catch(Exception ex)
            {
                throw ex;
            }

            return resources;
        }

        public void DeleteResource(int resourceID)
        {
            try
            {
                ResourceRepository resourceRepo = new ResourceRepository();
                var r = resourceRepo.Get(resourceID);
                resourceRepo.Delete(r);
                GlobalUnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
