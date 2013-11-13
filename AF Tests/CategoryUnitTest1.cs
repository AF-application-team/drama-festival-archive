using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using AF_BusinessLogic;
using AF_Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AF_DataAccessLayer;


namespace AF_Tests
{
    [TestClass]
    public class CategoryUnitTest1
    {
        IAF_DataAccess DAL = new AF_DataAccess();
        IAF_LogicService BLS = new AF_Logic();
        private AF_Context _context;
        
        [TestInitialize]
        public void Initialize()
        {
          //  Database.SetInitializer(new DropCreateDatabaseAlways<AF_Context>());
         //  _context = new AF_Context();
        }

        [TestCleanup]
        public void Cleanup()
        {
           // _context.Dispose();
        }

        #region Category
        [TestMethod]
        public async Task GetCategory_Should_ReturnCategory()
        {
            Category cat1 = await DAL.GetCategory(1);
            
            Assert.IsNotNull(cat1);
            Assert.AreEqual("GRAND PRIX", cat1.Title);
        }

        [TestMethod]
        public async Task GetAllCategories_Should_ReturnCategories()
        {
            List<Category> categories1 = await DAL.GetAllCategories();
            List<Category> categories2 = await BLS.GetAllCategories();
            Assert.AreEqual(39, categories1.Count);
            Assert.AreEqual("GRAND PRIX", categories1.First().Title);
        }

        [TestMethod]
        public async Task AddCategory_Should_ReturnSameCategory()
        {
            var cat1 = new Category {Title = "cat1", Group = 2, Order = 1, EditedBy = 1, EditDate = new DateTime(2011, 6, 10)};
            await DAL.AddCategory(cat1);
            var cat2 = new Category { CategoryId = 49, Title = "cat2", Group = 2, Order = 1, EditedBy = 1, EditDate = new DateTime(2011, 6, 10) };
            await DAL.AddCategory(cat2);

            Category category1 = await DAL.GetCategory(40); 
            Category category2 = await DAL.GetCategory(41);

            Assert.AreEqual(category1, cat1);
            Assert.AreEqual(category2, cat2);
        }

        [TestMethod]
        public async Task RemoveCategory_Should_ReturnNull()
        {
            await DAL.RemoveCategory(40);
            await DAL.RemoveCategory(41);
        } 

        [TestMethod]
        public async Task UpdateCategory_Should_ReturnDifferentCategory()
        {
            Category cat1 = await DAL.GetCategory(5);
            Category cat2 = new Category(cat1);
            cat1.Title = "NewTitle";
            await DAL.UpdateCategory(cat1);
            Category cat3 = await DAL.GetCategory(cat1.CategoryId);
            Assert.IsFalse(cat3.Equals(cat2));
        }
        #endregion
        
        #region relation
        /*
        [TestMethod]
        public async Task GetRelationPersonPlayJobId_Should_ReturnRelation()
        {
            RelationPersonAward r = await DAL.GetRelationPersonAward(42);

            Assert.IsNotNull(r);
            Assert.AreEqual(214, r.PersonId);
        }

        [TestMethod]
        public async Task AddRelationPersonPlayJob_Should_ReturnSameAddRelationPersonPlayJob()
        {
            var rel = new RelationPersonPlayJob(){ PersonId = 155, PlayId = 13, JobId = 1, EditedBy = 2, EditDate = new DateTime(2011, 6, 10) };
            await DAL.AddRelationPersonPlayJob(rel);

            RelationPersonPlayJob relation = await DAL.GetRelationPersonPlayJob(125);

            Assert.IsNotNull(relation);
            Assert.AreEqual(relation, rel);
        }

        [TestMethod]
        public async Task RemoveRelationPersonPlayJob_Should_ReturnNull()
        {
            await DAL.RemoveCategory(2);
        }
        
        [TestMethod]
        public async Task UpdateRelationPersonPlayJob_Should_ReturnDifferentRelationPersonPlayJob()
        {
            RelationPersonPlayJob rel1 = await DAL.GetRelationPersonPlayJob(8);
            RelationPersonPlayJob rel2 = new RelationPersonPlayJob(rel1);
            rel1.PlayId = 5;
            await DAL.UpdateRelationPersonPlayJob(rel1);
            //poprawic jesce rAZ pobrac z bazy sprawdzic assert
            Assert.AreNotEqual(rel1.PlayId, rel2.PlayId);
        }

        [TestMethod]
        public async Task GetRelationPersonPlayJob_Should_ReturnRelationsPersonPlayJob()
        {
            List<RelationPersonPlayJob> relation = await DAL.GetAllRelationPersonPlayJob();
            Assert.AreEqual(83, relation.Count);
            Assert.AreEqual("97", relation.First().PersonId);
        } 
        */
        #endregion
        
    }
}
