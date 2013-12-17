using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using AF.Common.DTO;
using AF.Common.Queries;
using AF.Common.Requests;
using AF.Common.Services;
using AF_DataAccessLayer;
using AF_Models;

namespace AF.Services
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
                PlayId = newAward.PlayId,
                EditedBy = GetUserId(),
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
                PlayId = updateData.PlayId,
                EditedBy = GetUserId(),
                EditDate = DateTime.Now
            };

            using (var context = new AF_Context())
            {
                try
                {
                    Award awa = context.Awards.First(a => a.AwardId == updateData.AwardId);
                    context.Entry(awa).CurrentValues.SetValues(updateDataFull);
                    context.SaveChanges();
                    int id = updateData.AwardId;
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
                    Award awa = context.Awards.First(a => a.AwardId == id);
                    //awa.Editor = context.Users.First(u => u.UserId == awa.EditedBy);

                    var newAwardDto = new AwardDataDTO
                    {
                        AwardId = awa.AwardId,
                        CategoryId = awa.CategoryId,
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
                        query = query.Where(a => a.Play.FestivalId == criteria.FestivalIdFilter);
                    if (!String.IsNullOrEmpty(criteria.Author))
                        query = query.Where(a => a.Play.Author.Contains(criteria.Author));
                    if (!String.IsNullOrEmpty(criteria.Title))
                        query = query.Where(a => a.Play.Title.Contains(criteria.Title));
                    if (criteria.CategoryIdFilter != null)
                        query = query.Where(a => a.CategoryId == criteria.CategoryIdFilter);
                    List<AwardMixedDTO> tmp = new List<AwardMixedDTO>();
                    //List<AwardDataDTO> tmp;
                    foreach (Award b in (query.OrderBy(a => a.Play.FestivalId)
                        .ThenBy(a => a.Category.Group)
                        .ThenBy(a => a.Category.Order)
                        .Skip(skip)
                        .Take(pageAmount)))
                    {
                        var newAwardDto = new AwardMixedDTO()
                        {
                            AwardId = b.AwardId,
                            FestivalId = b.Play.FestivalId,
                            CategoryTitle = b.Category.Title,
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
                EditedBy = GetUserId(),
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
                EditedBy = GetUserId(),
                Group = updateData.Group,
                Order = updateData.Order
            };

            using (var context = new AF_Context())
            {
                try
                {
                    Category cat = context.Categories.First(c => c.CategoryId == updateData.CategoryId);
                    context.Entry(cat).CurrentValues.SetValues(updateDataFull);
                    context.SaveChanges();
                    int id = updateData.CategoryId;
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
            }
        }

        #endregion
        #region Festival

        public SingleItemResponse<FestivalDTO> AddFestival(FestivalDTO newFestival)
        {
            var newFestivalFull = new Festival()
            {
                Year = newFestival.Year,
                BeginningDate = newFestival.BeginningDate,
                EndDate = newFestival.EndDate,
                EditedBy = GetUserId(),
                EditDate = DateTime.Now
            };

            using (var context = new AF_Context())
            {
                try
                {
                    context.Festivals.Add(newFestivalFull);
                    context.SaveChanges();
                    int id = newFestivalFull.FestivalId;
                    return GetFestival(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public SingleItemResponse<FestivalDTO> UpdateFestival(FestivalDTO updateData)
        {
            var updateDataFull = new Festival()
            {
                Year = updateData.Year,
                BeginningDate = updateData.BeginningDate,
                EndDate = updateData.EndDate,
                EditedBy = GetUserId(),
                EditDate = DateTime.Now
            };

            using (var context = new AF_Context())
            {
                try
                {
                    Festival fes = context.Festivals.First(f => f.FestivalId == updateData.FestivalId);
                    context.Entry(fes).CurrentValues.SetValues(updateDataFull);
                    context.SaveChanges();
                    int id = updateData.FestivalId;
                    return GetFestival(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public SingleItemResponse<FestivalDTO> GetFestival(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Festival fes = context.Festivals.First(f => f.FestivalId == id);

                    var newFestivalDto = new FestivalDTO()
                    {
                        FestivalId = fes.FestivalId,
                        Year = fes.Year,
                        BeginningDate = fes.BeginningDate,
                        EndDate = fes.EndDate,
                    };
                    return (new SingleItemResponse<FestivalDTO>(newFestivalDto));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public ListResponse<FestivalDTO> GetFestivalsPaged(int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount*(pageNr - 1);
                    List<FestivalDTO> tmp = new List<FestivalDTO>();
                    foreach (Festival fe in (from f in context.Festivals.Include(u => u.Editor)
                        select f).Skip(skip).Take(pageAmount))
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
                    return (new ListResponse<FestivalDTO>(tmp));
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public SingleItemResponse<int> CountFestivals()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    return (new SingleItemResponse<int>(context.Festivals.Count()));
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        #endregion
        #region Job
        public SingleItemResponse<JobDTO> AddJob(JobDTO newJob)
        {
            var newJobFull = new Job()
            {
                JobTitle = newJob.JobTitle,
                EditedBy = GetUserId(),
                EditDate = DateTime.Now
            };

            using (var context = new AF_Context())
            {
                try
                {
                    context.Jobs.Add(newJobFull);
                    context.SaveChanges();
                    int id = newJobFull.JobId;
                    return GetJob(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public SingleItemResponse<JobDTO> UpdateJob(JobDTO updateData)
        {
            var updateDataFull = new Job()
            {
                JobTitle = updateData.JobTitle,
                EditedBy = GetUserId(),
                EditDate = DateTime.Now
            };

            using (var context = new AF_Context())
            {
                try
                {
                    Job jo = context.Jobs.First(j => j.JobId == updateData.JobId);
                    context.Entry(jo).CurrentValues.SetValues(updateDataFull);
                    context.SaveChanges();
                    int id = updateData.JobId;
                    return GetJob(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public SingleItemResponse<JobDTO> GetJob(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Job jo = context.Jobs.First(j => j.JobId == id);

                    var newJobDto = new JobDTO()
                    {
                        JobId = jo.JobId,
                        JobTitle = jo.JobTitle
                    };
                    return (new SingleItemResponse<JobDTO>(newJobDto));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public ListResponse<JobDTO> GetAllJobs()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<JobDTO> tmp = new List<JobDTO>();
                    foreach (Job jo in from j in context.Jobs select j)
                    {
                        var newJobDto = new JobDTO()
                        {
                            JobId = jo.JobId,
                            JobTitle = jo.JobTitle
                        };
                        tmp.Add(newJobDto);
                    }
                    return (new ListResponse<JobDTO>(tmp));
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }
        #endregion
        #region Play

        public SingleItemResponse<PlayDataDTO> AddPlay(PlayDataDTO newPlay)
        {
            var newPlayFull = new Play()
            {
                Title = newPlay.Title,
                Author = newPlay.Author,
                FestivalId = newPlay.FestivalId,
                Day = newPlay.Day,
                Order = newPlay.Order,
                PlayedBy = newPlay.PlayedBy,
                Motto = newPlay.Motto,
                EditedBy = GetUserId(),
                EditDate = DateTime.Now
            };

            using (var context = new AF_Context())
            {
                try
                {
                    context.Plays.Add(newPlayFull);
                    context.SaveChanges();
                    int id = newPlayFull.PlayId;
                    return GetPlay(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public SingleItemResponse<PlayDataDTO> UpdatePlay(PlayDataDTO updateData)
        {
            var updateDataFull = new Play()
            {
                Title = updateData.Title,
                Author = updateData.Author,
                FestivalId = updateData.FestivalId,
                Day = updateData.Day,
                Order = updateData.Order,
                PlayedBy = updateData.PlayedBy,
                Motto = updateData.Motto,
                EditedBy = GetUserId(),
                EditDate = DateTime.Now
            };

            using (var context = new AF_Context())
            {
                try
                {
                    Play pla = context.Plays.First(p => p.PlayId == updateData.PlayId);
                    context.Entry(pla).CurrentValues.SetValues(updateDataFull);
                    context.SaveChanges();
                    int id = updateData.PlayId;
                    return GetPlay(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public SingleItemResponse<PlayDataDTO> GetPlay(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Play pla = context.Plays.First(p => p.PlayId == id);

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
                    return (new SingleItemResponse<PlayDataDTO>(newPlayDto));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public ListResponse<PlayDataDTO> SearchPlays(PlaysSearchingCriteria criteria, int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount*(pageNr - 1);
                    var query = (from p in context.Plays select p);
                    if (criteria.FestivalIdFilter != null)
                        query = query.Where(p => p.FestivalId == criteria.FestivalIdFilter);
                    if (!String.IsNullOrEmpty(criteria.Author))
                        query = query.Where(p => p.Author.Contains(criteria.Author));
                    if (!String.IsNullOrEmpty(criteria.Title))
                        query = query.Where(p => p.Title.Contains(criteria.Title));
                    if (!String.IsNullOrEmpty(criteria.Motto))
                        query = query.Where(p => p.Motto.Contains(criteria.Motto));

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
                    return (new ListResponse<PlayDataDTO>(tmp));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public ListResponse<PlayTitleDTO> SearchPlaysTitles(PlaysSearchingCriteria criteria, int pageNr, int pageAmount)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    var skip = pageAmount * (pageNr - 1);
                    var query = (from p in context.Plays select p);
                    if (criteria.FestivalIdFilter != null)
                        query = query.Where(p => p.FestivalId == criteria.FestivalIdFilter);
                    if (!String.IsNullOrEmpty(criteria.Author))
                        query = query.Where(p => p.Author.Contains(criteria.Author));
                    if (!String.IsNullOrEmpty(criteria.Title))
                        query = query.Where(p => p.Title.Contains(criteria.Title));
                    if (!String.IsNullOrEmpty(criteria.Motto))
                        query = query.Where(p => p.Motto.Contains(criteria.Motto));

                    List<PlayTitleDTO> tmp = new List<PlayTitleDTO>();
                    foreach (Play pla in (query.OrderBy(p => p.FestivalId)
                        .ThenBy(p => p.Day)
                        .ThenBy(p => p.Order)
                        .Skip(skip)
                        .Take(pageAmount)))
                    {
                        var newPlayDto = new PlayTitleDTO()
                        {
                            PlayId = pla.PlayId,
                            Title = pla.Title,
                        };
                        tmp.Add(newPlayDto);
                    }
                    return (new ListResponse<PlayTitleDTO>(tmp));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public SingleItemResponse<PlayTitleDTO> GetPlayTitle(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Play pla = context.Plays.First(p => p.PlayId == id);

                    var newPlayDto = new PlayTitleDTO()
                    {
                        PlayId = pla.PlayId,
                        Title = pla.Title,
                    };
                    return (new SingleItemResponse<PlayTitleDTO>(newPlayDto));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        } 

        #endregion
        #region Position

        public SingleItemResponse<PositionDTO> AddPosition(PositionDTO newPosition)
        {
            var newPositionFull = new Position()
            {
                PositionTitle = newPosition.PositionTitle,
                Section = newPosition.Section,
                Order = newPosition.Order,
                EditedBy = GetUserId(),
                EditDate = DateTime.Now
            };

            using (var context = new AF_Context())
            {
                try
                {
                    context.Positions.Add(newPositionFull);
                    context.SaveChanges();
                    int id = newPositionFull.PositionId;
                    return GetPosition(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public SingleItemResponse<PositionDTO> UpdatePosition(PositionDTO updateData)
        {
            var updateDataFull = new Position()
            {
                PositionTitle = updateData.PositionTitle,
                Section = updateData.Section,
                Order = updateData.Order,
                EditedBy = GetUserId(),
                EditDate = DateTime.Now
            };

            using (var context = new AF_Context())
            {
                try
                {
                    Position pos = context.Positions.First(p => p.PositionId == updateData.PositionId);
                    context.Entry(pos).CurrentValues.SetValues(updateDataFull);
                    context.SaveChanges();
                    int id = updateData.PositionId;
                    return GetPosition(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public SingleItemResponse<PositionDTO> GetPosition(int id)
        {
            using (var context = new AF_Context())
            {
                try
                {
                    Position pos = context.Positions.First(p => p.PositionId == id);
                    //awa.Editor = context.Users.First(u => u.UserId == awa.EditedBy);

                    var newPositionDto = new PositionDTO()
                    {
                        PositionId = pos.PositionId,
                        PositionTitle = pos.PositionTitle,
                        Section = pos.Section,
                        Order = pos.Order
                    };
                    return (new SingleItemResponse<PositionDTO>(newPositionDto));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public ListResponse<PositionDTO> GetAllPositions()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<PositionDTO> tmp = new List<PositionDTO>();
                    foreach (Position pos in context.Positions.OrderBy(s => s.Section).ThenBy(o => o.Order))
                    {
                        var newPositionDto = new PositionDTO()
                        {
                            PositionId = pos.PositionId,
                            PositionTitle = pos.PositionTitle,
                            Section = pos.Section,
                            Order = pos.Order
                        };
                        tmp.Add(newPositionDto);
                    }
                    return (new ListResponse<PositionDTO>(tmp));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        #endregion


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
            using (var context = new AF_Context())
            {
                try
                {
                    User us = context.Users.First(u => u.UserId == id);

                    var newUserDto = new UserDTO()
                    {
                        UserId = us.UserId,
                        Login = us.Login,
                        FirstName = us.FirstName,
                        LastName = us.LastName,
                        Email = us.Email
                    };
                    return (new SingleItemResponse<UserDTO>(newUserDto));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public ListResponse<UserDTO> GetAllUsers()
        {
            using (var context = new AF_Context())
            {
                try
                {
                    List<UserDTO> tmp = new List<UserDTO>();
                    foreach (User a in (from u in context.Users select u))
                    {
                        var newUserDto = new UserDTO()
                        {
                            UserId = a.UserId,
                            Login = a.Login,
                            FirstName = a.FirstName,
                            LastName = a.LastName,
                            Email = a.Email
                        };
                        tmp.Add(newUserDto);
                    }
                    return (new ListResponse<UserDTO>(tmp));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        private int GetUserId()
        {
            string login = ServiceSecurityContext.Current.PrimaryIdentity.Name;
            using (var context = new AF_Context())
            {
                try
                {
                    User us = context.Users.First(u => u.Login == login);
                    return (us.UserId);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
