using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ActorSakilaReboot.Models;
using Microsoft.EntityFrameworkCore;
using ActorSakilaReboot.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ActorSakilaReboot.Controllers
{
    public class ActorController : Controller
    {
        private readonly sakilaContext _context;

        public ActorController(sakilaContext context)
        {
            _context = context;
        }


        //GET: /Actor/
        public async Task<IActionResult> Index()
        {
            return View(await _context.Actor.ToListAsync());
        }


        //GET: /Actor/Add/5
        public ActionResult Add()
        {
            return View();
        }

        //POST: /Actor/Add/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Actor actor)
        {
            //dohvaćanje idućeg slobodnog ID-a, može li bolje/izravnije?
            actor.ActorId = (ushort)((_context.Actor.Select(x => x.ActorId).Max()) + 1);
            _context.Add(actor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: /Actor/Details/5
        public async Task<IActionResult> Details(ushort id = 0)
        {
            var actorFilms = new ActorIndexData();

            //ovo bi trebalo učitat sve actore i njihove veze s filmactor i film tablicama
            actorFilms.Actors = await _context.Actor
                  .Include(i => i.FilmActor)
                    .ThenInclude(i => i.Film)
                  .AsNoTracking()
                  .ToListAsync();


            //ovdje je naštimano da app radi, ali način ziher nije optimalan i ispravan 

            //učitaj actora za prikaz
            actorFilms.Actors = actorFilms.Actors.Where(i => i.ActorId == id).ToList();

            //učitaj actora za daljnju pretragu po filmactorima
            Actor actor = actorFilms.Actors.Where(i => i.ActorId == id).Single();

            //učitaj filmactora za daljnju pretragu po filmovima
            actorFilms.FilmActors = actor.FilmActor.Where(i => i.ActorId == id).ToList();

            //učitaj sve filmove za određenog filmaktora
            actorFilms.Films = actorFilms.FilmActors.Select(x => x.Film);

            //učitaj distinktne naslove filmova
            actorFilms.Title = actorFilms.Films.Select(x => x.Title).Distinct().ToList();

            return View(actorFilms);
        }


        // GET: /Actor/Edit/5
        public ActionResult Edit(ushort id = 0)
        {
            Actor actor = _context.Actor.Find(id);
            return View(actor);
        }


        // POST: /Actor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ushort id, Actor actor)
        {
            _context.Entry(actor).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: /Actor/Delete/5
        public ActionResult Delete(ushort id = 0)
        {
            Actor actor = _context.Actor.Find(id);
            return View(actor);
        }

        // POST: /Actor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ushort id, [Bind("ActorId,FirstName,LastName")] Actor actor)
        {
            //Actor actorToDelete = _context.Actor.FirstOrDefault(_ => _.ActorId == id);
            _context.Entry(actor).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
