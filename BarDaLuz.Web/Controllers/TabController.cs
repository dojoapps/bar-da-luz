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
    public class TabController : Controller
    {
        private BarDaLuzContext db = new BarDaLuzContext();

        //
        // GET: /Tab/

        public ViewResult Index()
        {
            return View(db.Tabs.ToList());
        }

        //
        // GET: /Tab/Details/5

        public ViewResult Details(int id)
        {
            Tab tab = db.Tabs.Find(id);
            return View(tab);
        }

        //
        // GET: /Tab/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Tab/Create

        [HttpPost]
        public ActionResult Create(Tab tab)
        {
            if (ModelState.IsValid)
            {
                db.Tabs.Add(tab);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tab);
        }
        
        //
        // GET: /Tab/Edit/5
 
        public ActionResult Edit(int id)
        {
            Tab tab = db.Tabs.Find(id);
            return View(tab);
        }

        //
        // POST: /Tab/Edit/5

        [HttpPost]
        public ActionResult Edit(Tab tab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tab);
        }

        //
        // GET: /Tab/Delete/5
 
        public ActionResult Delete(int id)
        {
            Tab tab = db.Tabs.Find(id);
            return View(tab);
        }

        //
        // POST: /Tab/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Tab tab = db.Tabs.Find(id);
            db.Tabs.Remove(tab);
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