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
        SingleItemResponse<AwardDataDTO> AddAward(AwardDataDTO newAward);
        //Void RemoveAward(int id);
        [OperationContract]
        SingleItemResponse<AwardDataDTO> UpdateAward(AwardDataDTO updateData);
        [OperationContract]
        SingleItemResponse<AwardDataDTO> GetAward(int id);
        //List<AwardDTO> GetAwardsPaged(int pageNr, int pageAmount);
        [OperationContract]
        ListResponse<AwardMixedDTO> SearchAwards(AwardsSearchingCriteria criteria, int pageNr, int pageAmount);
        //<List<Award> GetAllAwards();
        #endregion
        #region Category
        [OperationContract]
        SingleItemResponse<CategoryDTO> AddCategory(CategoryDTO newCategory);
        //RemoveCategory(int id);
        [OperationContract]
        SingleItemResponse<CategoryDTO> UpdateCategory(CategoryDTO updateData);
        [OperationContract]
        SingleItemResponse<CategoryDTO> GetCategory(int id);
        //List<Category> GetCategoriesPaged(int pageNr, int pageAmount);
        [OperationContract]
        ListResponse<CategoryDTO> GetAllCategories();
        #endregion
        #region Festival
        [OperationContract]
        SingleItemResponse<FestivalDTO> AddFestival(FestivalDTO newFestival);
        //RemoveFestival(int id);
        [OperationContract]
        SingleItemResponse<FestivalDTO> UpdateFestival(FestivalDTO updateData);
        [OperationContract]
        SingleItemResponse<FestivalDTO> GetFestival(int id);
        [OperationContract]
        ListResponse<FestivalDTO> GetFestivalsPaged(int pageNr, int pageAmount);
        //List<Festival> GetAllFestivals();
        [OperationContract]
        SingleItemResponse<int> CountFestivals();
        #endregion
        #region Job
        [OperationContract]
        SingleItemResponse<JobDTO> AddJob(JobDTO newJob);
        //RemoveJob(int id);
        [OperationContract]
        SingleItemResponse<JobDTO> UpdateJob(JobDTO updateData);
        [OperationContract]
        SingleItemResponse<JobDTO> GetJob(int id);
        //List<Job> GetJobsPaged(int pageNr, int pageAmount);
        [OperationContract]
        ListResponse<JobDTO> GetAllJobs();
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
        SingleItemResponse<PlayDataDTO> AddPlay(PlayDataDTO newPlay);
        //RemovePlay(int id);
        [OperationContract]
        SingleItemResponse<PlayDataDTO> UpdatePlay(PlayDataDTO updateData);
        [OperationContract]
        SingleItemResponse<PlayDataDTO> GetPlay(int id);
        //List<PlayDTO> GetPlaysPaged(int pageNr, int pageAmount);
        //List<Play> GetAllPlays();
        [OperationContract]
        ListResponse<PlayDataDTO> SearchPlays(PlaysSearchingCriteria criteria, int pageNr, int pageAmount);
        #endregion
        #region Position
        [OperationContract]
        SingleItemResponse<PositionDTO> AddPosition(PositionDTO newPosition);
        //RemovePosition(int id);
        [OperationContract]
        SingleItemResponse<PositionDTO> UpdatePosition(PositionDTO updateData);
        [OperationContract]
        SingleItemResponse<PositionDTO> GetPosition(int id);
        //List<Position> GetPositionsPaged(int pageNr, int pageAmount);
        [OperationContract]
        ListResponse<PositionDTO> GetAllPositions();
        #endregion
        #region RelationFestivalPersonPosition
        [OperationContract]
        SingleItemResponse<RelationFestivalPersonPositionDTO> AddRelationFestivalPersonPosition(RelationFestivalPersonPositionDTO newRelationFestivalPersonPosition);
        [OperationContract]
        SingleItemResponse<bool> RemoveRelationFestivalPersonPosition(int id);
        [OperationContract]
        SingleItemResponse<RelationFestivalPersonPositionDTO> UpdateRelationFestivalPersonPosition(RelationFestivalPersonPositionDTO updateData);
        [OperationContract]
        SingleItemResponse<RelationFestivalPersonPositionDTO> GetRelationFestivalPersonPosition(int id);
        //List<RelationFestivalPersonPosition> GetRelationFestivalPersonPositionPaged(int pageNr, int pageAmount);
        //List<RelationFestivalPersonPosition> GetAllRelationFestivalPersonPosition();
        #endregion
        #region RelationPersonAward
        [OperationContract]
        SingleItemResponse<RelationPersonAwardDTO> AddRelationPersonAward(RelationPersonAwardDTO newRelationPersonAward);
        [OperationContract]
        SingleItemResponse<bool> RemoveRelationPersonAward(int id);
        [OperationContract]
        SingleItemResponse<RelationPersonAwardDTO> UpdateRelationPersonAward(RelationPersonAwardDTO updateData);
        [OperationContract]
        SingleItemResponse<RelationPersonAwardDTO> GetRelationPersonAward(int id);
        //List<RelationPersonAward> GetRelationPersonAwardPaged(int pageNr, int pageAmount);
        //List<RelationPersonAward> GetAllRelationPersonAward();
        #endregion
        #region RelationPersonPlayJob
        [OperationContract]
        SingleItemResponse<RelationPersonPlayJobDTO> AddRelationPersonPlayJob(RelationPersonPlayJobDTO newRelationPersonPlayJob);
        [OperationContract]
        SingleItemResponse<bool> RemoveRelationPersonPlayJob(int id);
        [OperationContract]
        SingleItemResponse<RelationPersonPlayJobDTO> UpdateRelationPersonPlayJob(RelationPersonPlayJobDTO updateData);
        [OperationContract]
        SingleItemResponse<RelationPersonPlayJobDTO> GetRelationPersonPlayJob(int id);
        //List<RelationPersonPlayJob> GetRelationPersonPlayJobPaged(int pageNr, int pageAmount);
        //List<RelationPersonPlayJob> GetAllRelationPersonPlayJob();
        #endregion
        #region RelationPersonPlayRole
        [OperationContract]
        SingleItemResponse<RelationPersonPlayRoleDTO> AddRelationPersonPlayRole(RelationPersonPlayRoleDTO newRelationPersonPlayRole);
        [OperationContract]
        SingleItemResponse<bool> RemoveRelationPersonPlayRole(int id);
        [OperationContract]
        SingleItemResponse<RelationPersonPlayRoleDTO> UpdateRelationPersonPlayRole(RelationPersonPlayRoleDTO updateData);
        [OperationContract]
        SingleItemResponse<RelationPersonPlayRoleDTO> GetRelationPersonPlayRole(int id);
        //List<RelationPersonPlayRole> GetRelationPersonPlayRolePaged(int pageNr, int pageAmount);
        //List<RelationPersonPlayRole> GetAllRelationPersonPlayRole();
        #endregion
        #region User
        //User AddUser(User newUser);
        //bool RemoveUser(int id);
        //UpdateUser(User updateData);
        [OperationContract]
        SingleItemResponse<UserDTO> GetUser(int id);
        //List<User> GetUserPaged(int pageNr, int pageAmount);
        [OperationContract]
        ListResponse<UserDTO> GetAllUsers();
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
