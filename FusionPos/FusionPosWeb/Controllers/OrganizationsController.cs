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
    public class OrganizationsController : Controller
    {
        private OrganizationManager organizationManager =new OrganizationManager();

        // GET: Organizations
        public ActionResult Index()
        {
            return View(organizationManager.GetAll());
        }

        // GET: Organizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = organizationManager.Get(o=>o.Id==id).FirstOrDefault();
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            Organization organization =new Organization();
            return View(organization);
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Code,ContactNo,Address")] Organization organization,HttpPostedFileBase LogoImage)
        {
            if (ModelState.IsValid)
            {
                if (LogoImage != null)
                {
                    
                    organization.LogoImage =new byte[LogoImage.ContentLength];
                    LogoImage.InputStream.Read(organization.LogoImage, 0, LogoImage.ContentLength);
                }
                organizationManager.Add(organization);
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        // GET: Organizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = organizationManager.Get(o=>o.Id==id).FirstOrDefault();
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code,ContactNo,LogoImage,Address")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                organizationManager.Upate(organization);
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        // GET: Organizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = organizationManager.Get(o=>o.Id==id).FirstOrDefault();
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organization = organizationManager.Get(o=>o.Id==id).FirstOrDefault();
            organizationManager.Remove(organization);
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
