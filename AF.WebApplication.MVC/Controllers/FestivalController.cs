using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AF_Models;
using AF.Common.DTO;
using AF_DataAccessLayer;

namespace AF.WebApplication.MVC.Controllers
{
    public class FestivalController : Controller
    {
        private AF_Context db = new AF_Context();

        // GET: /Festival/
        public ActionResult Index()
        {
            var festivals = db.Festivals.Include(f => f.Editor);
            return View(festivals.ToList());
        }

        // GET: /Festival/Details/5
        public ActionResult Details(int? id)
        {
            using (var context = new AF_Context())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var skip = 0;//pageAmount * (pageNr - 1);
                int pageAmount = 100;
                var query = (from p in context.Plays select p).Where(p => p.FestivalId == id);
                if (query == null)
                {
                    return HttpNotFound();
                }
                List<PlayDataDTO> tmp = new List<PlayDataDTO>();
                foreach (Play pla in (query.OrderBy(p => p.FestivalId)
                    .ThenBy(p => p.Day)
                    .ThenBy(p => p.Order)
                    .Skip(skip)
                    .Take(pageAmount)))
                {
                    var newPlayDto = new PlayDataDTO()
                    {
                        PlayId = pla.PlayId,
                        Title = pla.Title,
                        Author = pla.Author,
                        FestivalId = pla.FestivalId,
                        Day = pla.Day,
                        Order = pla.Order,
                        PlayedBy = pla.PlayedBy,
                        Motto = pla.Motto
                    };
                    tmp.Add(newPlayDto);
                }
                return View(tmp);
            }
        }

        // GET: /Play/Create
        public ActionResult Create()
        {
            ViewBag.EditedBy = new SelectList(db.Users, "UserId", "Login");
            ViewBag.FestivalId = new SelectList(db.Festivals, "FestivalId", "FestivalId");
            return View();
        }

        // POST: /Play/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayId,Title,Author,FestivalId,Day,Order,PlayedBy,Motto,EditDate,EditedBy")] Play play)
        {
            if (ModelState.IsValid)
            {
                db.Plays.Add(play);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EditedBy = new SelectList(db.Users, "UserId", "Login", play.EditedBy);
            ViewBag.FestivalId = new SelectList(db.Festivals, "FestivalId", "FestivalId", play.FestivalId);
            return View(play);
        }

        // GET: /Festival/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Play play = db.Plays.Find(id);
            if (play == null)
            {
                return HttpNotFound();
            }
            ViewBag.EditedBy = new SelectList(db.Users, "UserId", "Login", play.EditedBy);
            ViewBag.FestivalId = new SelectList(db.Festivals, "FestivalId", "FestivalId", play.FestivalId);
            return View(play);
        }

        // POST: /Play/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayId,Title,Author,FestivalId,Day,Order,PlayedBy,Motto,EditDate,EditedBy")] Play play)
        {
            if (ModelState.IsValid)
            {
                db.Entry(play).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EditedBy = new SelectList(db.Users, "UserId", "Login", play.EditedBy);
            ViewBag.FestivalId = new SelectList(db.Festivals, "FestivalId", "FestivalId", play.FestivalId);
            return View(play);
        }

        // GET: /Play/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Play play = db.Plays.Find(id);
            if (play == null)
            {
                return HttpNotFound();
            }
            return View(play);
        }

        // POST: /Play/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Play play = db.Plays.Find(id);
            db.Plays.Remove(play);
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
