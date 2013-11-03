using System;
using AF_Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AF_DataAccessLayer;

namespace AF_Tests
{
    [TestClass]
    public class CategoryUnitTest1
    {
        IAF_DataAccess DAL = new AF_DataAccess();
        
        [TestMethod]
        public void TestMethod1()
        {
          // DAL.AddCategory(new Category());
          //  Category a = DAL.GetCategory(1);
          //  Console.WriteLine(a.Title);

        }
        [TestMethod]
        public void TestCategoryDisplay()
        {
            

        }
    }
}
