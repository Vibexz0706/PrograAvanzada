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
    public class TAB_RECETASController : Controller
    {
        private ProyectoEntities2 db = new ProyectoEntities2();

        // GET: TAB_RECETAS
        public ActionResult Index()
        {
            var tAB_RECETAS = db.TAB_RECETAS.Include(t => t.TAB_CATEGORIAS).Include(t => t.TAB_ESTADO).Include(t => t.TAB_TAGS);
            return View(tAB_RECETAS.ToList());
        }

        // GET: TAB_RECETAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_RECETAS tAB_RECETAS = db.TAB_RECETAS.Find(id);
            if (tAB_RECETAS == null)
            {
                return HttpNotFound();
            }
            return View(tAB_RECETAS);
        }

        // GET: TAB_RECETAS/Create
        public ActionResult Create()
        {
            ViewBag.ID_CATEGORIA = new SelectList(db.TAB_CATEGORIAS, "ID_CATEGORIA", "CATEGORIA");
            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO");
            ViewBag.ID_TAGS = new SelectList(db.TAB_TAGS, "ID_TAGS", "TAGS");
            return View();
        }

        // POST: TAB_RECETAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_RECETA,NOM_RECETA,ID_CATEGORIA,DURACION,PORCIONES,ID_TAGS,ID_ESTADO,UserName,FECHA_CREACION,FECHA_MODIFICACION")] TAB_RECETAS tAB_RECETAS)
        {
            if (ModelState.IsValid)
            {
                db.TAB_RECETAS.Add(tAB_RECETAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CATEGORIA = new SelectList(db.TAB_CATEGORIAS, "ID_CATEGORIA", "CATEGORIA", tAB_RECETAS.ID_CATEGORIA);
            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO", tAB_RECETAS.ID_ESTADO);
            ViewBag.ID_TAGS = new SelectList(db.TAB_TAGS, "ID_TAGS", "TAGS", tAB_RECETAS.ID_TAGS);
            return View(tAB_RECETAS);
        }

        // GET: TAB_RECETAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_RECETAS tAB_RECETAS = db.TAB_RECETAS.Find(id);
            if (tAB_RECETAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.TAB_CATEGORIAS, "ID_CATEGORIA", "CATEGORIA", tAB_RECETAS.ID_CATEGORIA);
            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO", tAB_RECETAS.ID_ESTADO);
            ViewBag.ID_TAGS = new SelectList(db.TAB_TAGS, "ID_TAGS", "TAGS", tAB_RECETAS.ID_TAGS);
            return View(tAB_RECETAS);
        }

        // POST: TAB_RECETAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_RECETA,NOM_RECETA,ID_CATEGORIA,DURACION,PORCIONES,ID_TAGS,ID_ESTADO,UserName,FECHA_CREACION,FECHA_MODIFICACION")] TAB_RECETAS tAB_RECETAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAB_RECETAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.TAB_CATEGORIAS, "ID_CATEGORIA", "CATEGORIA", tAB_RECETAS.ID_CATEGORIA);
            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO", tAB_RECETAS.ID_ESTADO);
            ViewBag.ID_TAGS = new SelectList(db.TAB_TAGS, "ID_TAGS", "TAGS", tAB_RECETAS.ID_TAGS);
            return View(tAB_RECETAS);
        }

        // GET: TAB_RECETAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_RECETAS tAB_RECETAS = db.TAB_RECETAS.Find(id);
            if (tAB_RECETAS == null)
            {
                return HttpNotFound();
            }
            return View(tAB_RECETAS);
        }

        // POST: TAB_RECETAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAB_RECETAS tAB_RECETAS = db.TAB_RECETAS.Find(id);
            db.TAB_RECETAS.Remove(tAB_RECETAS);
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
