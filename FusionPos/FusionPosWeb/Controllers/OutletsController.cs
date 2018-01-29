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
    public class OutletsController : Controller
    {
        private OutletManager outletManager =new OutletManager();
        private OrganizationManager organizationManager =new OrganizationManager();

        // GET: Outlets
        public ActionResult Index()
        {
            var outlets = outletManager.GetAll();
            return View(outlets.ToList());
        }

        // GET: Outlets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outlet outlet = outletManager.Get(o=>o.Id==id).FirstOrDefault();
            if (outlet == null)
            {
                return HttpNotFound();
            }
            return View(outlet);
        }

        // GET: Outlets/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationId = new SelectList(organizationManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Outlets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,ContactNo,Address,OrganizationId")] Outlet outlet)
        {
            if (ModelState.IsValid)
            {
                outletManager.Add(outlet);
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = new SelectList(organizationManager.GetAll(), "Id", "Name", outlet.OrganizationId);
            return View(outlet);
        }

        // GET: Outlets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outlet outlet = outletManager.Get(o=>o.Id==id).FirstOrDefault();
            if (outlet == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = new SelectList(organizationManager.GetAll(), "Id", "Name", outlet.OrganizationId);
            return View(outlet);
        }

        // POST: Outlets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,ContactNo,Address,OrganizationId")] Outlet outlet)
        {
            if (ModelState.IsValid)
            {
                outletManager.Upate(outlet);
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = new SelectList(organizationManager.GetAll(), "Id", "Name", outlet.OrganizationId);
            return View(outlet);
        }

        // GET: Outlets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outlet outlet = outletManager.Get(o=>o.Id==id).FirstOrDefault();
            if (outlet == null)
            {
                return HttpNotFound();
            }
            return View(outlet);
        }

        // POST: Outlets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outlet outlet = outletManager.Get(o=>o.Id==id).FirstOrDefault();
            outletManager.Remove(outlet);
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
