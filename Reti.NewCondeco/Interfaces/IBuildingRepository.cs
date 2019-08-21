using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reti.NewCondeco.Interfaces
{
    public interface IBuildingRepository
    {
        Building Get(int buildingId);
        IEnumerable<Building> GetAll();
        int Add(Building item);
        void Delete(Building item);
    }
}
