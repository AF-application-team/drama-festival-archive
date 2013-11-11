using System.Collections.ObjectModel;
using AF_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AF_Models;

namespace AF_BusinessLogic
{
    public class AF_Logic : IAF_LogicService
    {
        IAF_DataAccess DataAccess = new AF_DataAccess();

        #region Awards
        public async Task AddAward(Award newAward)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAward(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAward(Award updateData)
        {
            throw new NotImplementedException();
        }

        public async Task<Award> GetAward(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Award>> GetAwardsPaged(int pageNr, int pageAmount)
        {
            return await DataAccess.GetAwardsPaged(pageNr, pageAmount);
        }

        public async Task<List<Award>> GetAllAwards()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Categories
        public async Task AddCategory(string title, int group, int order, int userId)
        {
            var newCategory = new Category
            {
                Title = title,
                EditDate = DateTime.Now,
                EditedBy = userId,
                Group = group,
                Order = order
            };
            await DataAccess.AddCategory(newCategory);
        }


        public async Task RemoveCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCategory(Category updateData)
        {
            await DataAccess.UpdateCategory(updateData);
        }

        public async Task<Category> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetCategoriesPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await DataAccess.GetAllCategories();
        } 
        #endregion
        #region Festivals
        public async Task AddFestival(Festival newFestival)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveFestival(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateFestival(Festival updateData)
        {
            throw new NotImplementedException();
        }

        public async Task<Festival> GetFestival(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Festival>> GetFestivalsPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Festival>> GetAllFestivals()
        {
            throw new NotImplementedException();
        } 
        #endregion
        #region Jobs
        public async Task AddJob(string title, int userId)
        {
            var newJob = new Job
            {
                JobTitle = title,
                EditDate = DateTime.Now,
                EditedBy = userId
            };
            await DataAccess.AddJob(newJob);
        }

        public async Task RemoveJob(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateJob(Job updateData)
        {
            await DataAccess.UpdateJob(updateData);
        }

        public async Task<Job> GetJob(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Job>> GetJobsPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Job>> GetAllJobs()
        {
            return await DataAccess.GetAllJobs();
        } 
        #endregion
        #region News
        public async Task AddNews(News newNews)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveNews(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateNews(News updateData)
        {
            throw new NotImplementedException();
        }

        public async Task<News> GetNews(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<News>> GetNewsPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public async Task<List<News>> GetAllNews()
        {
            throw new NotImplementedException();
        } 
        #endregion
        #region People
        public async Task AddPerson(Person newPerson)
        {
            throw new NotImplementedException();
        }

        public async Task RemovePerson(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePerson(Person updateData)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Person>> GetPeoplePaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Person>> GetAllPeople()
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region Plays
        public async Task AddPlay(Play newPlay)
        {
            throw new NotImplementedException();
        }

        public async Task RemovePlay(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePlay(Play updateData)
        {
            throw new NotImplementedException();
        }

        public async Task<Play> GetPlay(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Play>> GetPlaysPaged(int pageNr, int pageAmount)
        {
            return await DataAccess.GetPlaysPaged(pageNr, pageAmount);
        }

        public async Task<List<Play>> GetAllPlays()
        {
            throw new NotImplementedException();
        } 
        #endregion
        #region Positions
        public async Task AddPosition(string title, int section, int order, int userId)
        {
            var newPosition= new Position
            {
                PositionTitle = title,
                Section = section,
                Order = order,
                EditDate = DateTime.Now,
                EditedBy = userId
            };
            await DataAccess.AddPosition(newPosition);
        }

        public async Task RemovePosition(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePosition(Position updateData)
        {
            await DataAccess.UpdatePosition(updateData);
        }

        public async Task<Position> GetPosition(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Position>> GetPositionsPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Position>> GetAllPositions()
        {
            return await DataAccess.GetAllPositions();
        } 
        #endregion
        
        #region RelationFestivalPersonPosition
        public async Task AddRelationFestivalPersonPosition(RelationFestivalPersonPosition newRelationFestivalPersonPosition)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveRelationFestivalPersonPosition(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRelationFestivalPersonPosition(RelationFestivalPersonPosition updateData)
        {
            throw new NotImplementedException();
        }

        public async Task<RelationFestivalPersonPosition> GetRelationFestivalPersonPosition(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RelationFestivalPersonPosition>> GetRelationFestivalPersonPositionPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RelationFestivalPersonPosition>> GetAllRelationFestivalPersonPosition()
        {
            throw new NotImplementedException();
        } 
        #endregion
        #region RelationPersonAward
        public async Task AddRelationPersonAward(RelationPersonAward newRelationPersonAward)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveRelationPersonAward(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRelationPersonAward(RelationPersonAward updateData)
        {
            throw new NotImplementedException();
        }

        public async Task<RelationPersonAward> GetRelationPersonAward(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RelationPersonAward>> GetRelationPersonAwardPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RelationPersonAward>> GetAllRelationPersonAward()
        {
            throw new NotImplementedException();
        } 
        #endregion
        #region RelationPersonPlayJob
        public async Task AddRelationPersonPlayJob(RelationPersonPlayJob newRelationPersonPlayJob)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveRelationPersonPlayJob(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRelationPersonPlayJob(RelationPersonPlayJob updateData)
        {
            throw new NotImplementedException();
        }

        public async Task<RelationPersonPlayJob> GetRelationPersonPlayJob(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RelationPersonPlayJob>> GetRelationPersonPlayJobPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RelationPersonPlayJob>> GetAllRelationPersonPlayJob()
        {
            throw new NotImplementedException();
        } 
        #endregion
        #region RelationPersonPlayRole
        public async Task AddRelationPersonPlayRole(RelationPersonPlayRole newRelationPersonPlayRole)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveRelationPersonPlayRole(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRelationPersonPlayRole(RelationPersonPlayRole updateData)
        {
            throw new NotImplementedException();
        }

        public async Task<RelationPersonPlayRole> GetRelationPersonPlayRole(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RelationPersonPlayRole>> GetRelationPersonPlayRolePaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RelationPersonPlayRole>> GetAllRelationPersonPlayRole()
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region Users
        public async Task AddUser(User newUser)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser(User updateData)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(int id)
        {
            return await DataAccess.GetUser(id);
        }

        public async Task<List<User>> GetUserPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
