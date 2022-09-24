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
        //[Route("devices")]
        public IActionResult Index()
        {
            //return View(db.Products.ToList());
            return View(_cr.GetAll());
        }
    }
}
