using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AF.Common.DTO;
using AF.Common.Queries;
using AF.Common.Requests;
using AF.Common.Services;
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
        public SingleItemResponse<Award> AddAward(int playId, int festivalId, int categoryId, int userId)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Award> UpdateAward(Award updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Award> GetAward(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<AwardMixedDTO> SearchAwards(AwardsSearchingCriteria criteria, int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Category> AddCategory(string title, int @group, int order, int userId)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Category> UpdateCategory(Category updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Category> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Festival> AddFestival(Festival newFestival)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Festival> UpdateFestival(Festival updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Festival> GetFestival(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<Festival> GetFestivalsPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<int> CountFestivals()
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Job> AddJob(string title, int userId)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Job> UpdateJob(Job updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Job> GetJob(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<Job> GetAllJobs()
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Play> AddPlay(Play newPlay)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Play> UpdatePlay(Play updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Play> GetPlay(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<Play> SearchPlays(PlaysSearchingCriteria criteria, int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Position> AddPosition(string title, int section, int order, int userId)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Position> UpdatePosition(Position updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<Position> GetPosition(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<Position> GetAllPositions()
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationFestivalPersonPosition> AddRelationFestivalPersonPosition(
            RelationFestivalPersonPosition newRelationFestivalPersonPosition)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<bool> RemoveRelationFestivalPersonPosition(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationFestivalPersonPosition> UpdateRelationFestivalPersonPosition(RelationFestivalPersonPosition updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationFestivalPersonPosition> GetRelationFestivalPersonPosition(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonAward> AddRelationPersonAward(RelationPersonAward newRelationPersonAward)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<bool> RemoveRelationPersonAward(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonAward> UpdateRelationPersonAward(RelationPersonAward updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonAward> GetRelationPersonAward(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayJob> AddRelationPersonPlayJob(RelationPersonPlayJob newRelationPersonPlayJob)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<bool> RemoveRelationPersonPlayJob(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayJob> UpdateRelationPersonPlayJob(RelationPersonPlayJob updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayJob> GetRelationPersonPlayJob(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayRole> AddRelationPersonPlayRole(RelationPersonPlayRole newRelationPersonPlayRole)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<bool> RemoveRelationPersonPlayRole(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayRole> UpdateRelationPersonPlayRole(RelationPersonPlayRole updateData)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<RelationPersonPlayRole> GetRelationPersonPlayRole(int id)
        {
            throw new NotImplementedException();
        }

        public SingleItemResponse<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
