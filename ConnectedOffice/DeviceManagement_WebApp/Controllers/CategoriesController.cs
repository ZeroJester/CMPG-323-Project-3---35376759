//Marcel Joubert - 35376759//

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





        //GET METHOD//
        //Returns all of the items in this section/category//
        public ActionResult Index()
        {
            //return View(db.Products.ToList());
            return View(_cr.GetAll());
        }
        //Returns a specific item in the section/category//
        [HttpGet]
        public ActionResult Details(Guid id)
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
                Dispose();
                return View(category);
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
            if (id == null)
            {
                return NotFound();
            }
            Category category = _cr.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            _cr.Remove(category);
            return RedirectToAction("Index");
        }







        //EDIT METHOD//
        //Returns a view of the selected item with its values to be edited//
        public ActionResult Edit(Guid id)
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
            return View(category);
        }
        //Edits/updates the selected item//
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (category == null)
            {
                return NotFound();
            }
            _cr.Update(category);
            return RedirectToAction("Index");
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
        public IActionResult Create(Category category)
        {
            if (category != null)
            {
                category.CategoryId = Guid.NewGuid();
                _cr.Add(category);
                return RedirectToAction("Index");
            }
            else
            {
                Dispose();
                return View(category);
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
