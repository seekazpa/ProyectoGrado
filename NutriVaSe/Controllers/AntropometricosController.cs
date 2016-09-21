using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NutriVaSe.Models;

namespace NutriVaSe.Controllers
{
    public class AntropometricosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Antropometricos/
        public ActionResult Index()
        {
            var antropometricoes = db.Antropometricoes.Include(a => a.Paciente);
            return View(antropometricoes.ToList());
        }

        // GET: /Antropometricos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Antropometrico antropometrico = db.Antropometricoes.Find(id);
            if (antropometrico == null)
            {
                return HttpNotFound();
            }
            return View(antropometrico);
        }

        // GET: /Antropometricos/Create
        public ActionResult Create()
        {
            Antropometrico antropometrico = new Antropometrico();
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime Fecha = DateTime.ParseExact(fecha, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            antropometrico.Fecha = Fecha;
            ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "Nombre");
            return View(antropometrico);
        }

        // POST: /Antropometricos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,PacienteId,PesoActual,Talla,CircuCintura,CircuCadera,PeriCuello,CircuCarpo,PeriBicep,PliegueTri,PliegueBi,PliegueSupra,PliegueSube,Fecha")] Antropometrico antropometrico)
        {
            if (ModelState.IsValid)
            {
                db.Antropometricoes.Add(antropometrico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "Nombre", antropometrico.PacienteId);
            return View(antropometrico);
        }

        // GET: /Antropometricos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Antropometrico antropometrico = db.Antropometricoes.Find(id);
            if (antropometrico == null)
            {
                return HttpNotFound();
            }
            ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "Nombre", antropometrico.PacienteId);
            return View(antropometrico);
        }

        // POST: /Antropometricos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,PacienteId,PesoActual,Talla,CircuCintura,CircuCadera,PeriCuello,CircuCarpo,PeriBicep,PliegueTri,PliegueBi,PliegueSupra,PliegueSube,Fecha")] Antropometrico antropometrico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(antropometrico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "Nombre", antropometrico.PacienteId);
            return View(antropometrico);
        }

        // GET: /Antropometricos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Antropometrico antropometrico = db.Antropometricoes.Find(id);
            if (antropometrico == null)
            {
                return HttpNotFound();
            }
            return View(antropometrico);
        }

        // POST: /Antropometricos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Antropometrico antropometrico = db.Antropometricoes.Find(id);
            db.Antropometricoes.Remove(antropometrico);
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
