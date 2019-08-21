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
        public int Add(Room item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            ((NewCondecoEntities)Context).Rooms.Add(item);
            return item.RoomId;
        }

        public void Delete(Room item)
        {
            ((NewCondecoEntities)Context).Rooms.Remove(item);
        }

        public Room Get(int roomId)
        {
            return ((NewCondecoEntities)Context).Rooms.SingleOrDefault(i => i.RoomId == roomId);
        }
    }
}
