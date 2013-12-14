using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using AF.Common.DTO;
using AF.Common.Queries;
using AF_Models;

namespace AF_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAFService
    {
        #region Award
        [OperationContract]
        Award AddAward(int playId, int festivalId, int categoryId, int userId);
        //Void RemoveAward(int id);
        [OperationContract]
        Award UpdateAward(Award updateData);
        [OperationContract]
        Award GetAward(int id);
        //List<AwardDTO> GetAwardsPaged(int pageNr, int pageAmount);
        [OperationContract]
        List<AwardMixedDTO> SearchAwards(AwardsSearchingCriteria criteria, int pageNr, int pageAmount);
        //<List<Award> GetAllAwards();
        #endregion
        #region Category
        [OperationContract]
        Category AddCategory(string title, int group, int order, int userId);
        //RemoveCategory(int id);
        [OperationContract]
        Category UpdateCategory(Category updateData);
        [OperationContract]
        Category GetCategory(int id);
        //List<Category> GetCategoriesPaged(int pageNr, int pageAmount);
        [OperationContract]
        List<Category> GetAllCategories();
        #endregion
        #region Festival
        [OperationContract]
        Festival AddFestival(Festival newFestival);
        //RemoveFestival(int id);
        [OperationContract]
        Festival UpdateFestival(Festival updateData);
        [OperationContract]
        Festival GetFestival(int id);
        [OperationContract]
        List<Festival> GetFestivalsPaged(int pageNr, int pageAmount);
        //List<Festival> GetAllFestivals();
        int CountFestivals();
        #endregion
        #region Job
        [OperationContract]
        Job AddJob(string title, int userId);
        //RemoveJob(int id);
        [OperationContract]
        Job UpdateJob(Job updateData);
        [OperationContract]
        Job GetJob(int id);
        //List<Job> GetJobsPaged(int pageNr, int pageAmount);
        [OperationContract]
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
        [OperationContract]
        Play AddPlay(Play newPlay);
        //RemovePlay(int id);
        [OperationContract]
        Play UpdatePlay(Play updateData);
        [OperationContract]
        Play GetPlay(int id);
        //List<PlayDTO> GetPlaysPaged(int pageNr, int pageAmount);
        //List<Play> GetAllPlays();
        [OperationContract]
        List<Play> SearchPlays(PlaysSearchingCriteria criteria, int pageNr, int pageAmount);
        #endregion
        #region Position
        [OperationContract]
        Position AddPosition(string title, int section, int order, int userId);
        //RemovePosition(int id);
        [OperationContract]
        Position UpdatePosition(Position updateData);
        [OperationContract]
        Position GetPosition(int id);
        //List<Position> GetPositionsPaged(int pageNr, int pageAmount);
        [OperationContract]
        List<Position> GetAllPositions();
        #endregion
        #region RelationFestivalPersonPosition
        [OperationContract]
        RelationFestivalPersonPosition AddRelationFestivalPersonPosition(RelationFestivalPersonPosition newRelationFestivalPersonPosition);
        [OperationContract]
        bool RemoveRelationFestivalPersonPosition(int id);
        [OperationContract]
        RelationFestivalPersonPosition UpdateRelationFestivalPersonPosition(RelationFestivalPersonPosition updateData);
        [OperationContract]
        RelationFestivalPersonPosition GetRelationFestivalPersonPosition(int id);
        //List<RelationFestivalPersonPosition> GetRelationFestivalPersonPositionPaged(int pageNr, int pageAmount);
        //List<RelationFestivalPersonPosition> GetAllRelationFestivalPersonPosition();
        #endregion
        #region RelationPersonAward
        [OperationContract]
        RelationPersonAward AddRelationPersonAward(RelationPersonAward newRelationPersonAward);
        [OperationContract]
        bool RemoveRelationPersonAward(int id);
        [OperationContract]
        RelationPersonAward UpdateRelationPersonAward(RelationPersonAward updateData);
        [OperationContract]
        RelationPersonAward GetRelationPersonAward(int id);
        //List<RelationPersonAward> GetRelationPersonAwardPaged(int pageNr, int pageAmount);
        //List<RelationPersonAward> GetAllRelationPersonAward();
        #endregion
        #region RelationPersonPlayJob
        [OperationContract]
        RelationPersonPlayJob AddRelationPersonPlayJob(RelationPersonPlayJob newRelationPersonPlayJob);
        [OperationContract]
        bool RemoveRelationPersonPlayJob(int id);
        [OperationContract]
        RelationPersonPlayJob UpdateRelationPersonPlayJob(RelationPersonPlayJob updateData);
        [OperationContract]
        RelationPersonPlayJob GetRelationPersonPlayJob(int id);
        //List<RelationPersonPlayJob> GetRelationPersonPlayJobPaged(int pageNr, int pageAmount);
        //List<RelationPersonPlayJob> GetAllRelationPersonPlayJob();
        #endregion
        #region RelationPersonPlayRole
        [OperationContract]
        RelationPersonPlayRole AddRelationPersonPlayRole(RelationPersonPlayRole newRelationPersonPlayRole);
        [OperationContract]
        bool RemoveRelationPersonPlayRole(int id);
        [OperationContract]
        RelationPersonPlayRole UpdateRelationPersonPlayRole(RelationPersonPlayRole updateData);
        [OperationContract]
        RelationPersonPlayRole GetRelationPersonPlayRole(int id);
        //List<RelationPersonPlayRole> GetRelationPersonPlayRolePaged(int pageNr, int pageAmount);
        //List<RelationPersonPlayRole> GetAllRelationPersonPlayRole();
        #endregion
        #region User
        //User AddUser(User newUser);
        //bool RemoveUser(int id);
        //UpdateUser(User updateData);
        [OperationContract]
        User GetUser(int id);
        //List<User> GetUserPaged(int pageNr, int pageAmount);
        [OperationContract]
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
