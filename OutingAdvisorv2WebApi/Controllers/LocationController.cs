using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using DO = OutingAdvisorV2DataObjects;
using LS = OutingAdvisorv2WebApi.LocationService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OutingAdvisorv2WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private LS.ILocationService _locationService;
        public LocationController(LS.ILocationService locationService) {
            _locationService = locationService;
        }
        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<DO.Location>> Get()
        {
            return Ok(_locationService.GetAll());
        }

        // GET api/values/5
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<DO.Location> Get(string name)
        {
            return Ok(_locationService.Get(name));
        }
         
        // POST api/values
        [HttpPost]
        public ActionResult<bool> Post([FromBody]DO.Location location)
        {
            return Ok(_locationService.Update(location));
        }

        // PUT api/values/5
        [HttpPut()]
        public ActionResult<bool> Put([FromBody]DO.Location location)
        {
            return Ok(_locationService.Insert(location));
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult<bool> Delete([FromRoute]DO.Location location)
        {
            return Ok(_locationService.Delete(location));
        }
    }
}
