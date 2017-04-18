using ControleAlunos.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleAlunos.Web.Controllers
{
    public class GraficosController : Controller
    {
        // GET: Graficos
        private ControleAlunosContext db = new ControleAlunosContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grafico()
        {
            return View(Json(db.Alunos.ToList(), JsonRequestBehavior.AllowGet));
        }
    }
}