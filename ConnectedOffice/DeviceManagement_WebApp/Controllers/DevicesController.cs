//Marcel Joubert - 35376759//

using System;
using Microsoft.AspNetCore.Mvc;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDeviceRepository _dr;
        public DevicesController(IDeviceRepository deviceRepository)
        {
            _dr = deviceRepository;
        }




        //GET METHOD//
        //Returns all of the items in this section/category//

        [HttpGet]
        public ActionResult Index()
        {
            //return View(db.Products.ToList());
            return View(_dr.ReturnDevices());
        }
        //Returns a specific item in the section/category//
        [HttpGet]
        public ActionResult Details(Guid id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Device device = _dr.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            else
            {
                Zone zone = _dr.ReturnZoneId(device.ZoneId);
                Category category = _dr.ReturnCatId(device.CategoryId);
                device.Zone = zone;
                device.Category = category;

                return View(device);
            }
        }






        //DELETE METHOD//
        //Returns a view of the selected item to be deleted//
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Device device = _dr.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            else
            {
                ViewData["Category.CategoryName"] = device.CategoryId;
                ViewData["Zone.ZoneName"] = device.ZoneId;
                return View(device);
            }
           
        }
        //Deletes the selected item//
        [HttpPost]
        public ActionResult Delete(Device device)
        {
            try
            {
                if (device == null)
                {
                    return NotFound();
                }
                _dr.Remove(device);
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }







        //EDIT METHOD//
        //Returns a view of the selected item with its values to be edited//
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Device device = _dr.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = _dr.ReturnCategoryList();
            ViewData["ZoneId"] = _dr.ReturnZoneList();
            return View(device);
        }
        //Edits/updates the selected item//
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Device device)
        {
            try
            {
                if (device == null)
                {
                    return NotFound();
                }
                _dr.Update(device);
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }








        //CREATE METHOD//
        //Returns a blank view and prompts the user for input//
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["CategoryId"] = _dr.ReturnCategoryList();
            ViewData["ZoneId"] = _dr.ReturnZoneList();
            return View();
        }
    
        //Creates a new item based on user input, ID is self-generated//
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Device device)
        {
            try
            {
                if (device != null)
                {
                    device.DeviceId = Guid.NewGuid();
                    _dr.Add(device);
                    return RedirectToAction("Index");
                }
                else
                {
                    Dispose();
                    return View(device);
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
