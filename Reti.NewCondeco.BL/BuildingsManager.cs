using Reti.NewCondeco.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reti.NewCondeco.BL
{
    public class BuildingsManager
    {
        public Building GetBuildingById(int id)
        {
            Building result;
            try
            {
                BuildingRepository buildingRepo = new BuildingRepository();
                result = buildingRepo.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public void CreateBuilding(Building building)
        {
            BuildingRepository buildingRepo = new BuildingRepository();
            try
            {
                buildingRepo.Add(building);
                GlobalUnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Building> ReturnAllBuildings()
        {
            IEnumerable<Building> buildings;
            try
            {
                BuildingRepository buildingRepo = new BuildingRepository();

                buildings = buildingRepo.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return buildings;
        }

        public void DeleteBuilding(int buildingID)
        {
            try
            {
                BuildingRepository buildingRepo = new BuildingRepository();
                var r = buildingRepo.Get(buildingID);
                buildingRepo.Delete(r);
                GlobalUnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
