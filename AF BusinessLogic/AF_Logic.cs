﻿using AF_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AF_Models;

namespace AF_BusinessLogic
{
    class AF_Logic : IAF_LogicService
    {
        IAF_DataAccess DataAccess = new AF_DataAccess();

        public List<Category> GetCategories()
        {
            return DataAccess.GetAllCategories();
        }
    }
}
