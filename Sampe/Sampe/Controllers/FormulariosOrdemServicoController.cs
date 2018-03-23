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
    public class FormulariosOrdemServicoController : Controller
    {
        private SampeContext db = new SampeContext();

        // GET: FormulariosOrdemServico
        public ActionResult Index()
        {
            var formularioOrdemServicoes = db.FormularioOrdemServicoes.Include(f => f.Maquina).Include(f => f.Usuario);
            return View(formularioOrdemServicoes.ToList());
        }

        // GET: FormulariosOrdemServico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormularioOrdemServico formularioOrdemServico = db.FormularioOrdemServicoes.Find(id);
            if (formularioOrdemServico == null)
            {
                return HttpNotFound();
            }
            return View(formularioOrdemServico);
        }

        // GET: FormulariosOrdemServico/Create
        public ActionResult Create()
        {
            ViewBag.MaquinaId = new SelectList(db.Maquinas, "MaquinaId", "NomeMaquina");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Hierarquia");
            return View();
        }

        // POST: FormulariosOrdemServico/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormularioOrdemServicoId,TipoManutencao,HoraInicio,HoraFinal,Dt,Intervalo,IntervaloInicio,IntervaloFim,ObsIntervalo,Executante,MaquinaId,UsuarioId")] FormularioOrdemServico formularioOrdemServico)
        {
            if (ModelState.IsValid)
            {
                db.FormularioOrdemServicoes.Add(formularioOrdemServico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaquinaId = new SelectList(db.Maquinas, "MaquinaId", "NomeMaquina", formularioOrdemServico.MaquinaId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Hierarquia", formularioOrdemServico.UsuarioId);
            return View(formularioOrdemServico);
        }

        // GET: FormulariosOrdemServico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormularioOrdemServico formularioOrdemServico = db.FormularioOrdemServicoes.Find(id);
            if (formularioOrdemServico == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaquinaId = new SelectList(db.Maquinas, "MaquinaId", "NomeMaquina", formularioOrdemServico.MaquinaId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Hierarquia", formularioOrdemServico.UsuarioId);
            return View(formularioOrdemServico);
        }

        // POST: FormulariosOrdemServico/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormularioOrdemServicoId,TipoManutencao,HoraInicio,HoraFinal,Dt,Intervalo,IntervaloInicio,IntervaloFim,ObsIntervalo,Executante,MaquinaId,UsuarioId")] FormularioOrdemServico formularioOrdemServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formularioOrdemServico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaquinaId = new SelectList(db.Maquinas, "MaquinaId", "NomeMaquina", formularioOrdemServico.MaquinaId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Hierarquia", formularioOrdemServico.UsuarioId);
            return View(formularioOrdemServico);
        }

        // GET: FormulariosOrdemServico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormularioOrdemServico formularioOrdemServico = db.FormularioOrdemServicoes.Find(id);
            if (formularioOrdemServico == null)
            {
                return HttpNotFound();
            }
            return View(formularioOrdemServico);
        }

        // POST: FormulariosOrdemServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormularioOrdemServico formularioOrdemServico = db.FormularioOrdemServicoes.Find(id);
            db.FormularioOrdemServicoes.Remove(formularioOrdemServico);
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
