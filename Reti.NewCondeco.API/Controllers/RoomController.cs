using AutoMapper;
using Reti.NewCondeco.API.Models;
using Reti.NewCondeco.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Reti.NewCondeco.API.Controllers
{
    [EnableCors(origins: "https://localhost:44374", headers: "*", methods: "*")]
    [RoutePrefix("api/rooms")]
    public class RoomController : ApiController
    {
        [HttpGet]
        [Route("GetRoom/{id}")]
        public IHttpActionResult GetRoom([FromUri]int id)
        {
            RoomsManager rm = new RoomsManager();
            return Ok(rm.GetRoomById(id));
        }

        [HttpPost]
        [Route("PostRoom")]
        public IHttpActionResult PostRoom([FromBody] RoomDto rc)
        {
            RoomsManager rm = new RoomsManager();

            IMapper iMapper = AutomapperInitialize();
            var source = rc;
            var destination = iMapper.Map<RoomDto, Room>(source);

            rm.CreateRoom(destination);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAllRoom()
        {
            RoomsManager rm = new RoomsManager();
            return Ok(rm.ReturnAllRooms());
        }

        [HttpDelete]
        [Route("DeleteRoom/{id}")]
        public IHttpActionResult DeleteRoom([FromUri]int id)
        {
            RoomsManager rm = new RoomsManager();
            rm.DeleteRoom(id);
            return Ok();
        }

        private IMapper AutomapperInitialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RoomDto, Room>();
            });

            return config.CreateMapper();
        }
    }
}