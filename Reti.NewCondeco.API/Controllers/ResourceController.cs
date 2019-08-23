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
        public IEnumerable<ResourceDto> GetAllResources()
        {
            return null;
        }

        [HttpGet]
        public IHttpActionResult GetResource(int id)
        {
          
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult PostResource(ResourceDto rc)
        {
            ResourcesManager rm = new ResourcesManager();

            //TODO: Config Automapper
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Resource, ResourceDto>();
            });

            IMapper iMapper = config.CreateMapper();
            var source = new ResourceDto();
            var destination = iMapper.Map<ResourceDto, Resource>(source);

            rm.UpdateResource(destination);
            return Ok();
        }
    }
}