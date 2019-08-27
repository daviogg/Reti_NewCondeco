using AutoMapper;
using Reti.NewCondeco.API.Models;
using Reti.NewCondeco.BL;
using Reti.NewCondeco.Entities;
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
        public IHttpActionResult GetResource(int id)
        {
          
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult PostResource([FromBody] ResourceDto rc)
        {
            ResourcesManager rm = new ResourcesManager();

            IMapper iMapper = AutomapperInitialize();
            var source = rc;
            var destination = iMapper.Map<ResourceDto, Resource>(source);

            rm.UpdateResource(destination);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAllResources()
        {
            ResourcesManager rm = new ResourcesManager();
            return Ok(rm.ReturnAllResources());
        }

        private IMapper AutomapperInitialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ResourceDto, Resource>();
            });

            return config.CreateMapper();
        }
    }
}