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
            //var festivals = db.Festivals.Include(f => f.Editor);
            //return View(festivals.ToList());
            using (var context = new AF_Context())
            {
                var skip = 0;//pageAmount * (pageNr - 1);
                int pageAmount = 100;
                List<FestivalDTO> tmp = new List<FestivalDTO>();
                foreach (Festival fe in (from f in context.Festivals//.Include(u => u.Editor)
                                         select f).OrderBy(f => f.Year).Skip(skip).Take(pageAmount))
                {
                    var newFestivalDto = new FestivalDTO()
                    {
                        FestivalId = fe.FestivalId,
                        Year = fe.Year,
                        BeginningDate = fe.BeginningDate,
                        EndDate = fe.EndDate
                    };
                    tmp.Add(newFestivalDto);
                }
                return View(tmp);
            }
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

        // GET: /Festival/Create
        public ActionResult Create()
        {
            //ViewBag.EditedBy = new SelectList(db.Users, "UserId", "Login");
            //ViewBag.FestivalId = new SelectList(db.Festivals, "FestivalId", "FestivalId");
            return View();
        }

        // POST: /Festival/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FestivalId,Year,BeginningDate,EndDate")] FestivalDTO updateData)
        {
            if (ModelState.IsValid)
            {
                var updateDataFull = new Festival()
                {
                    //FestivalId = updateData.FestivalId,
                    Year = updateData.Year,
                    BeginningDate = updateData.BeginningDate,
                    EndDate = updateData.EndDate,
                    EditedBy = 1,//GetUserId(),
                    EditDate = DateTime.Now
                };
                using (var context = new AF_Context())
                {
                    context.Festivals.Add(updateDataFull);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            //ViewBag.EditedBy = new SelectList(db.Users, "UserId", "Login", play.EditedBy);
            //ViewBag.FestivalId = new SelectList(db.Festivals, "FestivalId", "FestivalId", play.FestivalId);
            return View(updateData);
        }

        // GET: /Festival/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var context = new AF_Context())
            {
                Festival fes = context.Festivals.Find(id);
                if (fes == null)
                {
                    return HttpNotFound();
                }
                var newFestivalDto = new FestivalDTO()
                {
                    FestivalId = fes.FestivalId,
                    Year = fes.Year,
                    BeginningDate = fes.BeginningDate,
                    EndDate = fes.EndDate,
                };
                //ViewBag.EditedBy = new SelectList(db.Users, "UserId", "Login", play.EditedBy);
                //ViewBag.FestivalId = new SelectList(db.Festivals, "FestivalId", "FestivalId", play.FestivalId);
                return View(newFestivalDto);
            }
        }

        // POST: /Play/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FestivalId,Year,BeginningDate,EndDate")] FestivalDTO updateData)
        {
            if (ModelState.IsValid)
            {
                var updateDataFull = new Festival()
                {
                    FestivalId = updateData.FestivalId,
                    Year = updateData.Year,
                    BeginningDate = updateData.BeginningDate,
                    EndDate = updateData.EndDate,
                    EditedBy = 1,//GetUserId(),
                    EditDate = DateTime.Now
                };
                using (var context = new AF_Context())
                {
                    Festival fes = context.Festivals.Find(updateData.FestivalId);
                    context.Entry(fes).CurrentValues.SetValues(updateDataFull);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            //ViewBag.EditedBy = new SelectList(db.Users, "UserId", "Login", play.EditedBy);
            //ViewBag.FestivalId = new SelectList(db.Festivals, "FestivalId", "FestivalId", play.FestivalId);
            return View(updateData);
        }

        // GET: /Play/Delete/5
       /* public ActionResult Delete(int? id)
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
        }*/

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
