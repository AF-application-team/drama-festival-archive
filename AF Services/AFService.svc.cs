using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AF.Common.DTO;
using AF.Common.Queries;
using Af.Common.Services;
using AF_Models;

namespace AF_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AFService : IAFService
    {
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
        public Award AddAward(int playId, int festivalId, int categoryId, int userId)
        {
            throw new NotImplementedException();
        }

        public Award UpdateAward(Award updateData)
        {
            throw new NotImplementedException();
        }

        public Award GetAward(int id)
        {
            throw new NotImplementedException();
        }

        public List<AwardMixedDTO> SearchAwards(AwardsSearchingCriteria criteria, int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public Category AddCategory(string title, int @group, int order, int userId)
        {
            throw new NotImplementedException();
        }

        public Category UpdateCategory(Category updateData)
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Festival AddFestival(Festival newFestival)
        {
            throw new NotImplementedException();
        }

        public Festival UpdateFestival(Festival updateData)
        {
            throw new NotImplementedException();
        }

        public Festival GetFestival(int id)
        {
            throw new NotImplementedException();
        }

        public List<Festival> GetFestivalsPaged(int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public int CountFestivals()
        {
            throw new NotImplementedException();
        }

        public Job AddJob(string title, int userId)
        {
            throw new NotImplementedException();
        }

        public Job UpdateJob(Job updateData)
        {
            throw new NotImplementedException();
        }

        public Job GetJob(int id)
        {
            throw new NotImplementedException();
        }

        public List<Job> GetAllJobs()
        {
            throw new NotImplementedException();
        }

        public Play AddPlay(Play newPlay)
        {
            throw new NotImplementedException();
        }

        public Play UpdatePlay(Play updateData)
        {
            throw new NotImplementedException();
        }

        public Play GetPlay(int id)
        {
            throw new NotImplementedException();
        }

        public List<Play> SearchPlays(PlaysSearchingCriteria criteria, int pageNr, int pageAmount)
        {
            throw new NotImplementedException();
        }

        public Position AddPosition(string title, int section, int order, int userId)
        {
            throw new NotImplementedException();
        }

        public Position UpdatePosition(Position updateData)
        {
            throw new NotImplementedException();
        }

        public Position GetPosition(int id)
        {
            throw new NotImplementedException();
        }

        public List<Position> GetAllPositions()
        {
            throw new NotImplementedException();
        }

        public RelationFestivalPersonPosition AddRelationFestivalPersonPosition(
            RelationFestivalPersonPosition newRelationFestivalPersonPosition)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRelationFestivalPersonPosition(int id)
        {
            throw new NotImplementedException();
        }

        public RelationFestivalPersonPosition UpdateRelationFestivalPersonPosition(RelationFestivalPersonPosition updateData)
        {
            throw new NotImplementedException();
        }

        public RelationFestivalPersonPosition GetRelationFestivalPersonPosition(int id)
        {
            throw new NotImplementedException();
        }

        public RelationPersonAward AddRelationPersonAward(RelationPersonAward newRelationPersonAward)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRelationPersonAward(int id)
        {
            throw new NotImplementedException();
        }

        public RelationPersonAward UpdateRelationPersonAward(RelationPersonAward updateData)
        {
            throw new NotImplementedException();
        }

        public RelationPersonAward GetRelationPersonAward(int id)
        {
            throw new NotImplementedException();
        }

        public RelationPersonPlayJob AddRelationPersonPlayJob(RelationPersonPlayJob newRelationPersonPlayJob)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRelationPersonPlayJob(int id)
        {
            throw new NotImplementedException();
        }

        public RelationPersonPlayJob UpdateRelationPersonPlayJob(RelationPersonPlayJob updateData)
        {
            throw new NotImplementedException();
        }

        public RelationPersonPlayJob GetRelationPersonPlayJob(int id)
        {
            throw new NotImplementedException();
        }

        public RelationPersonPlayRole AddRelationPersonPlayRole(RelationPersonPlayRole newRelationPersonPlayRole)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRelationPersonPlayRole(int id)
        {
            throw new NotImplementedException();
        }

        public RelationPersonPlayRole UpdateRelationPersonPlayRole(RelationPersonPlayRole updateData)
        {
            throw new NotImplementedException();
        }

        public RelationPersonPlayRole GetRelationPersonPlayRole(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
