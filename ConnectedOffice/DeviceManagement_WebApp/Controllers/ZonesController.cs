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


        //GET

        // GET: retrieve all items in a table format : Get All
        public IActionResult Index()
        {
            //return View(db.Products.ToList());
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
            Zone zones = _zr.GetById(id);
            if (zones == null)
            {
                return NotFound();
            }
            else
            {
                return View(zones);
                Dispose();
            }
        }



      

        // DELETE: delete item base on item id given : Remove
        [Route("zones/delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
                //return View(service);
            }
            Zone zones = _zr.GetById(id);
            if (zones == null)
            {
                return NotFound();
            }
            _zr.Remove(zones);
            //return View(service);
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
        public IActionResult Create(Zone zones)
        {
            if (zones!=null)
            {
                _zr.Add(zones);

                //return CreatedAtAction("Index", service);
                return RedirectToAction("Index");
            }
            else
            {
                Dispose();
                return View(zones);
            }

        }





        //DISPOSE


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
