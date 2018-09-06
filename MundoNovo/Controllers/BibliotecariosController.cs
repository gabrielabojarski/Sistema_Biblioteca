using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MundoNovo.Models;
using MundoNovo.DAL;
using MundoNovo.Utils;

namespace MundoNovo.Controllers
{
    public class BibliotecariosController : Controller
    {
       // private Context db = new Context();

        // GET: Bibliotecarios
        public ActionResult Index()
        {
            return View(BibliotecarioDAO.ListarBibliotecarios());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entrar([Bind(Include = "login,senha")] Bibliotecario bibliotecario)
        {
            int loginId = BibliotecarioDAO.Login(bibliotecario);
            if (loginId != 0)
            {
                bibliotecario = BibliotecarioDAO.BuscarBibliotecarioPorId(loginId);

                string guid = Sessao.RetornarGuidId();
                bibliotecario.guid = guid;
                BibliotecarioDAO.EditarBibliotecario(bibliotecario);
                return View("Index", BibliotecarioDAO.ListarBibliotecarios());
            }
            else
            {
                return View("Login");
            }

        }

        public ActionResult Sair()
        {
            Sessao.ReiniciarSessao();
            return View("Login");
        }

        // GET: Bibliotecarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bibliotecarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,login,senha,nome,matricula")] Bibliotecario bibliotecario)
        {
            if (ModelState.IsValid)
            {
                BibliotecarioDAO.CadastrarBibliotecario(bibliotecario);
                return RedirectToAction("Index");
            }

            return View(bibliotecario);
        }

        // GET: Bibliotecarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliotecario bibliotecario = BibliotecarioDAO.BuscarBibliotecarioPorId(id);
            if (bibliotecario == null)
            {
                return HttpNotFound();
            }
            return View(bibliotecario);
        }

        // POST: Bibliotecarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,login,senha,nome,matricula")] Bibliotecario bibliotecario)
        {
            if (ModelState.IsValid)
            {
                Bibliotecario bibliotecarioAux = BibliotecarioDAO.BuscarBibliotecarioPorId(bibliotecario.id);
                bibliotecario.guid = bibliotecarioAux.guid;
                BibliotecarioDAO.RemoverBibliotecario(bibliotecarioAux);
                BibliotecarioDAO.CadastrarBibliotecario(bibliotecario);

                return RedirectToAction("Index");
            }
            return View(bibliotecario);
        }

        // GET: Bibliotecarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliotecario bibliotecario = BibliotecarioDAO.BuscarBibliotecarioPorId(id);
            if (bibliotecario == null)
            {
                return HttpNotFound();
            }
            return View(bibliotecario);
        }

        // POST: Bibliotecarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bibliotecario bibliotecario = BibliotecarioDAO.BuscarBibliotecarioPorId(id);
            BibliotecarioDAO.RemoverBibliotecario(bibliotecario);
            return RedirectToAction("Index");
        }

      
    }
}
