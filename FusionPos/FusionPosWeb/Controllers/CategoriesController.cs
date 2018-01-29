using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FusionPosBll;
using FusionPosModels.EntityModels;

namespace FusionPosWeb.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryManager categoryManager =new CategoryManager();

        // GET: Categories
        public ActionResult Index()
        {
            var categories = categoryManager.GetAll();
            return View(categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Category category = db.Categories.Find(id);
            Category category= categoryManager.Get(c => c.Id == id).FirstOrDefault();
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(categoryManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Code,Description,IsRoot,ParentId,Image")] Category category)
        {
            if (ModelState.IsValid)
            {
                bool res =categoryManager.Add(category);
                if (res)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Create");
                }
                
            }

            ViewBag.ParentId = new SelectList(categoryManager.GetAll(), "Id", "Name", category.ParentId);
            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryManager.Get(c=>c.Id==id).FirstOrDefault();
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(categoryManager.GetAll(), "Id", "Name", category.ParentId);
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code,Description,IsRoot,ParentId,Image")] Category category)
        {
            if (ModelState.IsValid)
            {
                bool res = categoryManager.Upate(category);
                if (res)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Edit");
                }
            }
            ViewBag.ParentId = new SelectList(categoryManager.GetAll(), "Id", "Name", category.ParentId);
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Category category = categoryManager.Get(c=>c.Id==id).FirstOrDefault();
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = categoryManager.Get(c=>c.Id==id).FirstOrDefault();
            bool res = categoryManager.Remove(category);
            
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
