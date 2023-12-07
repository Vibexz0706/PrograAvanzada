﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoProgra.Models;

namespace ProyectoProgra.Controllers
{
    public class TAB_TAGSController : Controller
    {
        private ProyectoEntities2 db = new ProyectoEntities2();

        // GET: TAB_TAGS
        public ActionResult Index()
        {
            return View(db.TAB_TAGS.ToList());
        }

        // GET: TAB_TAGS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_TAGS tAB_TAGS = db.TAB_TAGS.Find(id);
            if (tAB_TAGS == null)
            {
                return HttpNotFound();
            }
            return View(tAB_TAGS);
        }

        // GET: TAB_TAGS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TAB_TAGS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TAGS,TAGS")] TAB_TAGS tAB_TAGS)
        {
            if (ModelState.IsValid)
            {
                db.TAB_TAGS.Add(tAB_TAGS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tAB_TAGS);
        }

        // GET: TAB_TAGS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_TAGS tAB_TAGS = db.TAB_TAGS.Find(id);
            if (tAB_TAGS == null)
            {
                return HttpNotFound();
            }
            return View(tAB_TAGS);
        }

        // POST: TAB_TAGS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TAGS,TAGS")] TAB_TAGS tAB_TAGS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAB_TAGS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tAB_TAGS);
        }

        // GET: TAB_TAGS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_TAGS tAB_TAGS = db.TAB_TAGS.Find(id);
            if (tAB_TAGS == null)
            {
                return HttpNotFound();
            }
            return View(tAB_TAGS);
        }

        // POST: TAB_TAGS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAB_TAGS tAB_TAGS = db.TAB_TAGS.Find(id);
            db.TAB_TAGS.Remove(tAB_TAGS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
