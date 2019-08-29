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
    [RoutePrefix("api/buildings")]
    public class BuildingController : ApiController
    {
        [HttpGet]
        [Route("GetBuilding/{id}")]
        public IHttpActionResult GetBuilding([FromUri]int id)
        {
            BuildingsManager rm = new BuildingsManager();
            return Ok(rm.GetBuildingById(id));
        }

        [HttpPost]
        [Route("Postbuilding")]
        public IHttpActionResult PostBuilding([FromBody] BuildingDto rc)
        {
            BuildingsManager rm = new BuildingsManager();

            IMapper iMapper = AutomapperInitialize();
            var source = rc;
            var destination = iMapper.Map<BuildingDto, Building>(source);

            rm.CreateBuilding(destination);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAllBuildings()
        {
            BuildingsManager rm = new BuildingsManager();
            return Ok(rm.ReturnAllBuildings());
        }

        [HttpDelete]
        [Route("Deletebuilding/{id}")]
        public IHttpActionResult DeleteBuilding([FromUri]int id)
        {
            BuildingsManager rm = new BuildingsManager();
            rm.DeleteBuilding(id);
            return Ok();
        }

        private IMapper AutomapperInitialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BuildingDto, Building>();
            });

            return config.CreateMapper();
        }
    }
}