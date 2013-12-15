using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AF.Common.DTO;
using AF.Common.Queries;
using AF.Common.Requests;
using AF.Common.Services;
using AF_DataAccessLayer;
using AF_Models;


namespace AF_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AFService : IAFService
    {
        /* Award AddAward(int playId, int festivalId, int categoryId, int userId);

         List<AwardMixedDTO> SearchAwards(AwardsSearchingCriteria criteria, int pageNr, int pageAmount)

         public ListResponse<ModuleDto> GetModules(SingleRequest request)
         {
             //Warning: unbound list read from db, do not do this at home!
             return ListResponse.Create(request,
                 InTransaction(tc => tc.Entities.ModuleInstances.Include(mi => mi.ModuleDef).ToList()
                                                         .Select(_moduleAssembler.ToSimpleDto).ToList()));
         }
         */

        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
        public SingleItemResponse<AwardDataDTO> AddAward(AwardDataDTO newAward) //void?
        {
            var newAwardFull = new Award()
            {
                CategoryId = newAward.CategoryId,
                FestivalId = newAward.FestivalId,
                PlayId = newAward.PlayId,
                EditedBy = userId,
                EditDate = DateTime.Now
            };

            using (var context = new AF_Context())
            {
                try
                {
                    context.Awards.Add(newAwardFull);
                    context.SaveChangesAsync();
                    //GetAward((int))
                    //return
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public SingleItemResponse<AwardDataDTO> UpdateAward(AwardDataDTO updateData)
        {
            using (var context = new AF_Context())
            {
                var updateDataFull = new Award()
                {
                    CategoryId = updateData.CategoryId,
                    FestivalId = updateData.FestivalId,
                    PlayId = updateData.PlayId,
                    EditedBy = userId,
                    EditDate = DateTime.Now
                };

                try
                {
                    Award awa = context.Awards.First(a => a.AwardId == updateData.AwardId);
                    context.Entry(awa).CurrentValues.SetValues(updateDataFull);
                    context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public SingleItemResponse<AwardDataDTO> GetAward(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<AwardMixedDTO> SearchAwards(AwardsSearchingCriteria criteria, int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                    var query = (from a in context.Awards select a).Include(a => a.Play).Include(a => a.Category);
                    if (criteria.FestivalIdFilter != null)
                        query = query.Where(a => a.FestivalId == criteria.FestivalIdFilter);
                    if (!String.IsNullOrEmpty(criteria.Author))
                        query = query.Where(a => a.Play.Author.Contains(criteria.Author));
                    if (!String.IsNullOrEmpty(criteria.Title))
                        query = query.Where(a => a.Play.Title.Contains(criteria.Title));
                    if (criteria.CategoryIdFilter != null)
                        query = query.Where(a => a.CategoryId == criteria.CategoryIdFilter);
                    return (query.OrderBy(a => a.FestivalId)
                                .ThenBy(a => a.Category.Group)
                                .ThenBy(a => a.Category.Order)
                                .Skip(skip)
                                .Take(pageAmount)
                                .ToList());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return null;
            }
        }

        public SingleItemResponse<CategoryDTO> AddCategory(CategoryDTO newCategory)
        {
            var newCategoryFull = new Category
            {
                Title = newCategory.Title,
                EditDate = DateTime.Now,
                EditedBy = userId,
                Group = newCategory.Group,
                Order = newCategory.Order
            };

            using (var context = new AF_Context())
            {
                try
                {
                    context.Categories.Add(newCategory);
                    int recordsAffected = await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public SingleItemResponse<Category> UpdateCategory(Category updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Category> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Festival> AddFestival(Festival newFestival)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Festival> UpdateFestival(Festival updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Festival> GetFestival(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<Festival> GetFestivalsPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<int> CountFestivals()
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Job> AddJob(string title, int userId)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Job> UpdateJob(Job updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Job> GetJob(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<Job> GetAllJobs()
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Play> AddPlay(Play newPlay)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Play> UpdatePlay(Play updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Play> GetPlay(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<Play> SearchPlays(PlaysSearchingCriteria criteria, int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Position> AddPosition(string title, int section, int order, int userId)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Position> UpdatePosition(Position updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Position> GetPosition(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<Position> GetAllPositions()
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationFestivalPersonPosition> AddRelationFestivalPersonPosition(
            RelationFestivalPersonPosition newRelationFestivalPersonPosition)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<bool> RemoveRelationFestivalPersonPosition(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationFestivalPersonPosition> UpdateRelationFestivalPersonPosition(RelationFestivalPersonPosition updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationFestivalPersonPosition> GetRelationFestivalPersonPosition(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonAward> AddRelationPersonAward(RelationPersonAward newRelationPersonAward)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<bool> RemoveRelationPersonAward(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonAward> UpdateRelationPersonAward(RelationPersonAward updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonAward> GetRelationPersonAward(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayJob> AddRelationPersonPlayJob(RelationPersonPlayJob newRelationPersonPlayJob)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<bool> RemoveRelationPersonPlayJob(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayJob> UpdateRelationPersonPlayJob(RelationPersonPlayJob updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayJob> GetRelationPersonPlayJob(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayRole> AddRelationPersonPlayRole(RelationPersonPlayRole newRelationPersonPlayRole)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<bool> RemoveRelationPersonPlayRole(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayRole> UpdateRelationPersonPlayRole(RelationPersonPlayRole updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayRole> GetRelationPersonPlayRole(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
