using Reti.NewCondeco.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Reti.NewCondeco.API.Controllers
{
    public class ResourceController: ApiController
    {
        [HttpGet]
        public IEnumerable<ResourceDto> GetAllResources()
        {
            return null;
        }

        [HttpGet]
        public IHttpActionResult GetResource(int id)
        {
          
            return Ok();
        }
    }
}