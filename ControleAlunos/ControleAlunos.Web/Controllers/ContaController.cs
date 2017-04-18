using ControleAlunos.Web.Data;
using ControleAlunos.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ControleAlunos.Web.Controllers
{
    public class ContaController : Controller
    {
        private ControleAlunosContext db = new ControleAlunosContext();

        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Usuario Login, string returnurl)
        {
            var resultado = db.Usuarios.Where(x => x.email == Login.email && x.senha == Login.senha).ToList();

            if (resultado.Count == 1)
            {
                FormsAuthentication.SetAuthCookie(Login.email, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Login Inválido");
            }

            return View(Login);
        }

        [HttpPost]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Conta");
        }
    }
}