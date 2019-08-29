using AutoMapper;
using Reti.NewCondeco.API.Models;
using Reti.NewCondeco.BL;
using Reti.NewCondeco.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Reti.NewCondeco.API.Controllers
{
    [EnableCors(origins: "https://localhost:44374", headers: "*", methods: "*")]
    [RoutePrefix("api/resources")]
    public class ResourceController: ApiController
    {

        [HttpGet]
        [Route("GetResource/{id}")]
        public IHttpActionResult GetResource([FromUri]int id)
        {
            ResourcesManager rm = new ResourcesManager();
            return Ok(rm.GetResourceById(id));
        }

        [HttpPost]
        [Route("PostResource")]
        public IHttpActionResult PostResource([FromBody] ResourceDto rc)
        {
            ResourcesManager rm = new ResourcesManager();

            IMapper iMapper = AutomapperInitialize();
            var source = rc;
            var destination = iMapper.Map<ResourceDto, Resource>(source);

            rm.CreateResource(destination);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAllResources()
        {
            ResourcesManager rm = new ResourcesManager();
            return Ok(rm.ReturnAllResources());
        }

        [HttpDelete]
        [Route("DeleteResource/{id}")]
        public IHttpActionResult DeleteResource([FromUri]int id)
        {
            ResourcesManager rm = new ResourcesManager();
            rm.DeleteResource(id);
            return Ok();
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