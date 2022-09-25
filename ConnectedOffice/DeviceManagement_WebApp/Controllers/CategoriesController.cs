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

namespace DeviceManagement_WebApp.Controllers
{

    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _cr;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _cr = categoryRepository;
        }


        //GET

        // GET: retrieve all items in a table format : Get All
        public IActionResult Index()
        {
            //return View(db.Products.ToList());
            return View(_cr.GetAll());
        }

        // GET: show one item in a singular item format : Get By ID
        //[Route("categories/{id}")]
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category category = _cr.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return View(category);
                Dispose();
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
            Category categories = _cr.GetById(id);
            if (categories == null)
            {
                return NotFound();
            }
            _cr.Remove(categories);
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
        public IActionResult Create(Category category)
        {
            if (category != null)
            {
                _cr.Add(category);

                //return CreatedAtAction("Index", service);
                return RedirectToAction("Index");
            }
            else
            {
                Dispose();
                return View(category);
            }

        }





        //DISPOSE


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
