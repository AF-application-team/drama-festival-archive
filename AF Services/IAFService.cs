using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AF_Models;

namespace AF_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAFService
    {
        #region Award
        Award AddAward(int playId, int festivalId, int categoryId, int userId);
        //Void RemoveAward(int id);
        Award UpdateAward(Award updateData);
        Award GetAward(int id);
        //List<AwardDTO> GetAwardsPaged(int pageNr, int pageAmount);
        List<AwardDTO> SearchAwards(AwardsSearchingCriteria criteria, int pageNr, int pageAmount);
        //<List<Award> GetAllAwards();
        #endregion
        #region Category
        Category AddCategory(string title, int group, int order, int userId);
        //RemoveCategory(int id);
        Category UpdateCategory(Category updateData);
        Category GetCategory(int id);
        //List<Category> GetCategoriesPaged(int pageNr, int pageAmount);
        List<Category> GetAllCategories();
        #endregion
        #region Festival
        Festival AddFestival(Festival newFestival);
        //RemoveFestival(int id);
        Festival UpdateFestival(Festival updateData);
        Festival GetFestival(int id);
        List<Festival> GetFestivalsPaged(int pageNr, int pageAmount);
        //List<Festival> GetAllFestivals();
        int CountFestivals();
        #endregion
        #region Job
        Job AddJob(string title, int userId);
        //RemoveJob(int id);
        Job UpdateJob(Job updateData);
        Job GetJob(int id);
        //List<Job> GetJobsPaged(int pageNr, int pageAmount);
        List<Job> GetAllJobs();
        #endregion
        #region News
        //AddNews(News newNews);
        //RemoveNews(int id);
        //UpdateNews(News updateData);
        //News GetNews(int id);
        //List<News> GetNewsPaged(int pageNr, int pageAmount);
        //List<News> GetAllNews();
        #endregion
        #region Person
        //Person AddPerson(Person newPerson);
        //RemovePerson(int id);
        //Person UpdatePerson(Person updateData);
        //Person GetPerson(int id);
        //List<PersonDTO> GetPeoplePaged(int pageNr, int pageAmount);
        //List<Person> GetAllPeople();
        #endregion
        #region Play
        Play AddPlay(Play newPlay);
        //RemovePlay(int id);
        Play UpdatePlay(Play updateData);
        Play GetPlay(int id);
        //List<PlayDTO> GetPlaysPaged(int pageNr, int pageAmount);
        //List<Play> GetAllPlays();
        List<Play> SearchPlays(PlaysSearchingCriteria criteria, int pageNr, int pageAmount);
        #endregion
        #region Position
        Position AddPosition(string title, int section, int order, int userId);
        //RemovePosition(int id);
        Position UpdatePosition(Position updateData);
        Position GetPosition(int id);
        //List<Position> GetPositionsPaged(int pageNr, int pageAmount);
        List<Position> GetAllPositions();
        #endregion
        #region RelationFestivalPersonPosition
        RelationFestivalPersonPosition AddRelationFestivalPersonPosition(RelationFestivalPersonPosition newRelationFestivalPersonPosition);
        bool RemoveRelationFestivalPersonPosition(int id);
        RelationFestivalPersonPosition UpdateRelationFestivalPersonPosition(RelationFestivalPersonPosition updateData);
        RelationFestivalPersonPosition GetRelationFestivalPersonPosition(int id);
        //List<RelationFestivalPersonPosition> GetRelationFestivalPersonPositionPaged(int pageNr, int pageAmount);
        //List<RelationFestivalPersonPosition> GetAllRelationFestivalPersonPosition();
        #endregion
        #region RelationPersonAward
        RelationPersonAward AddRelationPersonAward(RelationPersonAward newRelationPersonAward);
        bool RemoveRelationPersonAward(int id);
        RelationPersonAward UpdateRelationPersonAward(RelationPersonAward updateData);
        RelationPersonAward GetRelationPersonAward(int id);
        //List<RelationPersonAward> GetRelationPersonAwardPaged(int pageNr, int pageAmount);
        //List<RelationPersonAward> GetAllRelationPersonAward();
        #endregion
        #region RelationPersonPlayJob
        RelationPersonPlayJob AddRelationPersonPlayJob(RelationPersonPlayJob newRelationPersonPlayJob);
        bool RemoveRelationPersonPlayJob(int id);
        RelationPersonPlayJob UpdateRelationPersonPlayJob(RelationPersonPlayJob updateData);
        RelationPersonPlayJob GetRelationPersonPlayJob(int id);
        //List<RelationPersonPlayJob> GetRelationPersonPlayJobPaged(int pageNr, int pageAmount);
        //List<RelationPersonPlayJob> GetAllRelationPersonPlayJob();
        #endregion
        #region RelationPersonPlayRole
        RelationPersonPlayRole AddRelationPersonPlayRole(RelationPersonPlayRole newRelationPersonPlayRole);
        bool RemoveRelationPersonPlayRole(int id);
        RelationPersonPlayRole UpdateRelationPersonPlayRole(RelationPersonPlayRole updateData);
        RelationPersonPlayRole GetRelationPersonPlayRole(int id);
        //List<RelationPersonPlayRole> GetRelationPersonPlayRolePaged(int pageNr, int pageAmount);
        //List<RelationPersonPlayRole> GetAllRelationPersonPlayRole();
        #endregion
        #region User
        //User AddUser(User newUser);
        //bool RemoveUser(int id);
        //UpdateUser(User updateData);
        User GetUser(int id);
        //List<User> GetUserPaged(int pageNr, int pageAmount);
        List<User> GetAllUsers();
        #endregion


        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
