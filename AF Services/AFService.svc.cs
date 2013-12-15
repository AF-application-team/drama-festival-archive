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
        public AFService()
        {
            Console.WriteLine("AF Service started to work...");
        }
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


        #region Awards
        public SingleItemResponse<AwardDataDTO> AddAward(AwardDataDTO newAward)
        {
            var newAwardFull = new Award()
            {
                CategoryId = newAward.CategoryId,
                FestivalId = newAward.FestivalId,
                PlayId = newAward.PlayId,
                //EditedBy = userId,
                EditDate = DateTime.Now
            };

            using (var context = new AF_Context())
            {
                try
                {
                    context.Awards.Add(newAwardFull);
                    context.SaveChanges();
                    int id = newAwardFull.AwardId;
                    return GetAward(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public SingleItemResponse<AwardDataDTO> UpdateAward(AwardDataDTO updateData)
        {
            var updateDataFull = new Award()
            {
                CategoryId = updateData.CategoryId,
                FestivalId = updateData.FestivalId,
                PlayId = updateData.PlayId,
                //EditedBy = userId,
                EditDate = DateTime.Now
            };

            using (var context = new AF_Context())
            {
                try
                {
                    Award awa = context.Awards.First(a => a.AwardId == updateData.AwardId);
                    context.Entry(awa).CurrentValues.SetValues(updateDataFull);
                    context.SaveChanges();
                    int id = updateDataFull.AwardId;
                    return GetAward(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public SingleItemResponse<AwardDataDTO> GetAward(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Award awa = context.Awards.First(a => a.CategoryId == id);
                    //awa.Editor = context.Users.First(u => u.UserId == awa.EditedBy);

                    var newAwardDto = new AwardDataDTO()
                    {
                        AwardId = awa.AwardId,
                        CategoryId = awa.CategoryId,
                        FestivalId = awa.FestivalId,
                        PlayId = awa.PlayId,
                    };
                    return (new SingleItemResponse<AwardDataDTO>(newAwardDto));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public ListResponse<AwardMixedDTO> SearchAwards(AwardsSearchingCriteria criteria, int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount*(pageNr - 1);
                    var query = (from a in context.Awards select a).Include(a => a.Play).Include(a => a.Category);
                    if (criteria.FestivalIdFilter != null)
                        query = query.Where(a => a.FestivalId == criteria.FestivalIdFilter);
                    if (!String.IsNullOrEmpty(criteria.Author))
                        query = query.Where(a => a.Play.Author.Contains(criteria.Author));
                    if (!String.IsNullOrEmpty(criteria.Title))
                        query = query.Where(a => a.Play.Title.Contains(criteria.Title));
                    if (criteria.CategoryIdFilter != null)
                        query = query.Where(a => a.CategoryId == criteria.CategoryIdFilter);
                    List<AwardMixedDTO> tmp = new List<AwardMixedDTO>();
                    //List<AwardDataDTO> tmp;
                    foreach (Award b in (query.OrderBy(a => a.FestivalId)
                        .ThenBy(a => a.Category.Group)
                        .ThenBy(a => a.Category.Order)
                        .Skip(skip)
                        .Take(pageAmount)))
                    {
                        var newAwardDto = new AwardMixedDTO()
                        {
                            AwardId = b.AwardId,
                            CategoryTitle = b.Category.Title,
                            FestivalId = b.FestivalId,
                            PlayTitle = b.Play.Title,
                        };
                        tmp.Add(newAwardDto);
                    }
                    return (new ListResponse<AwardMixedDTO>(tmp));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        #endregion
        #region Category

        public SingleItemResponse<CategoryDTO> AddCategory(CategoryDTO newCategory)
        {
            var newCategoryFull = new Category
            {
                Title = newCategory.Title,
                EditDate = DateTime.Now,
                //EditedBy = userId,
                Group = newCategory.Group,
                Order = newCategory.Order
            };

            using (var context = new AF_Context())
            {
                try
                {
                    context.Categories.Add(newCategoryFull);
                    context.SaveChanges();
                    int id = newCategoryFull.CategoryId;
                    return GetCategory(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public SingleItemResponse<CategoryDTO> UpdateCategory(CategoryDTO updateData)
        {
            var updateDataFull = new Category
            {
                Title = updateData.Title,
                EditDate = DateTime.Now,
                //EditedBy = userId,
                Group = updateData.Group,
                Order = updateData.Order
            };

            using (var context = new AF_Context())
            {
                try
                {
                    Category cat = context.Categories.First(c => c.CategoryId == updateData.CategoryId);
                    cat.CategoryId = updateData.CategoryId;
                    cat.EditDate = DateTime.Now;
                    //cat.EditedBy = updateData.EditedBy;
                    cat.Group = updateData.Group;
                    cat.Order = updateData.Order;
                    cat.Title = updateData.Title;
                    context.SaveChanges();
                    int id = updateDataFull.CategoryId;
                    return GetCategory(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public SingleItemResponse<CategoryDTO> GetCategory(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Category cat = context.Categories.First(c => c.CategoryId == id);
                    //cat.Editor = context.Users.First(u => u.UserId == cat.EditedBy);

                    var newCategoryDto = new CategoryDTO()
                    {
                        CategoryId = cat.CategoryId,
                        Title = cat.Title,
                        Group = cat.Group,
                        Order = cat.Order,
                    };
                    return (new SingleItemResponse<CategoryDTO>(newCategoryDto));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public ListResponse<CategoryDTO> GetAllCategories()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<CategoryDTO> tmp = new List<CategoryDTO>();
                    foreach (Category a in context.Categories.OrderBy(c => c.Group).ThenBy(c => c.Order))
                    {
                        var newCategoryDto = new CategoryDTO()
                        {
                            CategoryId = a.CategoryId,
                            Title = a.Title,
                            Group = a.Group,
                            Order = a.Order,
                        };
                        tmp.Add(newCategoryDto);
                    }
                    return (new ListResponse<CategoryDTO>(tmp));
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        #endregion
        public SingleItemResponse<FestivalDTO> AddFestival(FestivalDTO newFestival)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<FestivalDTO> UpdateFestival(FestivalDTO updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<FestivalDTO> GetFestival(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<FestivalDTO> GetFestivalsPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<int> CountFestivals()
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<JobDTO> AddJob(JobDTO newJob)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<JobDTO> UpdateJob(JobDTO updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<JobDTO> GetJob(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<JobDTO> GetAllJobs()
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<PlayDataDTO> AddPlay(PlayDataDTO newPlay)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<PlayDataDTO> UpdatePlay(PlayDataDTO updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<PlayDataDTO> GetPlay(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<PlayDataDTO> SearchPlays(PlaysSearchingCriteria criteria, int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<PositionDTO> AddPosition(PositionDTO newPosition)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<PositionDTO> UpdatePosition(PositionDTO updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<PositionDTO> GetPosition(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<PositionDTO> GetAllPositions()
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationFestivalPersonPositionDTO> AddRelationFestivalPersonPosition(RelationFestivalPersonPositionDTO newRelationFestivalPersonPosition)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<bool> RemoveRelationFestivalPersonPosition(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationFestivalPersonPositionDTO> UpdateRelationFestivalPersonPosition(RelationFestivalPersonPositionDTO updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationFestivalPersonPositionDTO> GetRelationFestivalPersonPosition(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonAwardDTO> AddRelationPersonAward(RelationPersonAwardDTO newRelationPersonAward)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<bool> RemoveRelationPersonAward(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonAwardDTO> UpdateRelationPersonAward(RelationPersonAwardDTO updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonAwardDTO> GetRelationPersonAward(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayJobDTO> AddRelationPersonPlayJob(RelationPersonPlayJobDTO newRelationPersonPlayJob)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<bool> RemoveRelationPersonPlayJob(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayJobDTO> UpdateRelationPersonPlayJob(RelationPersonPlayJobDTO updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayJobDTO> GetRelationPersonPlayJob(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayRoleDTO> AddRelationPersonPlayRole(RelationPersonPlayRoleDTO newRelationPersonPlayRole)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<bool> RemoveRelationPersonPlayRole(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayRoleDTO> UpdateRelationPersonPlayRole(RelationPersonPlayRoleDTO updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayRoleDTO> GetRelationPersonPlayRole(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<UserDTO> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<UserDTO> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
