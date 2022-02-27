using ChatBot.Models;
using ChatBot.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ChatBot.Controllers.Api
{
    [ApiController]
    [Route("api/maps")]
    public class MapsApiController : Controller
    {
        private readonly IMapService service;

        public MapsApiController(IMapService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IEnumerable<Map> Get()
        {
            return service.Maps;
        }

        [HttpGet("{region}")]
        public IEnumerable<Map> Get(string region)
        {
            return service.Maps.Where(x => x.Region == region);
        }
        [HttpGet("{region}/{city}")]
        public IEnumerable<Map> Get(string region, string city)
        {
            return service.Maps.Where(x => x.Region == region && x.City == city);
        }

    }
}
