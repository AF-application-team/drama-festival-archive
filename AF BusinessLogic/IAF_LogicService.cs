using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AF_Models;

namespace AF_BusinessLogic
{
    public interface IAF_LogicService
    {
        List<Category> GetAllCategories();
    }
}
