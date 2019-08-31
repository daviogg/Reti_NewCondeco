using Reti.NewCondeco.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reti.NewCondeco.Repositories;
using System.Text.RegularExpressions;

namespace Reti.NewCondeco.BL
{
    public class ResourcesManager
    {
    
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
                var max = -1;
                List<Resource> rl = resourceRepo.GetAll().ToList();

                

                rl.ForEach(r =>
                {

                    var number = Regex.Replace(r.UserName, "[^0-9]", ""); ;
                    var usrName = Regex.Replace(r.UserName, "[^a-zA-Z]", "");

                    if (resource.UserName == usrName)
                    {
                        var intUsername = Int32.Parse(number);
                        if (max < intUsername)
                            max = intUsername;
                    }
                });

                
                resource.UserName += max+1;
                resource.ResourceID = resourceRepo.GetMaxId() + 1;

                resourceRepo.Add(resource);
                GlobalUnitOfWork.Commit();
            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

        public void UpdateAvaibleResource(int roomId, bool isAvaible)
        {

            try
            {
                ResourceRepository resourceRepo = new ResourceRepository();
                var resource = GetResourceById(roomId);
                resource.IsAvaible = isAvaible;
                resourceRepo.Update(resource);
                GlobalUnitOfWork.Commit();

            }
            catch (Exception ex)
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
