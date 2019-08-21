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
        int Add(string name, string address, bool isAvaible);
        void Delete(int buildingId);
    }
}
