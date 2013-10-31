using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class Person 
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Sex { get; set; }
        public int Year { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }
        public string Profile { get; set; } 
    }
}
