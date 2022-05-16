using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dia11v2;

namespace dia11v2.Controllers
{
    public class WebsController : Controller
    {
        private Dia11Entities db = new Dia11Entities();

        // GET: Webs
        public ActionResult Index()
        {
            return View(db.Web.ToList());
        }

        // GET: Webs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Web web = db.Web.Find(id);
            if (web == null)
            {
                return HttpNotFound();
            }
            return View(web);
        }

        // GET: Webs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Webs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Marca,Modelo,Año,Kilometros,Precio")] Web web)
        {
            if (ModelState.IsValid)
            {
                db.Web.Add(web);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(web);
        }

        // GET: Webs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Web web = db.Web.Find(id);
            if (web == null)
            {
                return HttpNotFound();
            }
            return View(web);
        }

        // POST: Webs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Marca,Modelo,Año,Kilometros,Precio")] Web web)
        {
            if (ModelState.IsValid)
            {
                db.Entry(web).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(web);
        }

        // GET: Webs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Web web = db.Web.Find(id);
            if (web == null)
            {
                return HttpNotFound();
            }
            return View(web);
        }

        // POST: Webs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Web web = db.Web.Find(id);
            db.Web.Remove(web);
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
