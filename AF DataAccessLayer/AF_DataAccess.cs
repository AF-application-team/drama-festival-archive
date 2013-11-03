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
        public void AddAward(Award newAward)
        {
            throw new NotImplementedException();
        }

        public void RemoveAward(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAward(Award updateData)
        {
            throw new NotImplementedException();
        }

        public Award GetAward(int id)
        {
            throw new NotImplementedException();
        }

        public List<Award> GetAwardsPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Category
        public void AddCategory(Category newCategory)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    context.Categories.Add(newCategory);
                    int recordsAffected = context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public void RemoveCategory(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Category cat = context.Categories.First(c => c.CategoryId == id);
                    context.Categories.Remove(cat);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }

        }

        public void UpdateCategory(Category updateData)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Category cat = context.Categories.First(c => c.CategoryId==updateData.CategoryId);
                    cat = updateData;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public Category GetCategory(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Category cat = context.Categories.First(c => c.CategoryId == id);
                    cat.Edited = context.Users.First(u => u.UserId == cat.EditedBy);

                    /*IQueryable<Category> query = from c in context.Categories
                                                 where c.CategoryId == id
                                                 select c;
                    Category cat = query.FirstOrDefault();
                    IQueryable<User> query_rel = from u in context.Users
                                                 where u.UserId == cat.EditedBy
                                                 select u;
                    cat.Edited = query_rel.FirstOrDefault();*/
                    return (cat);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                return null;
            }
        }

        public List<Category> GetCategoriesPaged(int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                    IQueryable<Category> query = (from c in context.Categories
                                                 orderby c.Order
                                                 select c).Skip(skip).Take(pageAmount);  //efficient? join with users?
                    return(query.ToList<Category>());
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
        public void AddFestival(Festival newFestival)
        {
            throw new NotImplementedException();
        }

        public void RemoveFestival(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateFestival(Festival updateData)
        {
            throw new NotImplementedException();
        }

        public Festival GetFestival(int id)
        {
            throw new NotImplementedException();
        }

        public List<Festival> GetFestivalsPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Job
        public void AddJob(Job newJob)
        {
            throw new NotImplementedException();
        }

        public void RemoveJob(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateJob(Job updateData)
        {
            throw new NotImplementedException();
        }

        public Job GetJob(int id)
        {
            throw new NotImplementedException();
        }

        public List<Job> GetJobsPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region News
        public void AddNews(News newNews)
        {
            throw new NotImplementedException();
        }

        public void RemoveNews(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateNews(News updateData)
        {
            throw new NotImplementedException();
        }

        public News GetNews(int id)
        {
            throw new NotImplementedException();
        }

        public List<News> GetNewsPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Person
        public void AddPerson(Person newPerson)
        {
            throw new NotImplementedException();
        }

        public void RemovePerson(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(Person updateData)
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPeoplePaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Play
        public void AddPlay(Play newPlay)
        {
            throw new NotImplementedException();
        }

        public void RemovePlay(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlay(Play updateData)
        {
            throw new NotImplementedException();
        }

        public Play GetPlay(int id)
        {
            throw new NotImplementedException();
        }

        public List<Play> GetPlaysPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Position
        public void AddPosition(Position newPosition)
        {
            throw new NotImplementedException();
        }

        public void RemovePosition(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePosition(Position updateData)
        {
            throw new NotImplementedException();
        }

        public Position GetPosition(int id)
        {
            throw new NotImplementedException();
        }

        public List<Position> GetPositionsPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region RelationFestivalPersonPosition
        public void AddRelationFestivalPersonPosition(RelationFestivalPersonPosition newRelationFestivalPersonPosition)
        {
            throw new NotImplementedException();
        }

        public void RemoveRelationFestivalPersonPosition(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRelationFestivalPersonPosition(RelationFestivalPersonPosition updateData)
        {
            throw new NotImplementedException();
        }

        public RelationFestivalPersonPosition GetRelationFestivalPersonPosition(int id)
        {
            throw new NotImplementedException();
        }

        public List<RelationFestivalPersonPosition> GetRelationFestivalPersonPositionPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region RelationPersonAward
        public void AddRelationPersonAward(RelationPersonAward newRelationPersonAward)
        {
            throw new NotImplementedException();
        }

        public void RemoveRelationPersonAward(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRelationPersonAward(RelationPersonAward updateData)
        {
            throw new NotImplementedException();
        }

        public RelationPersonAward GetRelationPersonAward(int id)
        {
            throw new NotImplementedException();
        }

        public List<RelationPersonAward> GetRelationPersonAwardPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region RelationPersonPlayJob
        public void AddRelationPersonPlayJob(RelationPersonPlayJob newRelationPersonPlayJob)
        {
            throw new NotImplementedException();
        }

        public void RemoveRelationPersonPlayJob(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRelationPersonPlayJob(RelationPersonPlayJob updateData)
        {
            throw new NotImplementedException();
        }

        public RelationPersonPlayJob GetRelationPersonPlayJob(int id)
        {
            throw new NotImplementedException();
        }

        public List<RelationPersonPlayJob> GetRelationPersonPlayJobPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region RelationPersonPlayRole
        public void AddRelationPersonPlayRole(RelationPersonPlayRole newRelationPersonPlayRole)
        {
            throw new NotImplementedException();
        }

        public void RemoveRelationPersonPlayRole(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRelationPersonPlayRole(RelationPersonPlayRole updateData)
        {
            throw new NotImplementedException();
        }

        public RelationPersonPlayRole GetRelationPersonPlayRole(int id)
        {
            throw new NotImplementedException();
        }

        public List<RelationPersonPlayRole> GetRelationPersonPlayRolePaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region User
        public void AddUser(User newUser)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User updateData)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUserPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}