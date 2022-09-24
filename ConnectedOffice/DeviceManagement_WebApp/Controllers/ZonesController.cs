using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Routing;
using DeviceManagement_WebApp.IRepository;
using Microsoft.Extensions.Logging;
using DeviceManagement_WebApp.Configuration;

namespace DeviceManagement_WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZonesController : Controller
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly ILogger<ZonesController> _logger;
        private readonly IUnitOfWork _unitOfWork;



        public ZonesController(
            IZoneRepository zoneRepository,
            ILogger<ZonesController> logger,
            IUnitOfWork unitOfWork)
        {
           _logger = logger;
            _unitOfWork = unitOfWork;   
            _zoneRepository = zoneRepository;
        }









        /*
         public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }


        //Inherited GET method to retrieve all zones//
        public async Task<IActionResult> Index()
        {
            return View(_zoneRepository.GetAll());
        }

        //Inherited GET method to retrieve zones by id//
        public async Task<IActionResult> GetMostRecent()
        {
            return View(_zoneRepository.GetMostRecentZone());
        }*/
    }
}
