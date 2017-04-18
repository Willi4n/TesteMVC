using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleAlunos.Web.Data;
using ControleAlunos.Web.Models;

namespace ControleAlunos.Web.Controllers
{
    public class AlunoesController : Controller
    {
        private ControleAlunosContext db = new ControleAlunosContext();

        // GET: Alunoes
        public ActionResult Index()
        {
            var alunos = db.Alunos.Include(a => a.Cidade);
            return View(alunos.ToList());
        }

        // GET: Alunoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Alunoes/Create
        public ActionResult Create()
        {
            ViewBag.CidadeId = new SelectList(db.Cidades, "Id", "nome");
            return View();
        }

        // POST: Alunoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,matricula,dataNascimento,dataCadastro,endereco,sexo,idade,dataAlteracao,usuarioAlteracao,CidadeId,nome,cpf,rg,telefone,email,nomePai,nomeMae,rgPai,rgMae,cpfPai,cpfMae,profissaoPai,profissaoMae,telefonePai,telefoneMae,emailPai,emailMae")] Aluno aluno)
        {
            if (aluno.nomePai == null || aluno.cpfPai == null || aluno.rgPai == null || aluno.telefonePai == null || aluno.emailPai == null)
            {
                ModelState.AddModelError("", "Preencha todas as informações sobre o pai");
            }
            else if(aluno.nomeMae == null || aluno.cpfMae == null || aluno.rgMae == null || aluno.telefoneMae == null || aluno.emailMae == null)
            {
                ModelState.AddModelError("", "Preencha todas as informações sobre a mãe");
            }
            else
            {
                aluno.Pais = new List<Pais>();

                Pais pai = new Pais();
                pai.nome = aluno.nomePai;
                pai.rg = aluno.rgPai;
                pai.cpf = aluno.cpfPai;
                pai.email = aluno.emailPai;
                pai.telefone = aluno.telefonePai;
                pai.filiacao = "p";
                pai.dataCadastro = DateTime.Now.Date;
                db.Pais.Add(pai);

                aluno.Pais.Add(pai);

                Pais mae = new Pais();
                mae.nome = aluno.nomeMae;
                mae.rg = aluno.rgMae;
                mae.cpf = aluno.cpfMae;
                mae.email = aluno.emailMae;
                mae.telefone = aluno.telefoneMae;
                mae.filiacao = "m";
                mae.dataCadastro = DateTime.Now;
                db.Pais.Add(mae);

                aluno.Pais.Add(mae);

                aluno.dataCadastro = DateTime.Now;          

                if (ModelState.IsValid)
                {
                    db.Alunos.Add(aluno);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }                
            }

            ViewBag.CidadeId = new SelectList(db.Cidades, "Id", "nome", aluno.CidadeId);
            return View(aluno);
        }

        // GET: Alunoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);

            foreach (Pais p in aluno.Pais)
            {
                if (p.filiacao.Equals("p"))
                {
                    aluno.nomePai = p.nome;
                    aluno.cpfPai = p.cpf;
                    aluno.rgPai = p.rg;
                    aluno.telefonePai = p.telefone;
                    aluno.emailPai = p.email;


                }
                else
                {
                    aluno.nomeMae = p.nome;
                    aluno.cpfMae = p.cpf;
                    aluno.rgMae = p.rg;
                    aluno.telefoneMae = p.telefone;
                    aluno.emailMae = p.email;
                    ViewBag.mae = p;
                }

            }
            if (aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeId = new SelectList(db.Cidades, "Id", "nome", aluno.CidadeId);
            return View(aluno);
        }

        // POST: Alunoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,matricula,dataNascimento,dataCadastro,endereco,sexo,idade,dataAlteracao,usuarioAlteracao,CidadeId,nome,cpf,rg,telefone,email,nomePai,nomeMae,rgPai,rgMae,cpfPai,cpfMae,profissaoPai,profissaoMae,telefonePai,telefoneMae,emailPai,emailMae")] Aluno aluno)
        {
            if (aluno.nomePai == null || aluno.cpfPai == null || aluno.rgPai == null || aluno.telefonePai == null || aluno.emailPai == null)
            {
                ModelState.AddModelError("", "Preencha todas as informações sobre o pai");
            }
            else if (aluno.nomeMae == null || aluno.cpfMae == null || aluno.rgMae == null || aluno.telefoneMae == null || aluno.emailMae == null)
            {
                ModelState.AddModelError("", "Preencha todas as informações sobre a mãe");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    aluno.Pais = new List<Pais>();

                    Pais pai = new Pais();
                    pai.nome = aluno.nomePai;
                    pai.rg = aluno.rgPai;
                    pai.cpf = aluno.cpfPai;
                    pai.email = aluno.emailPai;
                    pai.telefone = aluno.telefonePai;
                    pai.filiacao = "p";
                    pai.dataCadastro = DateTime.Now.Date;

                    aluno.Pais.Add(pai);

                    Pais mae = new Pais();
                    mae.nome = aluno.nomeMae;
                    mae.rg = aluno.rgMae;
                    mae.cpf = aluno.cpfMae;
                    mae.email = aluno.emailMae;
                    mae.telefone = aluno.telefoneMae;
                    mae.filiacao = "m";
                    mae.dataCadastro = DateTime.Now;

                    aluno.Pais.Add(mae);

                    db.Entry(aluno).State = EntityState.Modified;                   
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }               
            }
            ViewBag.CidadeId = new SelectList(db.Cidades, "Id", "nome", aluno.CidadeId);
            return View(aluno);
        }

        // GET: Alunoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);

            
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            db.Alunos.Remove(aluno);
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
