using Reti.NewCondeco.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reti.NewCondeco.Repositories
{
    public class RoomRepository : EFRepository<Room>, IRoomRepository
    {
        public int Add(string name, int avaiableSeat, int buildingId, bool isAvaible)
        {
            throw new NotImplementedException();
        }

        public void Delete(int roomId)
        {
            throw new NotImplementedException();
        }

        public Room Get(int roomId)
        {
            throw new NotImplementedException();
        }
    }
}
