﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.IRepository;
using System.Security.Policy;

namespace DeviceManagement_WebApp.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDeviceRepository _sr;
        public DeviceController(IDeviceRepository deviceRepository)
        {
            _sr = deviceRepository;
        }


        //GET

        // GET: retrieve all items in a table format : Get All
        public IActionResult Index()
        {
            //return View(db.Products.ToList());
            return View(_sr.GetAll());
        }

        // GET: show one item in a singular item format : Get By ID
        [Route("devices/{id}")]
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Product product = db.Products.Find(id);
            Device device = _sr.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            else
            {
                Dispose();
                return View(device);
               
            }
        }





        // DELETE: delete item base on item id given : Remove
        [Route("devices/delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Device device = _sr.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            _sr.Remove(device);
            return RedirectToAction("Index");
        }







        //EDIT

        /*// GET: retrieves a single item base on the item id given : Get By ID
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
                //return View(service);
            }
            Service service = _sr.GetById(id);
            if (service == null)
            {
                return NotFound();
            }
            else
            {
                return View(service);
                Dispose();
            }
        }

        // POST: edits/updates the information of a single item matching the given id : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();
                _sr.AddRange(service);
                return RedirectToAction("Index");
            }
            else
            {
                return View(service);
                Dispose();
            }
        }*/








        //CREATE

        // GET: returns blank view : Get None
        public ActionResult Create()
        {
            return View();
        }


        // POST: executes Add command, thus adding an item to the database : Add
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Device device)
        {
            if (device != null)
            {
                _sr.Add(device);

                //return CreatedAtAction("Index", service);
                return RedirectToAction("Index");
            }
            else
            {
                Dispose();
                return View(device);
            }

        }





        //DISPOSE


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
