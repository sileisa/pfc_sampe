using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sampe.Models;

namespace Sampe.Controllers
{
    public class AtividadesFormularioTMController : Controller
    {
        private SampeContext db = new SampeContext();

        // GET: AtividadesFormularioTM
        public ActionResult Index()
        {
            var atividadeFormularioTMs = db.AtividadeFormularioTMs.Include(a => a.FormularioTrocaMolde);
            return View(atividadeFormularioTMs.ToList());
        }

        // GET: AtividadesFormularioTM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtividadeFormularioTM atividadeFormularioTM = db.AtividadeFormularioTMs.Find(id);
            if (atividadeFormularioTM == null)
            {
                return HttpNotFound();
            }
            return View(atividadeFormularioTM);
        }

        // GET: AtividadesFormularioTM/Create
        public ActionResult Create()
        {
            ViewBag.FormularioTrocaMoldeId = new SelectList(db.FormularioTrocaMoldes, "FormularioTrocaMoldeId", "DtRetirada");
            return View();
        }

        // POST: AtividadesFormularioTM/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AtividadeFormularioTMId,AtividadeTMId,StatusAtividadeTM,FormularioTrocaMoldeId")] AtividadeFormularioTM atividadeFormularioTM)
        {
            if (ModelState.IsValid)
            {
                db.AtividadeFormularioTMs.Add(atividadeFormularioTM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormularioTrocaMoldeId = new SelectList(db.FormularioTrocaMoldes, "FormularioTrocaMoldeId", "DtRetirada", atividadeFormularioTM.FormularioTrocaMoldeId);
            return View(atividadeFormularioTM);
        }

        // GET: AtividadesFormularioTM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtividadeFormularioTM atividadeFormularioTM = db.AtividadeFormularioTMs.Find(id);
            if (atividadeFormularioTM == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormularioTrocaMoldeId = new SelectList(db.FormularioTrocaMoldes, "FormularioTrocaMoldeId", "DtRetirada", atividadeFormularioTM.FormularioTrocaMoldeId);
            return View(atividadeFormularioTM);
        }

        // POST: AtividadesFormularioTM/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AtividadeFormularioTMId,AtividadeTMId,StatusAtividadeTM,FormularioTrocaMoldeId")] AtividadeFormularioTM atividadeFormularioTM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atividadeFormularioTM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormularioTrocaMoldeId = new SelectList(db.FormularioTrocaMoldes, "FormularioTrocaMoldeId", "DtRetirada", atividadeFormularioTM.FormularioTrocaMoldeId);
            return View(atividadeFormularioTM);
        }

        // GET: AtividadesFormularioTM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtividadeFormularioTM atividadeFormularioTM = db.AtividadeFormularioTMs.Find(id);
            if (atividadeFormularioTM == null)
            {
                return HttpNotFound();
            }
            return View(atividadeFormularioTM);
        }

        // POST: AtividadesFormularioTM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AtividadeFormularioTM atividadeFormularioTM = db.AtividadeFormularioTMs.Find(id);
            db.AtividadeFormularioTMs.Remove(atividadeFormularioTM);
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
