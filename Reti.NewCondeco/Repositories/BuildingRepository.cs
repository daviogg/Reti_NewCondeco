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
        public int Add(Building item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            ((NewCondecoEntities)Context).Buildings.Add(item);
            return item.BuildingId;
        }

        public void Delete(Building item)
        {
            ((NewCondecoEntities)Context).Buildings.Remove(item);
        }

        public Building Get(int buildingId)
        {
            return ((NewCondecoEntities)Context).Buildings.SingleOrDefault(i => i.BuildingId == buildingId);
        }
    }
}
