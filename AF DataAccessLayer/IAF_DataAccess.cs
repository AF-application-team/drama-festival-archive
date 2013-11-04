using AF_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_DataAccessLayer
{
    public interface IAF_DataAccess
    {
        #region Award
        void AddAward(Award newAward);
        void RemoveAward(int id);
        void UpdateAward(Award updateData);
        Award GetAward(int id);
        List<Award> GetAwardsPaged(int pageNr, int pageAmount);
        #endregion
        #region Category
        void AddCategory(Category newCategory);
        void RemoveCategory(int id);
        void UpdateCategory(Category updateData);
        Category GetCategory(int id);
        List<Category> GetCategoriesPaged(int pageNr, int pageAmount);
        List<Category> GetAllCategories();
        #endregion
        #region Festival
        void AddFestival(Festival newFestival);
        void RemoveFestival(int id);
        void UpdateFestival(Festival updateData);
        Festival GetFestival(int id);
        List<Festival> GetFestivalsPaged(int pageNr, int pageAmount);
        #endregion
        #region Job
        void AddJob(Job newJob);
        void RemoveJob(int id);
        void UpdateJob(Job updateData);
        Job GetJob(int id);
        List<Job> GetJobsPaged(int pageNr, int pageAmount);
        List<Job> GetAllJobs(); 
        #endregion
        #region News
        void AddNews(News newNews);
        void RemoveNews(int id);
        void UpdateNews(News updateData);
        News GetNews(int id);
        List<News> GetNewsPaged(int pageNr, int pageAmount);
        #endregion
        #region Person
        void AddPerson(Person newPerson);
        void RemovePerson(int id);
        void UpdatePerson(Person updateData);
        Person GetPerson(int id);
        List<Person> GetPeoplePaged(int pageNr, int pageAmount);
        #endregion
        #region Play
        void AddPlay(Play newPlay);
        void RemovePlay(int id);
        void UpdatePlay(Play updateData);
        Play GetPlay(int id);
        List<Play> GetPlaysPaged(int pageNr, int pageAmount);
        List<Play> GetAllPlays();
        #endregion
        #region Position
        void AddPosition(Position newPosition);
        void RemovePosition(int id);
        void UpdatePosition(Position updateData);
        Position GetPosition(int id);
        List<Position> GetPositionsPaged(int pageNr, int pageAmount);
        List<Position> GetAllPositions();  
        #endregion
        #region RelationFestivalPersonPosition
        void AddRelationFestivalPersonPosition(RelationFestivalPersonPosition newRelationFestivalPersonPosition);
        void RemoveRelationFestivalPersonPosition(int id);
        void UpdateRelationFestivalPersonPosition(RelationFestivalPersonPosition updateData);
        RelationFestivalPersonPosition GetRelationFestivalPersonPosition(int id);
        List<RelationFestivalPersonPosition> GetRelationFestivalPersonPositionPaged(int pageNr, int pageAmount);
        #endregion
        #region RelationPersonAward
        void AddRelationPersonAward(RelationPersonAward newRelationPersonAward);
        void RemoveRelationPersonAward(int id);
        void UpdateRelationPersonAward(RelationPersonAward updateData);
        RelationPersonAward GetRelationPersonAward(int id);
        List<RelationPersonAward> GetRelationPersonAwardPaged(int pageNr, int pageAmount);
        #endregion
        #region RelationPersonPlayJob
        void AddRelationPersonPlayJob(RelationPersonPlayJob newRelationPersonPlayJob);
        void RemoveRelationPersonPlayJob(int id);
        void UpdateRelationPersonPlayJob(RelationPersonPlayJob updateData);
        RelationPersonPlayJob GetRelationPersonPlayJob(int id);
        List<RelationPersonPlayJob> GetRelationPersonPlayJobPaged(int pageNr, int pageAmount);
        #endregion
        #region RelationPersonPlayRole
        void AddRelationPersonPlayRole(RelationPersonPlayRole newRelationPersonPlayRole);
        void RemoveRelationPersonPlayRole(int id);
        void UpdateRelationPersonPlayRole(RelationPersonPlayRole updateData);
        RelationPersonPlayRole GetRelationPersonPlayRole(int id);
        List<RelationPersonPlayRole> GetRelationPersonPlayRolePaged(int pageNr, int pageAmount);
        #endregion
        #region User
        void AddUser(User newUser);
        void RemoveUser(int id);
        void UpdateUser(User updateData);
        User GetUser(int id);
        List<User> GetUserPaged(int pageNr, int pageAmount);
        List<User> GetAllUsers();
        #endregion
    }
}
