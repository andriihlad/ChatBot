using ChatBot.Models;
using ChatBot.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ChatBot.Controllers
{
    [Authorize(Roles = "admin")]
    public class MapsController : Controller
    {
        private readonly IMapService service;

        public MapsController(IMapService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View(service.Maps);
        }
        [HttpPost]
        public IActionResult Index(Map map)
        {
            if (map.Id == 0)
            {
                service.Maps.Add(map);
            }
            else
            {
                var mapEntity = service.Maps.FirstOrDefault(x => x.Id == map.Id);
                if (mapEntity != null)
                {
                    mapEntity.Region = map.Region;
                    mapEntity.City = map.City;
                    mapEntity.Url = map.Url;
                }
                service.Update(mapEntity);
            }
            service.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            service.Maps.Remove(service.Maps.Find(x => x.Id == id));
            service.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
