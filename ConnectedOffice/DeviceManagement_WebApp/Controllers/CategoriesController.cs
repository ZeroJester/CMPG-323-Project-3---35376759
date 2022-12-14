//Marcel Joubert - 35376759//

using System;
using Microsoft.AspNetCore.Mvc;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.EntityFrameworkCore;

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
            try
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
            catch(DbUpdateConcurrencyException)
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
            try
            {
                if (category == null)
                {
                    return NotFound();
                }
                _cr.Update(category);
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
        public IActionResult Create(Category category)
        {
            try
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
