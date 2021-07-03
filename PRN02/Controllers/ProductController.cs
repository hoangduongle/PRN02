using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN02.Areas.Identity.Data;
using PRN02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN02.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly DBImportManagementContext _context;
        public ProductController(DBImportManagementContext context)
        {
            _context = context;
        }
        //testttt
        public IActionResult Index()
        {
            var ListProduct = from p in _context.Products
                              join c in _context.Categories
                              on p.CategoryID equals c.CategoryID
                              select (new Product()
                              {
                                  ProductID = p.ProductID,
                                  ProductName = p.ProductName,
                                  Quantity = p.Quantity,
                                  DateIn = p.DateIn,
                                  TotalPrice = p.TotalPrice,
                                  CategoryID = p.CategoryID,
                                  CateID = c
                              });
            return View(ListProduct.ToList());
        }


        //GET Create
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (ProductExists(product.ProductID))
                {
                    return RedirectToAction(nameof(Index));
                }
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        //Get Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product p = _context.Products.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        //GET Product/Edit/id
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product p = _context.Products.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            ViewData["CateID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", p.CateID);

            return View(p);
        }

        //Post Product/Edit/
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (!ProductExists(product.ProductID))
                {
                    return NotFound();
                }
                Product p = _context.Products.Find(product.ProductID);
                p.ProductName = product.ProductName;
                p.Quantity = product.Quantity;
                p.DateIn = product.DateIn;
                p.TotalPrice = product.TotalPrice;
                p.CategoryID = product.CategoryID;
                _context.Products.Update(p);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        //GET Product/delete/id
        public IActionResult Delete(int id)
        {
            Product p = _context.Products.Find(id);
            _context.Products.Remove(p);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //GET List Report sort by Date
        [Authorize(Roles = "Admin")]
        public IActionResult Report()
        {
            var ListReport = from p in _context.Products
                             orderby p.DateIn ascending
                             select p;
            return View(ListReport.ToList());
        }

        //POST Report
        [Authorize(Roles = "Admin")]
        public IActionResult Sort(DateTime SmallDate, DateTime BigDate)
        {
            var ListReport = _context.Products.Where(p => p.DateIn >= SmallDate && p.DateIn < BigDate).ToList();
            return View("Report", ListReport);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(p => p.ProductID == id);
        }






    }
}
