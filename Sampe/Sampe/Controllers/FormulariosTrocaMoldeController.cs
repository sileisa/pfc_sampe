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
    public class FormulariosTrocaMoldeController : Controller
    {
        private SampeContext db = new SampeContext();

        // GET: FormulariosTrocaMolde
        public ActionResult Index()
        {
            var formularioTrocaMoldes = db.FormularioTrocaMoldes.Include(f => f.Maquina).Include(f => f.Molde).Include(f => f.Usuario);
            return View(formularioTrocaMoldes.ToList());
        }

        // GET: FormulariosTrocaMolde/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormularioTrocaMolde formularioTrocaMolde = db.FormularioTrocaMoldes.Find(id);
            if (formularioTrocaMolde == null)
            {
                return HttpNotFound();
            }
            return View(formularioTrocaMolde);
        }

        // GET: FormulariosTrocaMolde/Create
        public ActionResult Create()
        {
            ViewBag.MaquinaId = new SelectList(db.Maquinas, "MaquinaId", "NomeMaquina");
            ViewBag.MoldeId = new SelectList(db.Moldes, "MoldeId", "NomeMolde");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Hierarquia");
            return View();
        }

        // POST: FormulariosTrocaMolde/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormularioTrocaMoldeId,DtRetirada,DtColocar,ColocarInicio,ColocarFim,RetirarInicio,RetirarFim,Executante,MoldeId,MaquinaId,UsuarioId")] FormularioTrocaMolde formularioTrocaMolde)
        {
            if (ModelState.IsValid)
            {
                db.FormularioTrocaMoldes.Add(formularioTrocaMolde);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaquinaId = new SelectList(db.Maquinas, "MaquinaId", "NomeMaquina", formularioTrocaMolde.MaquinaId);
            ViewBag.MoldeId = new SelectList(db.Moldes, "MoldeId", "NomeMolde", formularioTrocaMolde.MoldeId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Hierarquia", formularioTrocaMolde.UsuarioId);
            return View(formularioTrocaMolde);
        }

        // GET: FormulariosTrocaMolde/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormularioTrocaMolde formularioTrocaMolde = db.FormularioTrocaMoldes.Find(id);
            if (formularioTrocaMolde == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaquinaId = new SelectList(db.Maquinas, "MaquinaId", "NomeMaquina", formularioTrocaMolde.MaquinaId);
            ViewBag.MoldeId = new SelectList(db.Moldes, "MoldeId", "NomeMolde", formularioTrocaMolde.MoldeId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Hierarquia", formularioTrocaMolde.UsuarioId);
            return View(formularioTrocaMolde);
        }

        // POST: FormulariosTrocaMolde/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormularioTrocaMoldeId,DtRetirada,DtColocar,ColocarInicio,ColocarFim,RetirarInicio,RetirarFim,Executante,MoldeId,MaquinaId,UsuarioId")] FormularioTrocaMolde formularioTrocaMolde)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formularioTrocaMolde).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaquinaId = new SelectList(db.Maquinas, "MaquinaId", "NomeMaquina", formularioTrocaMolde.MaquinaId);
            ViewBag.MoldeId = new SelectList(db.Moldes, "MoldeId", "NomeMolde", formularioTrocaMolde.MoldeId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Hierarquia", formularioTrocaMolde.UsuarioId);
            return View(formularioTrocaMolde);
        }

        // GET: FormulariosTrocaMolde/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormularioTrocaMolde formularioTrocaMolde = db.FormularioTrocaMoldes.Find(id);
            if (formularioTrocaMolde == null)
            {
                return HttpNotFound();
            }
            return View(formularioTrocaMolde);
        }

        // POST: FormulariosTrocaMolde/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormularioTrocaMolde formularioTrocaMolde = db.FormularioTrocaMoldes.Find(id);
            db.FormularioTrocaMoldes.Remove(formularioTrocaMolde);
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
