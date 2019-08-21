using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reti.NewCondeco.Interfaces
{
    public interface IRoomRepository
    {
        Room Get(int roomId);
        IEnumerable<Room> GetAll();
        int Add(string name, int avaiableSeat, int buildingId, bool isAvaible);
        void Delete(int roomId);
    }
}
