using Reti.NewCondeco.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reti.NewCondeco.BL
{
    public class RoomsManager
    {
        public Room GetRoomById(int id)
        {
            Room result;
            try
            {
                RoomRepository roomRepo = new RoomRepository();
                result = roomRepo.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public void CreateRoom(Room Room)
        {
            RoomRepository roomRepo = new RoomRepository();
            try
            {
                roomRepo.Add(Room);
                GlobalUnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Room> ReturnAllRooms()
        {
            IEnumerable<Room> rooms;
            try
            {
                RoomRepository roomRepo = new RoomRepository();

                rooms = roomRepo.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rooms;
        }

        public void UpdateAvaible(int roomId, int value)
        {
            
            try
            {
                RoomRepository roomRepo = new RoomRepository();
                var room = GetRoomById(roomId);
                room.AvaiableSeats += value;
                if (room.AvaiableSeats <= 0)
                    room.IsAvaible = false;
                else
                    room.IsAvaible = true;

                roomRepo.Update(room);
                GlobalUnitOfWork.Commit();

            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateResetAvaibleSeats(int roomId)
        {
            try
            {
                RoomRepository roomRepo = new RoomRepository();
                var room = GetRoomById(roomId);
                room.AvaiableSeats = room.OriginalAvaibleSeats;

                roomRepo.Update(room);
                GlobalUnitOfWork.Commit();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteRoom(int RoomID)
        {
            try
            {
                RoomRepository roomRepo = new RoomRepository();
                var r = roomRepo.Get(RoomID);
                roomRepo.Delete(r);
                GlobalUnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
