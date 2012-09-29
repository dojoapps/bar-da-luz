using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarDaLuz.Db;

namespace BarDaLuz.Web.Controllers
{ 
    public class ProductTabController : Controller
    {
        private BarDaLuzContext db = new BarDaLuzContext();

        //
        // GET: /ProductTab/

        public ViewResult Index()
        {
            var productstabs = db.ProductsTabs.Include(p => p.Product).Include(p => p.Tab);
            return View(productstabs.ToList());
        }

        //
        // GET: /ProductTab/Details/5

        public ViewResult Details(int id)
        {
            ProductTab producttab = db.ProductsTabs.Find(id);
            return View(producttab);
        }

        //
        // GET: /ProductTab/Create

        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            ViewBag.TabId = new SelectList(db.Tabs, "Id", "Code");
            return View();
        } 

        //
        // POST: /ProductTab/Create

        [HttpPost]
        public ActionResult Create(ProductTab producttab)
        {
            if (ModelState.IsValid)
            {
                db.ProductsTabs.Add(producttab);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", producttab.ProductId);
            ViewBag.TabId = new SelectList(db.Tabs, "Id", "Code", producttab.TabId);
            return View(producttab);
        }
        
        //
        // GET: /ProductTab/Edit/5
 
        public ActionResult Edit(int id)
        {
            ProductTab producttab = db.ProductsTabs.Find(id);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", producttab.ProductId);
            ViewBag.TabId = new SelectList(db.Tabs, "Id", "Code", producttab.TabId);
            return View(producttab);
        }

        //
        // POST: /ProductTab/Edit/5

        [HttpPost]
        public ActionResult Edit(ProductTab producttab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producttab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", producttab.ProductId);
            ViewBag.TabId = new SelectList(db.Tabs, "Id", "Code", producttab.TabId);
            return View(producttab);
        }

        //
        // GET: /ProductTab/Delete/5
 
        public ActionResult Delete(int id)
        {
            ProductTab producttab = db.ProductsTabs.Find(id);
            return View(producttab);
        }

        //
        // POST: /ProductTab/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            ProductTab producttab = db.ProductsTabs.Find(id);
            db.ProductsTabs.Remove(producttab);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}