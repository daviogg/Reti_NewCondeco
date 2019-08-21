using Reti.NewCondeco.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reti.NewCondeco.Repositories
{
    public class BuildingRepository : EFRepository<Building>, IBuildingRepository
    {
        public int Add(string name, string address, bool isAvaible)
        {
            throw new NotImplementedException();
        }

        public void Delete(int buildingId)
        {
            throw new NotImplementedException();
        }

        public Building Get(int buildingId)
        {
            throw new NotImplementedException();
        }
    }
}
