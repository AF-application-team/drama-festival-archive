using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Common.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int Group { get; set; }
        public int Order { get; set; }
    }
}
