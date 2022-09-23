using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.AspNetCore.Routing;

namespace DeviceManagement_WebApp.Controllers
{

    //[Route("[controller]")]
    public class ZonesController : Controller
    {
        private readonly IZoneRepository _zoneRepository;

        public ZonesController(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;
        }

        /*  public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }*/

        //Inherited GET method to retrieve all zones//
        [HttpGet]
        [Route("Zones/Index")]
        public async Task<IActionResult> Index()
        {
            return View(_zoneRepository.GetAll());
        }

        [HttpPost]
        [Route("Zones/Create")]
        public  Task<IActionResult> Create(Zone zone)
        {
            _zoneRepository.Add(zone);
            return NoContent();
        }

    }
}
