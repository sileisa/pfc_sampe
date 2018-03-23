using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sampe;
using Sampe.Models;

namespace Sampe.Controllers
{
    public class AtividadesFormularioOSController : Controller
    {
        private SampeContext db = new SampeContext();

        // GET: AtividadesFormularioOS
        public ActionResult Index()
        {
            var atividadeFormularioOS = db.AtividadeFormularioOS.Include(a => a.FormularioOrdemServico);
            return View(atividadeFormularioOS.ToList());
        }

        // GET: AtividadesFormularioOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtividadeFormularioOS atividadeFormularioOS = db.AtividadeFormularioOS.Find(id);
            if (atividadeFormularioOS == null)
            {
                return HttpNotFound();
            }
            return View(atividadeFormularioOS);
        }

        // GET: AtividadesFormularioOS/Create
        public ActionResult Create()
        {
            ViewBag.FormularioOrdemServicoId = new SelectList(db.FormularioOrdemServicoes, "FormularioOrdemServicoId", "TipoManutencao");
            return View();
        }

        // POST: AtividadesFormularioOS/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AtividadeFormularioOSId,AtividadeOSId,StatusAtividadeOS,FormularioOrdemServicoId")] AtividadeFormularioOS atividadeFormularioOS)
        {
            if (ModelState.IsValid)
            {
                db.AtividadeFormularioOS.Add(atividadeFormularioOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormularioOrdemServicoId = new SelectList(db.FormularioOrdemServicoes, "FormularioOrdemServicoId", "TipoManutencao", atividadeFormularioOS.FormularioOrdemServicoId);
            return View(atividadeFormularioOS);
        }

        // GET: AtividadesFormularioOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtividadeFormularioOS atividadeFormularioOS = db.AtividadeFormularioOS.Find(id);
            if (atividadeFormularioOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormularioOrdemServicoId = new SelectList(db.FormularioOrdemServicoes, "FormularioOrdemServicoId", "TipoManutencao", atividadeFormularioOS.FormularioOrdemServicoId);
            return View(atividadeFormularioOS);
        }

        // POST: AtividadesFormularioOS/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AtividadeFormularioOSId,AtividadeOSId,StatusAtividadeOS,FormularioOrdemServicoId")] AtividadeFormularioOS atividadeFormularioOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atividadeFormularioOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormularioOrdemServicoId = new SelectList(db.FormularioOrdemServicoes, "FormularioOrdemServicoId", "TipoManutencao", atividadeFormularioOS.FormularioOrdemServicoId);
            return View(atividadeFormularioOS);
        }

        // GET: AtividadesFormularioOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtividadeFormularioOS atividadeFormularioOS = db.AtividadeFormularioOS.Find(id);
            if (atividadeFormularioOS == null)
            {
                return HttpNotFound();
            }
            return View(atividadeFormularioOS);
        }

        // POST: AtividadesFormularioOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AtividadeFormularioOS atividadeFormularioOS = db.AtividadeFormularioOS.Find(id);
            db.AtividadeFormularioOS.Remove(atividadeFormularioOS);
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
