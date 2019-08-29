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
        
    }
}