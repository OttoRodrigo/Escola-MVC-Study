using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EC.Escola.Acesso_Dados.Context;
using EC.Escola.Dominio;

namespace EC.Escola.Web.Controllers
{
    public class registroNotasController : Controller
    {
        private EscolaDbContext db = new EscolaDbContext();

        // GET: registroNotas
        public ActionResult Index()
        {
            var registroNotas = db.registroNotas.Include(r => r.aluno).Include(r => r.disciplina);
            ViewBag.idAluno = new SelectList(db.estudantes, "id", "nome");
            ViewBag.idDisciplina = new SelectList(db.disciplinas, "id", "nome");
            
            return View(registroNotas.ToList());
        }

        // GET: registroNotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var registroNotas = db.registroNotas.Include(r => r.aluno).Include(r => r.disciplina);
            //registroNotas.FirstOrDefault(p => p.id == id);
            registroNotas registroNotas = db.registroNotas.Find(id);
            registroNotas.aluno = db.estudantes.Find(registroNotas.idAluno);
            registroNotas.disciplina = db.disciplinas.Find(registroNotas.idDisciplina);
            if (registroNotas == null)
            {
                return HttpNotFound();
            }
            return View((registroNotas)registroNotas);
        }

        // GET: registroNotas/Create
        public ActionResult Create()
        {
            ViewBag.idAluno = new SelectList(db.estudantes, "id", "nome");
            ViewBag.idDisciplina = new SelectList(db.disciplinas, "id", "nome");
            return View();
        }

        // POST: registroNotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idAluno,idDisciplina,nota1,nota2,nota3,nota4,media")] registroNotas registroNotas)
        {
            if (ModelState.IsValid)
            {
                db.registroNotas.Add(registroNotas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAluno = new SelectList(db.estudantes, "id", "nome", registroNotas.idAluno);
            ViewBag.idDisciplina = new SelectList(db.disciplinas, "id", "nome", registroNotas.idDisciplina);
            return View(registroNotas);
        }

        // GET: registroNotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registroNotas registroNotas = db.registroNotas.Find(id);
            if (registroNotas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAluno = new SelectList(db.estudantes, "id", "nome", registroNotas.idAluno);
            ViewBag.idDisciplina = new SelectList(db.disciplinas, "id", "nome", registroNotas.idDisciplina);
            return View(registroNotas);
        }

        // POST: registroNotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idAluno,idDisciplina,nota1,nota2,nota3,nota4,media")] registroNotas registroNotas)
        {
            if (ModelState.IsValid)
            {
                registroNotas.media = (registroNotas.nota1 + registroNotas.nota2 + registroNotas.nota3 + registroNotas.nota4) / 4;
                db.Entry(registroNotas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAluno = new SelectList(db.estudantes, "id", "nome", registroNotas.idAluno);
            ViewBag.idDisciplina = new SelectList(db.disciplinas, "id", "nome", registroNotas.idDisciplina);
            return View(registroNotas);
        }

        // GET: registroNotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registroNotas registroNotas = db.registroNotas.Find(id);
            registroNotas.aluno = db.estudantes.Find(registroNotas.idAluno);
            registroNotas.disciplina = db.disciplinas.Find(registroNotas.idDisciplina);
            if (registroNotas == null)
            {
                return HttpNotFound();
            }
            return View(registroNotas);
        }

        // POST: registroNotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registroNotas registroNotas = db.registroNotas.Find(id);
            db.registroNotas.Remove(registroNotas);
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
