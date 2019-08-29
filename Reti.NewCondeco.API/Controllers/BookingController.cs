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
    [RoutePrefix("api/booking")]
    public class BookingController : ApiController
    {
        [HttpGet]
        [Route("GetBooking/{id}")]
        public IHttpActionResult GetBooking([FromUri]int id)
        {
            BookingManager rm = new BookingManager();
            return Ok(rm.GetBookingById(id));
        }

        [HttpPost]
        [Route("PostBooking")]
        public IHttpActionResult PostBooking([FromBody] BookingDto rc)
        {
            BookingManager rm = new BookingManager();

            IMapper iMapper = AutomapperInitialize();
            var source = rc;
            var destination = iMapper.Map<BookingDto, Booking>(source);

            rm.CreateBooking(destination);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAllBooking()
        {
            BookingManager rm = new BookingManager();
            return Ok(rm.ReturnAllBookings());
        }

        [HttpDelete]
        [Route("DeleteBooking/{id}")]
        public IHttpActionResult DeleteBooking([FromUri]int id)
        {
            BookingManager rm = new BookingManager();
            rm.DeleteBooking(id);
            return Ok();
        }

        private IMapper AutomapperInitialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BookingDto, Booking>();
            });

            return config.CreateMapper();
        }
    }
}