using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AF_Models;

namespace AF_DataAccessLayer
{
    public class AF_DataAccess : IAF_DataAccess
    {
       // AF_Context context = new AF_Context();
        
        #region Award
        public async Task AddAward(Award newAward)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    context.Awards.Add(newAward);
                    int recordsAffected = await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task RemoveAward(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Award awa = context.Awards.First(a => a.AwardId == id);
                    context.Awards.Remove(awa);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task UpdateAward(Award updateData)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Award awa = context.Awards.First(a => a.AwardId == updateData.AwardId);
                    awa = updateData;
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task<Award> GetAward(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    //Category cat = await Task.Run<Category>(() => context.Categories.First(c => c.CategoryId == id));
                    Award awa = context.Awards.First(a => a.CategoryId == id);
                    awa.Editor = context.Users.First(u => u.UserId == awa.EditedBy);
                    return (awa);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<Award>> GetAwardsPaged(int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                    List<Award> q = await (from a in context.Awards
                                           select a).Skip(skip).Take(pageAmount).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<Award>> GetAllAwards()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<Award> q = await (from a in context.Awards
                                              select a).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }
        #endregion
        #region Category
        public async Task AddCategory(Category newCategory)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    context.Categories.Add(newCategory);
                    int recordsAffected = await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task RemoveCategory(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Category cat = context.Categories.First(c => c.CategoryId == id);
                    context.Categories.Remove(cat);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task UpdateCategory(Category updateData)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Category cat = context.Categories.First(c => c.CategoryId==updateData.CategoryId);
                    cat = updateData;
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task<Category> GetCategory(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    //Category cat = await Task.Run<Category>(() => context.Categories.First(c => c.CategoryId == id));
                    Category cat = context.Categories.First(c => c.CategoryId == id);
                    cat.Editor = context.Users.First(u => u.UserId == cat.EditedBy);
                    return (cat);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<Category>> GetCategoriesPaged(int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                    List<Category> q = await (from c in context.Categories
                                                 orderby c.Order
                                                 select c).Skip(skip).Take(pageAmount).ToListAsync();  //efficient? join with users?
                    return(q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<Category>> GetAllCategories()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<Category> q = await (from c in context.Categories
                                             orderby c.Order
                                             select c).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }
        #endregion
        #region Festival
        public async Task AddFestival(Festival newFestival)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    context.Festivals.Add(newFestival);
                    int recordsAffected = await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task RemoveFestival(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Festival fes = context.Festivals.First(f => f.FestivalId == id);
                    context.Festivals.Remove(fes);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task UpdateFestival(Festival updateData)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Festival fes = context.Festivals.First(f => f.FestivalId == updateData.FestivalId);
                    fes = updateData;
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task<Festival> GetFestival(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    //Category cat = await Task.Run<Category>(() => context.Categories.First(c => c.CategoryId == id));
                    Festival fes = context.Festivals.First(f => f.FestivalId == id);
                    fes.Editor = context.Users.First(u => u.UserId == fes.EditedBy);
                    return (fes);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<Festival>> GetFestivalsPaged(int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                    List<Festival> q = await (from f in context.Festivals
                                           select f).Skip(skip).Take(pageAmount).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<Festival>> GetAllFestivals()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<Festival> q = await (from f in context.Festivals
                                           select f).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        #endregion
        #region Job
        public async Task AddJob(Job newJob)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    context.Jobs.Add(newJob);
                    int recordsAffected = await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task RemoveJob(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Job jo = context.Jobs.First(j => j.JobId == id);
                    context.Jobs.Remove(jo);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task UpdateJob(Job updateData)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Job jo = context.Jobs.First(j => j.JobId == updateData.JobId);
                    jo = updateData;
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task<Job> GetJob(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Job jo = context.Jobs.First(j => j.JobId == id);
                    jo.Editor = context.Users.First(u => u.UserId == jo.EditedBy);
                    return (jo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<Job>> GetJobsPaged(int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                    List<Job> q = await (from j in context.Jobs
                                           select j).Skip(skip).Take(pageAmount).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<Job>> GetAllJobs()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<Job> q = await (from j in context.Jobs
                                         select j).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        } 
        #endregion
        #region News
        public async Task AddNews(News newNews)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    context.News.Add(newNews);
                    int recordsAffected = await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task RemoveNews(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    News ne = context.News.First(n => n.NewsId == id);
                    context.News.Remove(ne);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task UpdateNews(News updateData)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    News ne = context.News.First(n => n.NewsId == updateData.NewsId);
                    ne = updateData;
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task<News> GetNews(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    //Category cat = await Task.Run<Category>(() => context.Categories.First(c => c.CategoryId == id));
                    News ne = context.News.First(n => n.NewsId == id);
                    ne.Editor = context.Users.First(u => u.UserId == ne.EditedBy);
                    return (ne);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<News>> GetNewsPaged(int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                    List<News> q = await (from n in context.News
                                           select n).Skip(skip).Take(pageAmount).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<News>> GetAllNews()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<News> q = await (from n in context.News
                                           select n).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }
        #endregion
        #region Person
        public async Task AddPerson(Person newPerson)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    context.People.Add(newPerson);
                    int recordsAffected = await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task RemovePerson(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Person per = context.People.First(p => p.PersonId == id);
                    context.People.Remove(per);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task UpdatePerson(Person updateData)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Person per = context.People.First(a => a.PersonId == updateData.PersonId);
                    per = updateData;
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task<Person> GetPerson(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    //Category cat = await Task.Run<Category>(() => context.Categories.First(c => c.CategoryId == id));
                    Person per = context.People.First(p => p.PersonId == id);
                    per.Editor = context.Users.First(u => u.UserId == per.EditedBy);
                    return (per);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<Person>> GetPeoplePaged(int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                    List<Person> q = await (from p in context.People
                                           select p).Skip(skip).Take(pageAmount).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<Person>> GetAllPeople()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<Person> q = await (from p in context.People
                                           select p).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }
        #endregion
        #region Play
        public async Task AddPlay(Play newPlay)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    context.Plays.Add(newPlay);
                    int recordsAffected = await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task RemovePlay(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Play pla = context.Plays.First(p => p.PlayId == id);
                    context.Plays.Remove(pla);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task UpdatePlay(Play updateData)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Play pla = context.Plays.First(p => p.PlayId == updateData.PlayId);
                    pla = updateData;
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task<Play> GetPlay(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Play pla = context.Plays.First(p => p.PlayId == id);
                    pla.Editor = context.Users.First(u => u.UserId == pla.EditedBy);
                    return (pla);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<Play>> GetPlaysPaged(int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                  /*  IQueryable<Play> query = (from p in context.Plays
                                                  orderby p.Order
                                                  select p).Skip(skip).Take(pageAmount);*/
                    List<Play> q = await (from p in context.Plays
                                                  orderby p.Order
                                                  select p).Skip(skip).Take(pageAmount).ToListAsync();
                    return (q);
                    //return (query.ToList<Play>());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<Play>> GetAllPlays()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<Play> q = await (from p in context.Plays
                                           select p).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }
        #endregion
        #region Position
        public async Task AddPosition(Position newPosition)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    context.Positions.Add(newPosition);
                    int recordsAffected = await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task RemovePosition(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Position pos = context.Positions.First(p => p.PositionId == id);
                    context.Positions.Remove(pos);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task UpdatePosition(Position updateData)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Position pos = context.Positions.First(p => p.PositionId == updateData.PositionId);
                    pos = updateData;
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task<Position> GetPosition(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Position pos = context.Positions.First(p => p.PositionId == id);
                    pos.Editor = context.Users.First(u => u.UserId == pos.EditedBy);
                    return (pos);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<Position>> GetPositionsPaged(int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                    List<Position> q = await (from p in context.Positions
                                           select p).Skip(skip).Take(pageAmount).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<Position>> GetAllPositions()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<Position> q = await (from p in context.Positions
                                           select p).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }
        #endregion
        #region RelationFestivalPersonPosition
        public async Task AddRelationFestivalPersonPosition(RelationFestivalPersonPosition newRelationFestivalPersonPosition)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    context.RelationsFestivalPersonPosition.Add(newRelationFestivalPersonPosition);
                    int recordsAffected = await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task RemoveRelationFestivalPersonPosition(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    RelationFestivalPersonPosition rel = context.RelationsFestivalPersonPosition.First(r => r.RelationFestivalPersonPositionId == id);
                    context.RelationsFestivalPersonPosition.Remove(rel);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task UpdateRelationFestivalPersonPosition(RelationFestivalPersonPosition updateData)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    RelationFestivalPersonPosition rel = context.RelationsFestivalPersonPosition.First(r => r.RelationFestivalPersonPositionId == updateData.RelationFestivalPersonPositionId);
                    rel = updateData;
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task<RelationFestivalPersonPosition> GetRelationFestivalPersonPosition(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    //Category cat = await Task.Run<Category>(() => context.Categories.First(c => c.CategoryId == id));
                    RelationFestivalPersonPosition rel = context.RelationsFestivalPersonPosition.First(r => r.RelationFestivalPersonPositionId == id);
                    rel.Editor = context.Users.First(u => u.UserId == rel.EditedBy);
                    rel.Festival = context.Festivals.First(f => f.FestivalId == rel.FestivalId);
                    rel.Person = context.People.First(p => p.PersonId == rel.PersonId);
                    rel.Position = context.Positions.First(p => p.PositionId == rel.PositionId);
                    return (rel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<RelationFestivalPersonPosition>> GetRelationFestivalPersonPositionPaged(int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                    List<RelationFestivalPersonPosition> q = await (from p in context.RelationsFestivalPersonPosition
                                           select p).Skip(skip).Take(pageAmount).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<RelationFestivalPersonPosition>> GetAllRelationFestivalPersonPosition()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<RelationFestivalPersonPosition> q = await (from p in context.RelationsFestivalPersonPosition
                                           select p).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }
        #endregion
        #region RelationPersonAward
        public async Task AddRelationPersonAward(RelationPersonAward newRelationPersonAward)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    context.RelationsPersonAward.Add(newRelationPersonAward);
                    int recordsAffected = await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task RemoveRelationPersonAward(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    RelationPersonAward rel = context.RelationsPersonAward.First(r => r.RelationPersonAwardId == id);
                    context.RelationsPersonAward.Remove(rel);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task UpdateRelationPersonAward(RelationPersonAward updateData)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    RelationPersonAward rel = context.RelationsPersonAward.First(r => r.RelationPersonAwardId == updateData.RelationPersonAwardId);
                    rel = updateData;
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task<RelationPersonAward> GetRelationPersonAward(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    //Category cat = await Task.Run<Category>(() => context.Categories.First(c => c.CategoryId == id));
                    RelationPersonAward rel = context.RelationsPersonAward.First(r => r.RelationPersonAwardId == id);
                    rel.Editor = context.Users.First(u => u.UserId == rel.EditedBy);
                    rel.Person = context.People.First(p => p.PersonId == rel.PersonId);
                    rel.Award = context.Awards.First(a => a.AwardId == rel.AwardId);
                    return (rel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<RelationPersonAward>> GetRelationPersonAwardPaged(int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                    List<RelationPersonAward> q = await (from r in context.RelationsPersonAward
                                           select r).Skip(skip).Take(pageAmount).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<RelationPersonAward>> GetAllRelationPersonAward()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<RelationPersonAward> q = await (from r in context.RelationsPersonAward
                                           select r).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        #endregion
        #region RelationPersonPlayJob
        public async Task AddRelationPersonPlayJob(RelationPersonPlayJob newRelationPersonPlayJob)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    context.RelationsPersonPlayJob.Add(newRelationPersonPlayJob);
                    int recordsAffected = await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task RemoveRelationPersonPlayJob(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    RelationPersonPlayJob rel = context.RelationsPersonPlayJob.First(r => r.RelationPersonPlayJobId == id);
                    context.RelationsPersonPlayJob.Remove(rel);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task UpdateRelationPersonPlayJob(RelationPersonPlayJob updateData)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    RelationPersonPlayJob rel = context.RelationsPersonPlayJob.First(r => r.RelationPersonPlayJobId == updateData.RelationPersonPlayJobId);
                    rel = updateData;
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task<RelationPersonPlayJob> GetRelationPersonPlayJob(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    //Category cat = await Task.Run<Category>(() => context.Categories.First(c => c.CategoryId == id));
                    RelationPersonPlayJob rel = context.RelationsPersonPlayJob.First(r => r.RelationPersonPlayJobId == id);
                    rel.Editor = context.Users.First(u => u.UserId == rel.EditedBy);
                    rel.Person = context.People.First(p => p.PersonId == rel.PersonId);
                    rel.Play = context.Plays.First(p => p.PlayId == rel.PlayId);
                    rel.Job = context.Jobs.First(j => j.JobId == rel.JobId);
                    return (rel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<RelationPersonPlayJob>> GetRelationPersonPlayJobPaged(int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                    List<RelationPersonPlayJob> q = await (from r in context.RelationsPersonPlayJob
                                           select r).Skip(skip).Take(pageAmount).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<RelationPersonPlayJob>> GetAllRelationPersonPlayJob()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<RelationPersonPlayJob> q = await (from r in context.RelationsPersonPlayJob
                                           select r).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }
        #endregion
        #region RelationPersonPlayRole
        public async Task AddRelationPersonPlayRole(RelationPersonPlayRole newRelationPersonPlayRole)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    context.RelationsPersonPlayRole.Add(newRelationPersonPlayRole);
                    int recordsAffected = await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task RemoveRelationPersonPlayRole(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    RelationPersonPlayRole rel = context.RelationsPersonPlayRole.First(r => r.RelationPersonPlayRoleId == id);
                    context.RelationsPersonPlayRole.Remove(rel);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task UpdateRelationPersonPlayRole(RelationPersonPlayRole updateData)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    RelationPersonPlayRole rel = context.RelationsPersonPlayRole.First(r => r.RelationPersonPlayRoleId == updateData.RelationPersonPlayRoleId);
                    rel = updateData;
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task<RelationPersonPlayRole> GetRelationPersonPlayRole(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    //Category cat = await Task.Run<Category>(() => context.Categories.First(c => c.CategoryId == id));
                    RelationPersonPlayRole rel = context.RelationsPersonPlayRole.First(r => r.RelationPersonPlayRoleId == id);
                    rel.Editor = context.Users.First(u => u.UserId == rel.EditedBy);
                    rel.Person = context.People.First(p => p.PersonId == rel.PersonId);
                    rel.Play = context.Plays.First(p => p.PlayId == rel.PlayId);
                    return (rel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<RelationPersonPlayRole>> GetRelationPersonPlayRolePaged(int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                    List<RelationPersonPlayRole> q = await (from r in context.RelationsPersonPlayRole
                                           select r).Skip(skip).Take(pageAmount).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<RelationPersonPlayRole>> GetAllRelationPersonPlayRole()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<RelationPersonPlayRole> q = await (from r in context.RelationsPersonPlayRole
                                           select r).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        #endregion
        #region User
        public async Task AddUser(User newUser)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    context.Users.Add(newUser);
                    int recordsAffected = await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task RemoveUser(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    User us = context.Users.First(u => u.UserId == id);
                    context.Users.Remove(us);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task UpdateUser(User updateData)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    User us = context.Users.First(u => u.UserId == updateData.UserId);
                    us = updateData;
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public async Task<User> GetUser(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    User us = context.Users.First(u => u.UserId == id);
                    return (us);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<User>> GetUserPaged(int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                    List<User> q = await (from u in context.Users
                                           select u).Skip(skip).Take(pageAmount).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<User> q = await (from u in context.Users
                                           select u).ToListAsync();
                    return (q);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }
        #endregion
    }
}