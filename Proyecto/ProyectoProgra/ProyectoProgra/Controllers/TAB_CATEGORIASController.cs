using System;
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
    public class TAB_CATEGORIASController : Controller
    {
        private ProyectoEntities2 db = new ProyectoEntities2();

        // GET: TAB_CATEGORIAS
        public ActionResult Index()
        {
            return View(db.TAB_CATEGORIAS.ToList());
        }

        // GET: TAB_CATEGORIAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_CATEGORIAS tAB_CATEGORIAS = db.TAB_CATEGORIAS.Find(id);
            if (tAB_CATEGORIAS == null)
            {
                return HttpNotFound();
            }
            return View(tAB_CATEGORIAS);
        }

        // GET: TAB_CATEGORIAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TAB_CATEGORIAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CATEGORIA,CATEGORIA")] TAB_CATEGORIAS tAB_CATEGORIAS)
        {
            if (ModelState.IsValid)
            {
                db.TAB_CATEGORIAS.Add(tAB_CATEGORIAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tAB_CATEGORIAS);
        }

        // GET: TAB_CATEGORIAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_CATEGORIAS tAB_CATEGORIAS = db.TAB_CATEGORIAS.Find(id);
            if (tAB_CATEGORIAS == null)
            {
                return HttpNotFound();
            }
            return View(tAB_CATEGORIAS);
        }

        // POST: TAB_CATEGORIAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CATEGORIA,CATEGORIA")] TAB_CATEGORIAS tAB_CATEGORIAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAB_CATEGORIAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tAB_CATEGORIAS);
        }

        // GET: TAB_CATEGORIAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_CATEGORIAS tAB_CATEGORIAS = db.TAB_CATEGORIAS.Find(id);
            if (tAB_CATEGORIAS == null)
            {
                return HttpNotFound();
            }
            return View(tAB_CATEGORIAS);
        }

        // POST: TAB_CATEGORIAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAB_CATEGORIAS tAB_CATEGORIAS = db.TAB_CATEGORIAS.Find(id);
            db.TAB_CATEGORIAS.Remove(tAB_CATEGORIAS);
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
