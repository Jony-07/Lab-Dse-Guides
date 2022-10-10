using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcPelicula.Models;

namespace MvcPelicula.Controllers
{
    public class PeliculasController : Controller
    {
        private PeliculaDBContext db = new PeliculaDBContext();

        // GET: Peliculas
        public ActionResult Index(string buscarString, string generoPelicula, string BuscarxPrecio, string PrecioEspcifico)
        {
            //return View(db.Peliculas.ToList());
            var GeneroLst = new List<string>();
            var GeneroQry = from d in db.Peliculas
                            orderby d.Genero
                            select d.Genero;

            GeneroLst.AddRange(GeneroQry.Distinct());
            ViewBag.generoPelicula = new SelectList(GeneroLst);
            var peliculas = from p in db.Peliculas select p;

            var PrecioLst = new List<string>();
            PrecioLst.Add("Mayor");
            PrecioLst.Add("Menor");
            ViewBag.BuscarxPrecio=new SelectList(PrecioLst);


            if (!String.IsNullOrEmpty(buscarString))
            {
                peliculas = peliculas.Where(s => s.Titulo.Contains(buscarString));
            }

            if(!String.IsNullOrEmpty(PrecioEspcifico))
                {
                decimal PrecioEspcificoX = Decimal.Parse(PrecioEspcifico);
                peliculas = peliculas.Where(s=>s.Precio.Equals(PrecioEspcificoX));
            }

            if(!string.IsNullOrEmpty(BuscarxPrecio))
            {
                if(BuscarxPrecio == "Mayor")
                {
                    peliculas = peliculas.OrderByDescending(p => p.Precio);

                }
                else if(BuscarxPrecio == "Menor")
                {
                    peliculas = peliculas.OrderBy(p => p.Precio);
                }
            }

            if (!string.IsNullOrEmpty(generoPelicula))
            {
                peliculas = peliculas.Where(x => x.Genero == generoPelicula);
            }

            return View(peliculas);
        }



        // GET: Peliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,FechaLanzamiento,Genero,Precio, Calificacion, Productor")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Peliculas.Add(pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pelicula);
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,FechaLanzamiento,Genero,Precio, Calificacion, Productor")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pelicula);
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            db.Peliculas.Remove(pelicula);
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
