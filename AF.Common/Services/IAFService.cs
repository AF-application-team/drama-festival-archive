using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using AF.Common.DTO;
using AF.Common.Queries;
using AF.Common.Requests;
using AF_Models;

namespace AF.Common.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAFService
    {
        #region Award
        [OperationContract]
        SingleItemResponse<Award> AddAward(int playId, int festivalId, int categoryId, int userId);
        //Void RemoveAward(int id);
        [OperationContract]
        SingleItemResponse<Award> UpdateAward(Award updateData);
        [OperationContract]
        SingleItemResponse<Award> GetAward(int id);
        //List<AwardDTO> GetAwardsPaged(int pageNr, int pageAmount);
        [OperationContract]
        ListResponse<AwardMixedDTO> SearchAwards(AwardsSearchingCriteria criteria, int pageNr, int pageAmount);
        //<List<Award> GetAllAwards();
        #endregion
        #region Category
        [OperationContract]
        SingleItemResponse<Category> AddCategory(string title, int group, int order, int userId);
        //RemoveCategory(int id);
        [OperationContract]
        SingleItemResponse<Category> UpdateCategory(Category updateData);
        [OperationContract]
        SingleItemResponse<Category> GetCategory(int id);
        //List<Category> GetCategoriesPaged(int pageNr, int pageAmount);
        [OperationContract]
        ListResponse<Category> GetAllCategories();
        #endregion
        #region Festival
        [OperationContract]
        SingleItemResponse<Festival> AddFestival(Festival newFestival);
        //RemoveFestival(int id);
        [OperationContract]
        SingleItemResponse<Festival> UpdateFestival(Festival updateData);
        [OperationContract]
        SingleItemResponse<Festival> GetFestival(int id);
        [OperationContract]
        ListResponse<Festival> GetFestivalsPaged(int pageNr, int pageAmount);
        //List<Festival> GetAllFestivals();
        int CountFestivals();
        #endregion
        #region Job
        [OperationContract]
        SingleItemResponse<Job> AddJob(string title, int userId);
        //RemoveJob(int id);
        [OperationContract]
        SingleItemResponse<Job> UpdateJob(Job updateData);
        [OperationContract]
        SingleItemResponse<Job> GetJob(int id);
        //List<Job> GetJobsPaged(int pageNr, int pageAmount);
        [OperationContract]
        ListResponse<Job> GetAllJobs();
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
        SingleItemResponse<Play> AddPlay(Play newPlay);
        //RemovePlay(int id);
        [OperationContract]
        SingleItemResponse<Play> UpdatePlay(Play updateData);
        [OperationContract]
        SingleItemResponse<Play> GetPlay(int id);
        //List<PlayDTO> GetPlaysPaged(int pageNr, int pageAmount);
        //List<Play> GetAllPlays();
        [OperationContract]
        ListResponse<Play> SearchPlays(PlaysSearchingCriteria criteria, int pageNr, int pageAmount);
        #endregion
        #region Position
        [OperationContract]
        SingleItemResponse<Position> AddPosition(string title, int section, int order, int userId);
        //RemovePosition(int id);
        [OperationContract]
        SingleItemResponse<Position> UpdatePosition(Position updateData);
        [OperationContract]
        SingleItemResponse<Position> GetPosition(int id);
        //List<Position> GetPositionsPaged(int pageNr, int pageAmount);
        [OperationContract]
        ListResponse<Position> GetAllPositions();
        #endregion
        #region RelationFestivalPersonPosition
        [OperationContract]
        SingleItemResponse<RelationFestivalPersonPosition> AddRelationFestivalPersonPosition(RelationFestivalPersonPosition newRelationFestivalPersonPosition);
        [OperationContract]
        SingleItemResponse<bool> RemoveRelationFestivalPersonPosition(int id);
        [OperationContract]
        SingleItemResponse<RelationFestivalPersonPosition> UpdateRelationFestivalPersonPosition(RelationFestivalPersonPosition updateData);
        [OperationContract]
        SingleItemResponse<RelationFestivalPersonPosition> GetRelationFestivalPersonPosition(int id);
        //List<RelationFestivalPersonPosition> GetRelationFestivalPersonPositionPaged(int pageNr, int pageAmount);
        //List<RelationFestivalPersonPosition> GetAllRelationFestivalPersonPosition();
        #endregion
        #region RelationPersonAward
        [OperationContract]
        SingleItemResponse<RelationPersonAward> AddRelationPersonAward(RelationPersonAward newRelationPersonAward);
        [OperationContract]
        SingleItemResponse<bool> RemoveRelationPersonAward(int id);
        [OperationContract]
        SingleItemResponse<RelationPersonAward> UpdateRelationPersonAward(RelationPersonAward updateData);
        [OperationContract]
        SingleItemResponse<RelationPersonAward> GetRelationPersonAward(int id);
        //List<RelationPersonAward> GetRelationPersonAwardPaged(int pageNr, int pageAmount);
        //List<RelationPersonAward> GetAllRelationPersonAward();
        #endregion
        #region RelationPersonPlayJob
        [OperationContract]
        SingleItemResponse<RelationPersonPlayJob> AddRelationPersonPlayJob(RelationPersonPlayJob newRelationPersonPlayJob);
        [OperationContract]
        SingleItemResponse<bool> RemoveRelationPersonPlayJob(int id);
        [OperationContract]
        SingleItemResponse<RelationPersonPlayJob> UpdateRelationPersonPlayJob(RelationPersonPlayJob updateData);
        [OperationContract]
        SingleItemResponse<RelationPersonPlayJob> GetRelationPersonPlayJob(int id);
        //List<RelationPersonPlayJob> GetRelationPersonPlayJobPaged(int pageNr, int pageAmount);
        //List<RelationPersonPlayJob> GetAllRelationPersonPlayJob();
        #endregion
        #region RelationPersonPlayRole
        [OperationContract]
        SingleItemResponse<RelationPersonPlayRole> AddRelationPersonPlayRole(RelationPersonPlayRole newRelationPersonPlayRole);
        [OperationContract]
        SingleItemResponse<bool> RemoveRelationPersonPlayRole(int id);
        [OperationContract]
        SingleItemResponse<RelationPersonPlayRole> UpdateRelationPersonPlayRole(RelationPersonPlayRole updateData);
        [OperationContract]
        SingleItemResponse<RelationPersonPlayRole> GetRelationPersonPlayRole(int id);
        //List<RelationPersonPlayRole> GetRelationPersonPlayRolePaged(int pageNr, int pageAmount);
        //List<RelationPersonPlayRole> GetAllRelationPersonPlayRole();
        #endregion
        #region User
        //User AddUser(User newUser);
        //bool RemoveUser(int id);
        //UpdateUser(User updateData);
        [OperationContract]
        SingleItemResponse<User> GetUser(int id);
        //List<User> GetUserPaged(int pageNr, int pageAmount);
        [OperationContract]
        ListResponse<User> GetAllUsers();
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
