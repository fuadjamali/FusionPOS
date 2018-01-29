using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FusionPosModels.EntityModels;
using FusionPosBll;

namespace FusionPosWeb.Controllers
{
    public class ItemsController : Controller
    {
        private ItemManager itemManager = new ItemManager();
        private CategoryManager categoryManager = new CategoryManager();

        // GET: Items
        public ActionResult Index()
        {
            var items = itemManager.GetAll();
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = itemManager.Get(i=>i.Id==id).FirstOrDefault();
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(categoryManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,Description,CostPrice,SalePrice,Image,CategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                itemManager.Add(item);
                
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(categoryManager.GetAll(), "Id", "Name", item.CategoryId);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = itemManager.Get(i=>i.Id==id).FirstOrDefault();
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(categoryManager.GetAll(), "Id", "Name", item.CategoryId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Description,CostPrice,SalePrice,Image,CategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                itemManager.Upate(item);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(categoryManager.GetAll(), "Id", "Name", item.CategoryId);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = itemManager.Get(i=>i.Id==id).FirstOrDefault();
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = itemManager.Get(i=>i.Id==id).FirstOrDefault();
            itemManager.Remove(item);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               
            }
            base.Dispose(disposing);
        }
    }
}
