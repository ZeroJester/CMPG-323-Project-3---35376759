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

namespace DeviceManagement_WebApp.Controllers
{
    public class ZonesController : Controller
    {
        private readonly IZoneRepository _zr;
        public ZonesController(IZoneRepository zoneRepository)
        {
            _zr = zoneRepository;
        }







        //GET METHODS

        // GET: retrieve all items in a table format : Get All
        public IActionResult Index()
        {
            return View(_zr.GetAll());
        }

        // GET: show one item in a singular item format : Get By ID
        [Route("zones/{id}")]
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Product product = db.Products.Find(id);
            Zone zone = _zr.GetById(id);
            if (zone == null)
            {
                return NotFound();
            }
            else
            {
                return View(zone);
                Dispose();
            }
        }







        //DELETE METHODS

        public void Delete(Zone zone)
        {
            if (zone == null)
            {
                NotFound();
                View(zone);
            }
            // Product product = db.Products.Find(id);
            _zr.Remove(zone);
        }

        // GET: retrieve item by item id : Get By ID
        [Route("zones/delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Zone zone = _zr.GetById(id);
            if (zone == null)
            {
                return NotFound();
            }
            _zr.Remove(zone);
            return RedirectToAction("Index");
        }

        //DELETE: delete item base on item id given : Remove
        [Route("zones/delete/{id}")]
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Zone zone)
        {
            _zr.Remove(zone);
            return RedirectToAction("Index");
        }







        //EDIT METHODS

        // GET: retrieves a single item base on the item id given : Get By ID
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Zone zone = _zr.GetById(id);
            if (zone == null)
            {
                return NotFound();
            }
            else
            {
                return View(zone);
                Dispose();
            }
        }

        // POST: edits/updates the information of a single item matching the given id : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Zone zone)
        {
            if (ModelState.IsValid)
            {
               // _zr.AddRange(zone);
                return RedirectToAction("Index");
            }
            else
            {
                return View(zone);
                Dispose();
            }
        }








        //CREATE METHODS

        // GET: returns blank view : Get None
        public ActionResult Create()
        {
            return View();
        }

        // POST: executes Add command, thus adding an item to the database : Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Zone zone)
        {
            if (ModelState.IsValid)
            {
                _zr.Add(zone);
                return RedirectToAction("Index");
            }
            else
            {
                return View(zone);
                Dispose();
            }

        }







        //DISPOSE METHOD

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
