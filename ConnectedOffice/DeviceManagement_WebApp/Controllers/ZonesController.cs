//Marcel Joubert - 35376759//

using System;
using Microsoft.AspNetCore.Mvc;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.EntityFrameworkCore;


namespace DeviceManagement_WebApp.Controllers
{

    public class ZonesController : Controller
    {
        private readonly IZoneRepository _zr;
        public ZonesController(IZoneRepository zoneRepository)
        {
            _zr = zoneRepository;
        }





        //GET METHOD//
        //Returns all of the items in this section/category//
        public ActionResult Index()
        {
            //return View(db.Products.ToList());
            return View(_zr.GetAll());
        }
        //Returns a specific item in the section/category//
        [HttpGet]
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Zone zones = _zr.GetById(id);
            if (zones == null)
            {
                return NotFound();
            }
            else
            {
                Dispose();
                return View(zones);
            }
        }






        //DELETE METHOD//
        //Returns a view of the selected item to be deleted//
        public ActionResult Delete()
        {
            return View();
        }
        //Deletes the selected item//
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                Zone zones = _zr.GetById(id);
                if (zones == null)
                {
                    return NotFound();
                }
                _zr.Remove(zones);
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }







        //EDIT METHOD//
        //Returns a view of the selected item with its values to be edited//
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Zone zone = _zr.GetById(id);
            if (zone== null)
            {
                return NotFound();
            }
                return View(zone);
        }
        //Edits/updates the selected item//
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Zone zone)
        {
            try
            {
                if (zone == null)
                {
                    return NotFound();
                }
                _zr.Update(zone);
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }








        //CREATE METHOD//
        //Returns a blank view and prompts the user for input//
        public ActionResult Create()
        {
            return View();
        }
        //Creates a new item based on user input, ID is self-generated//
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Zone zones)
        {
            try
            {
                if (zones != null)
                {
                    zones.ZoneId = Guid.NewGuid();
                    _zr.Add(zones);
                    return RedirectToAction("Index");
                }
                else
                {
                    Dispose();
                    return View(zones);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }





        //DISPOSE METHOD//
        //Dispose method to free up memory if data in memory is unused//
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
