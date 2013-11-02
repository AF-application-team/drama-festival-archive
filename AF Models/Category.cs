using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int Group { get; set; }
        public int Order { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }


        public virtual User Edited { get; set; }
    }
}
