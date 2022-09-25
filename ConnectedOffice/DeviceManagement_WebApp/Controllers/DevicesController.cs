using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Security.Policy;
using DeviceManagement_WebApp.Repository;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDeviceRepository _dr;
        public DevicesController(IDeviceRepository deviceRepository)
        {
            _dr = deviceRepository;
        }


        //GET

        // GET: retrieve all items in a table format : Get All
        public IActionResult Index()
        {
            //return View(db.Products.ToList());
            return View(_dr.GetAll());
        }

        // GET: show one item in a singular item format : Get By ID
        //[Route("devices/{id}")]
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Product product = db.Products.Find(id);
            Device device = _dr.GetById(id);
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



        public ActionResult Delete()
        {
            return View();
        }

        // DELETE: delete item base on item id given : Remove
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
                return RedirectToAction("Index");
            }
            Device devices = _dr.GetById(id);
            if (devices == null)
            {
                return NotFound();
            }
            _dr.Remove(devices);
            return RedirectToAction("Index");
        }






        /* //EDIT

         // GET: retrieves a single item base on the item id given : Get By ID
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
         }
        */







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
                _dr.Add(device);

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
