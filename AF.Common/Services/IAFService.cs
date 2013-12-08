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
        Award AddAward(UpdateRequest<AwardDataDTO> request);
        //Void RemoveAward(int id);
        Award UpdateAward(UpdateRequest<AwardDataDTO> updateData);
        Award GetAward(SingleRequest request);
        //List<AwardDTO> GetAwardsPaged(int pageNr, int pageAmount);
        List<AwardMixedDTO> SearchAwards(QueryRequest<AwardsSearchingCriteria> request);
        //<List<Award> GetAllAwards();
        #endregion
        #region Category
        Category AddCategory(UpdateRequest<CategoryDTO> request);
        //RemoveCategory(int id);
        Category UpdateCategory(UpdateRequest<CategoryDTO> request);
        Category GetCategory(SingleRequest request);
        //List<Category> GetCategoriesPaged(int pageNr, int pageAmount);
        List<CategoryDTO> GetAllCategories(EmptyRequest request);
        #endregion
        #region Festival
        Festival AddFestival(UpdateRequest<FestivalDTO> request);
        //RemoveFestival(int id);
        Festival UpdateFestival(UpdateRequest<FestivalDTO> request);
        Festival GetFestival(SingleRequest request);
        //List<Festival> GetFestivalsPaged(QueryRequest<FestivalDTO> request);
        //List<Festival> GetAllFestivals();
        int CountFestivals();
        #endregion
        #region Job
        Job AddJob(UpdateRequest<JobDTO> request );
        //RemoveJob(int id);
        Job UpdateJob(UpdateRequest<JobDTO> request);
        Job GetJob(SingleRequest request);
        //List<Job> GetJobsPaged(int pageNr, int pageAmount);
        List<JobDTO> GetAllJobs(EmptyRequest request);
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
        //PersonDTO AddPerson(UpdateRequest<PersonDataDTO> request);
        //RemovePerson(SingleRequest request);
        //Person UpdatePerson(UpdateRequest<PersonDataDTO> request);
        //Person GetPerson(SingleRequest request);
        
        //List<PersonDTO> GetPeoplePaged(int pageNr, int pageAmount);
        //List<Person> GetAllPeople();
        #endregion
        #region Play
        Play AddPlay(UpdateRequest<PlayDataDTO> request);
        //RemovePlay(int id);
        Play UpdatePlay(UpdateRequest<PlayDataDTO> request);
        Play GetPlay(SingleRequest request);
        //List<PlayDTO> GetPlaysPaged(int pageNr, int pageAmount);
        //List<Play> GetAllPlays();
        List<PlayDataDTO> SearchPlays(QueryRequest<PlaysSearchingCriteria> request);
        #endregion
        #region Position
        Position AddPosition(UpdateRequest<PositionDTO> request);
        //RemovePosition(int id);
        Position UpdatePosition(UpdateRequest<PositionDTO> request);
        Position GetPosition(SingleRequest request);
        //List<Position> GetPositionsPaged(int pageNr, int pageAmount);
        List<PositionDTO> GetAllPositions(EmptyRequest request);
        #endregion
        #region RelationFestivalPersonPosition
        RelationFestivalPersonPositionDTO AddRelationFestivalPersonPosition(UpdateRequest<RelationFestivalPersonPositionDTO> request);
        bool RemoveRelationFestivalPersonPosition(SingleRequest request);
        RelationFestivalPersonPositionDTO UpdateRelationFestivalPersonPosition(UpdateRequest<RelationFestivalPersonPositionDTO> request);
        RelationFestivalPersonPosition GetRelationFestivalPersonPosition(SingleRequest request);
        //List<RelationFestivalPersonPosition> GetRelationFestivalPersonPositionPaged(QueryRequest<> );
        //List<RelationFestivalPersonPosition> GetAllRelationFestivalPersonPosition();
        #endregion
        #region RelationPersonAward
        RelationPersonAwardDTO AddRelationPersonAward(UpdateRequest<RelationPersonAwardDTO> request);
        bool RemoveRelationPersonAward(SingleRequest request);
        RelationPersonAwardDTO UpdateRelationPersonAward(UpdateRequest<RelationPersonAwardDTO> request);
        RelationPersonAward GetRelationPersonAward(SingleRequest request);
        //List<RelationPersonAward> GetRelationPersonAwardPaged(int pageNr, int pageAmount);
        //List<RelationPersonAward> GetAllRelationPersonAward();
        #endregion
        #region RelationPersonPlayJob
        RelationPersonPlayJobDTO AddRelationPersonPlayJob(UpdateRequest<RelationPersonPlayJobDTO> request);
        bool RemoveRelationPersonPlayJob(SingleRequest request);
        RelationPersonPlayJobDTO UpdateRelationPersonPlayJob(UpdateRequest<RelationPersonPlayJobDTO> request);
        RelationPersonPlayJob GetRelationPersonPlayJob(SingleRequest request);
        //List<RelationPersonPlayJob> GetRelationPersonPlayJobPaged(int pageNr, int pageAmount);
        //List<RelationPersonPlayJob> GetAllRelationPersonPlayJob();
        #endregion
        #region RelationPersonPlayRole
        RelationPersonPlayRoleDTO AddRelationPersonPlayRole(UpdateRequest<RelationPersonPlayRoleDTO> request);
        bool RemoveRelationPersonPlayRole(SingleRequest request);
        RelationPersonPlayRoleDTO UpdateRelationPersonPlayRole(UpdateRequest<RelationPersonPlayRoleDTO> request);
        RelationPersonPlayRole GetRelationPersonPlayRole(SingleRequest request);
        //List<RelationPersonPlayRole> GetRelationPersonPlayRolePaged(int pageNr, int pageAmount);
        //List<RelationPersonPlayRole> GetAllRelationPersonPlayRole();
        #endregion
        #region User
        UserDTO AddUser(UpdateRequest<UserDTO> request);
        bool RemoveUser(SingleRequest request);
        UserDTO UpdateUser(UpdateRequest<UserDTO> request);
        User GetUser(SingleRequest request);
        //List<User> GetUserPaged(int pageNr, int pageAmount);
        List<UserDTO> GetAllUsers(EmptyRequest request);
        #endregion


        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
