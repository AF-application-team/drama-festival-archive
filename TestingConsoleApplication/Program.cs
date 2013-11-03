using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AF_DataAccessLayer;
using AF_Models;
using System.Data.Entity;

namespace TestingConsoleApplication
{
    class Program
    {

        static void Main(string[] args)
        {
            IAF_DataAccess DAL = new AF_DataAccess();
          
           // Category b = DAL.AddCategory(a);
           // Console.WriteLine("Category Title:");
           // Console.WriteLine(a.Title);

            var cat = new Category { CategoryId = 40, Title = "cat1", Group = 2, Order = 1, EditedBy = 0, EditDate = new DateTime(2011, 6, 10) };
         //   DAL.AddCategory(cat);
            Category a = DAL.GetCategory(5);
            Console.WriteLine(a.Title);
        }
    }
}
