using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN02.Areas.Identity.Data;
using PRN02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN02.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly DBImportManagementContext _context;
        public CategoriesController(DBImportManagementContext context)
        {
            _context = context;
        }

        // getList
        public IActionResult Index()
        {           
            return View(_context.Categories.ToList());
        }

        // GET Create
        public IActionResult Create()
        {
            return View();
        }

        // POST Create
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        //GET Categories/Details/id
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var Category = _context.Categories.Find(id);
            if(Category == null)
            {
                return NotFound();
            }

            return View(Category);
        }

        //GET Categories/Edit/id
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Category = _context.Categories.Find(id);
            if (Category == null)
            {
                return NotFound();
            }
            return View(Category);
        }

        //POST Update
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            int cateID = category.CategoryID;
            string cateName = category.CategoryName;
            Category Category = _context.Categories.Find(cateID);
            if (ModelState.IsValid)
            {
                try
                {
                    
                    Category.CategoryName = cateName;
                    _context.Update(Category);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Category);
        }

        //GET Categories/Delete/id
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Category category = _context.Categories.Find(id);
            
            if(category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryID == id);
        }
    }
}
