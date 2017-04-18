using ControleAlunos.Web.Data;
using ControleAlunos.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ControleAlunos.Web.Controllers
{
    public class AlunosCidadesController : Controller
    {
        private ControleAlunosContext db = new ControleAlunosContext();

        public ActionResult Index()
        {
            return View(db.Cidades.ToList());
        }
        public ActionResult Details(int? id)
        {
            return View(db.Alunos.Where(s => s.CidadeId == id).ToList());
        }
    }
}