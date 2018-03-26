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
    public class UsuariosController : Controller
    {

        private SampeContext db = new SampeContext();

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario)
        {
            var usuarios = db.Usuarios;

            foreach (var item in usuarios)
            {
                if (usuario.Login == item.Login && usuario.Senha == item.Senha)
                {
                    return RedirectToAction("PagInicial");
                }
                else
                {
                    //ModelState.AddModelError("Login", "Login e/ou senha inválidos");
                }

            }

            return View("Login");
        }

        public ActionResult PagInicial()
        {
            return View();
        }
        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.Cargo);
            return View(usuarios.ToList());
        }

       
        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.CargoId = new SelectList(db.Cargoes, "CargoId", "NomeCargo");
            return View();
        }

        // POST: Usuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NomeUsuario,SobrenomeUsuario,Login,Senha,Hierarquia,CargoId,UsuarioId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CargoId = new SelectList(db.Cargoes, "CargoId", "NomeCargo", usuario.CargoId);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.CargoId = new SelectList(db.Cargoes, "CargoId", "NomeCargo", usuario.CargoId);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NomeUsuario,SobrenomeUsuario,Login,Senha,Hierarquia,CargoId,UsuarioId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CargoId = new SelectList(db.Cargoes, "CargoId", "NomeCargo", usuario.CargoId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /* // GET: Usuarios/Delete/5
         public ActionResult Login(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Usuario usuario = db.Usuarios.Find(id);
             if (usuario == null)
             {
                 return HttpNotFound();
             }
             return View(usuario);
         }

         // POST: Usuarios/Delete/5
         [HttpPost, ActionName("Login")]
         [ValidateAntiForgeryToken]
         public ActionResult LoginConfirmed(int id, String login, String senha)
         {

             Usuario usuario = db.Usuarios.Find(id);


             if (usuario.Login != login  &&  usuario.Senha != senha )
             {
                 ModelState.AddModelError("Login", "Login e/ou senha inválidos");
             }


             return RedirectToAction("Home/Index");
         }*/
        // GET: Usuarios/Create
        public ActionResult Teste()
        {

            return View();
        }

        // POST: Usuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]        
        public ActionResult Teste( String login, String senha)
        {
            var usuarios = db.Usuarios;
            foreach (var item in usuarios)
            {

                if (login == item.Login && senha == item.Senha)
                {
                    return RedirectToAction("Index");
                }
            }
           
            return View();
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
