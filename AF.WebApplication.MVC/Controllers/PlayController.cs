using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AF_Models;
using AF_DataAccessLayer;
using AF.Common.DTO;

namespace AF.WebApplication.MVC.Controllers
{
    public class PlayController : Controller
    {
        private AF_Context db = new AF_Context();

        // GET: /Play/
        public ActionResult Index()
        {
            using (var context = new AF_Context())
            {
                //var plays = context.Plays;//.Include(p => p.Editor).Include(p => p.Festival);
                //return View(plays.ToList());
                var skip = 0;//pageAmount * (pageNr - 1);
                int pageAmount = 100;
                var query = (from p in context.Plays select p);
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

        // GET: /Play/Details/5
        public ActionResult Details(int? id) 
        {
            using (var context = new AF_Context())
            {
                var play = (from p in context.Plays select p).FirstOrDefault(p => p.PlayId == id);
                if (play == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var data = new PlayCastDTO(play);

                data.Helpers = (from pjob in context.RelationsPersonPlayJob select pjob)
                    .Where(pjob => pjob.PlayId == data.PlayId)
                    .Include(pjob => pjob.Person)
                    .Include(pjob => pjob.Job)
                    .OrderBy(pjob => pjob.JobId)
                    .ToList()
                    .Select(PersonFunctionDTO.FromJobEntity);

                data.Cast = (from prole in context.RelationsPersonPlayRole select prole)
                    .Where(prole => prole.PlayId == data.PlayId)
                    .Include(prole => prole.Person)
                    .OrderBy(prole => prole.RelationPersonPlayRoleId)
                    .ToList()
                    .Select(PersonFunctionDTO.FromRoleEntity);

                return View(data);
            }
        }
        
        // GET: /Play/Create
        public ActionResult Create()
        {
            var tmp = new PlayDataDTO(){FestivalId=18};
            //ViewBag.FestivalId = 18;
            //ViewBag.EditedBy = new SelectList(db.Users, "UserId", "Login");
            return View(tmp);
        }

        // POST: /Play/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayId,Title,Author,FestivalId,Day,Order,PlayedBy,Motto")] PlayDataDTO updateData)
        {
            using (var context = new AF_Context())
            {
                var updateDataFull = new Play()
                {
                    //PlayId = updateData.PlayId,
                    Title = updateData.Title,
                    Author = updateData.Author,
                    FestivalId = updateData.FestivalId,
                    Day = updateData.Day,
                    Order = updateData.Order,
                    PlayedBy = updateData.PlayedBy,
                    Motto = updateData.Motto,
                    EditedBy = 1,
                    //EditedBy = GetUserId(),    //???????
                    EditDate = DateTime.Now
                };
            if (ModelState.IsValid)
            {
                    context.Plays.Add(updateDataFull);
                    string return_s = "Details/" + updateDataFull.FestivalId;
                    context.SaveChanges();
                    return RedirectToAction(return_s, "Festival"); //TODO: Correct for many and for old id
            }

                //ViewBag.EditedBy = new SelectList(db.Users, "UserId", "Login", updateData.EditedBy);
            return View(updateData);
            }
        }
        
        // GET: /Play/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var context = new AF_Context())
            {
                Play pla = context.Plays.Find(id);// First(p => p.PlayId == id);
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
                if (newPlayDto == null)
                {
                    return HttpNotFound();
                }
                //ViewBag.EditedBy = new SelectList(db.Users, "UserId", "Login", festival.EditedBy);
                return View(newPlayDto);
            }   
        }

        // POST: /Play/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayId,Title,Author,FestivalId,Day,Order,PlayedBy,Motto")] PlayDataDTO updateData)
        {
            var updateDataFull = new Play()
            {
                PlayId = updateData.PlayId,
                Title = updateData.Title,
                Author = updateData.Author,
                FestivalId = updateData.FestivalId,
                Day = updateData.Day,
                Order = updateData.Order,
                PlayedBy = updateData.PlayedBy,
                Motto = updateData.Motto,
                EditedBy = 1,
                //EditedBy = GetUserId(),    //???????
                EditDate = DateTime.Now
            };

            using (var context = new AF_Context())
            {
                if (ModelState.IsValid)
                {
                    Play pla = context.Plays.Find(updateData.PlayId);// First(p => p.PlayId == updateData.PlayId);
                    string return_s = "Details/" + pla.FestivalId;
                    context.Entry(pla).CurrentValues.SetValues(updateDataFull); //check for substituding only edited
                    //context.Entry(updateDataFull).State = EntityState.Modified;
                    context.SaveChanges();
                    //int id = updateData.PlayId;
                    //return Redirect(Request.UrlReferrer.ToString()); //RedirectToAction("Index")
                    //return RedirectToAction(return_s);
                    return RedirectToAction(return_s, "Festival");
                }
                return View(updateData);
            }
            //ViewBag.EditedBy = new SelectList(db.Users, "UserId", "Login", festival.EditedBy);
            //return View(updateData);
        }
        /*
        // GET: /Play/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Festival festival = db.Festivals.Find(id);
            if (festival == null)
            {
                return HttpNotFound();
            }
            return View(festival);
        }

        // POST: /Play/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Festival festival = db.Festivals.Find(id);
            db.Festivals.Remove(festival);
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
        }*/
    }
}
