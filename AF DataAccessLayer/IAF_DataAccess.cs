using AF_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AF_Searching_Criteria;

namespace AF_DataAccessLayer
{
    public interface IAF_DataAccess
    {
        #region Award
        Task AddAward(Award newAward);
        Task RemoveAward(int id);
        Task UpdateAward(Award updateData);
        Task<Award> GetAward(int id);
        Task<List<Award>> GetAwardsPaged(int pageNr, int pageAmount);
        Task<List<Award>> GetAllAwards();
        Task<List<Award>> SearchAwards(AwardsSearchingCriteria criteria, int pageNr, int pageAmount);
        #endregion
        #region Category
        Task AddCategory(Category newCategory);
        Task RemoveCategory(int id);
        Task UpdateCategory(Category updateData);
        Task<Category> GetCategory(int id);
        Task<List<Category>> GetCategoriesPaged(int pageNr, int pageAmount);
        Task<List<Category>> GetAllCategories();
        #endregion
        #region Festival
        Task AddFestival(Festival newFestival);
        Task RemoveFestival(int id);
        Task UpdateFestival(Festival updateData);
        Task<Festival> GetFestival(int id);
        Task<List<Festival>> GetFestivalsPaged(int pageNr, int pageAmount);
        Task<List<Festival>> GetAllFestivals();
        Task<int> CountFestivals();
        #endregion
        #region Job
        Task AddJob(Job newJob);
        Task RemoveJob(int id);
        Task UpdateJob(Job updateData);
        Task<Job> GetJob(int id);
        Task<List<Job>> GetJobsPaged(int pageNr, int pageAmount);
        Task<List<Job>> GetAllJobs(); 
        #endregion
        #region News
        Task AddNews(News newNews);
        Task RemoveNews(int id);
        Task UpdateNews(News updateData);
        Task<News> GetNews(int id);
        Task<List<News>> GetNewsPaged(int pageNr, int pageAmount);
        Task<List<News>> GetAllNews(); 
        #endregion
        #region Person
        Task AddPerson(Person newPerson);
        Task RemovePerson(int id);
        Task UpdatePerson(Person updateData);
        Task<Person> GetPerson(int id);
        Task<List<Person>> GetPeoplePaged(int pageNr, int pageAmount);
        Task<List<Person>> GetAllPeople(); 
        #endregion
        #region Play
        Task AddPlay(Play newPlay);
        Task RemovePlay(int id);
        Task UpdatePlay(Play updateData);
        Task<Play> GetPlay(int id);
        Task<List<Play>> GetPlaysPaged(int pageNr, int pageAmount);
        Task<List<Play>> GetAllPlays();
        Task<List<Play>> SearchPlays(PlaysSearchingCriteria criteria, int pageNr, int pageAmount);
        #endregion
        #region Position
        Task AddPosition(Position newPosition);
        Task RemovePosition(int id);
        Task UpdatePosition(Position updateData);
        Task<Position> GetPosition(int id);
        Task<List<Position>> GetPositionsPaged(int pageNr, int pageAmount);
        Task<List<Position>> GetAllPositions();  
        #endregion
        #region RelationFestivalPersonPosition
        Task AddRelationFestivalPersonPosition(RelationFestivalPersonPosition newRelationFestivalPersonPosition);
        Task RemoveRelationFestivalPersonPosition(int id);
        Task UpdateRelationFestivalPersonPosition(RelationFestivalPersonPosition updateData);
        Task<RelationFestivalPersonPosition> GetRelationFestivalPersonPosition(int id);
        Task<List<RelationFestivalPersonPosition>> GetRelationFestivalPersonPositionPaged(int pageNr, int pageAmount);
        Task<List<RelationFestivalPersonPosition>> GetAllRelationFestivalPersonPosition(); 
        #endregion
        #region RelationPersonAward
        Task AddRelationPersonAward(RelationPersonAward newRelationPersonAward);
        Task RemoveRelationPersonAward(int id);
        Task UpdateRelationPersonAward(RelationPersonAward updateData);
        Task<RelationPersonAward> GetRelationPersonAward(int id);
        Task<List<RelationPersonAward>> GetRelationPersonAwardPaged(int pageNr, int pageAmount);
        Task<List<RelationPersonAward>> GetAllRelationPersonAward();
        #endregion
        #region RelationPersonPlayJob
        Task AddRelationPersonPlayJob(RelationPersonPlayJob newRelationPersonPlayJob);
        Task RemoveRelationPersonPlayJob(int id);
        Task UpdateRelationPersonPlayJob(RelationPersonPlayJob updateData);
        Task<RelationPersonPlayJob> GetRelationPersonPlayJob(int id);
        Task<List<RelationPersonPlayJob>> GetRelationPersonPlayJobPaged(int pageNr, int pageAmount);
        Task<List<RelationPersonPlayJob>> GetAllRelationPersonPlayJob();
        #endregion
        #region RelationPersonPlayRole
        Task AddRelationPersonPlayRole(RelationPersonPlayRole newRelationPersonPlayRole);
        Task RemoveRelationPersonPlayRole(int id);
        Task UpdateRelationPersonPlayRole(RelationPersonPlayRole updateData);
        Task<RelationPersonPlayRole> GetRelationPersonPlayRole(int id);
        Task<List<RelationPersonPlayRole>> GetRelationPersonPlayRolePaged(int pageNr, int pageAmount);
        Task<List<RelationPersonPlayRole>> GetAllRelationPersonPlayRole();
        #endregion
        #region User
        Task AddUser(User newUser);
        Task RemoveUser(int id);
        Task UpdateUser(User updateData);
        Task<User> GetUser(int id);
        Task<List<User>> GetUserPaged(int pageNr, int pageAmount);
        Task<List<User>> GetAllUsers();
        #endregion
    }
}
