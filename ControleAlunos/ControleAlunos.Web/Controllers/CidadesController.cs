using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ControleAlunos.Web.Data;
using ControleAlunos.Web.Models;

namespace ControleAlunos.Web.Controllers
{
    public class CidadesController : Controller
    {
        private ControleAlunosContext db = new ControleAlunosContext();

        // GET: Cidades
        public ActionResult Index()
        {
            return View(db.Cidades.ToList());
        }

        // GET: Cidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.Cidades.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // GET: Cidades/Create
        public ActionResult Create()
        {          

            ViewBag.listaCidades = Cidades();
            return View();
        }

        public List<SelectListItem> Cidades()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            listItems.Add(new SelectListItem
            {
                Text = "Acre (AC)",
                Value = "Acre"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Alagoas (AL)",
                Value = "Alagoas",
            });
            listItems.Add(new SelectListItem
            {
                Text = "Amapá (AP)",
                Value = "Amapá"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Amazonas (AM)",
                Value = "Amazonas"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Bahia (BA)",
                Value = "Bahia"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Ceará (CE)",
                Value = "Ceará"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Distrito Federal (DF)",
                Value = "Distrito Federal"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Goiás (GO)",
                Value = "Goiás"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Maranhão (MA)",
                Value = "Maranhão"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Mato Grosso (MT)",
                Value = "Mato Grosso"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Mato Grosso do Sul (MS)",
                Value = "Mato Grosso do Sul"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Minas Gerais (MG)",
                Value = "Minas Gerais"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Pará (PA)",
                Value = "Pará"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Paraíba (PB)",
                Value = "Paraíba"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Paraná (PR)",
                Value = "Paraná"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Pernambuco (PE)",
                Value = "Pernambuco"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Piauí (PI)",
                Value = "Piauí"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Rio de Janeiro (RJ)",
                Value = "Rio de Janeiro"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Rio Grande do Norte (RN)",
                Value = "Rio Grande do Norte"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Rio Grande do Sul (RS)",
                Value = "Rio Grande do Sul"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Rondônia (RO)",
                Value = "Rondônia"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Roraima (RR)",
                Value = "Roraima"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Santa Catarina (SC)",
                Value = "Santa Catarina"
            });
            listItems.Add(new SelectListItem
            {
                Text = "São Paulo (SP)",
                Value = "São Paulo"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Sergipe (SE)",
                Value = "Sergipe"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Tocantins (TO)",
                Value = "Tocantins"
            });

            return listItems;
        }


        // POST: Cidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,estado,cep,dataCadastro")] Cidade cidade)
        {
            cidade.dataCadastro = DateTime.Now.Date;

            if (ModelState.IsValid)
            {
                db.Cidades.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.Cidades.Find(id);
            ViewBag.listaCidades = Cidades();
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,estado,cep,dataAlteracao,usuarioAlteracao")] Cidade cidade)
        {
            cidade.dataAlteracao = DateTime.Now.Date;
            cidade.usuarioAlteracao = "Não informado";
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.Cidades.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cidade cidade = db.Cidades.Find(id);
            db.Cidades.Remove(cidade);
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
