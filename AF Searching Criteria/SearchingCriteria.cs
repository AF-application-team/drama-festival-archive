using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Searching_Criteria
{
    public class PeopleSearchingCriteria
    {
        public int? JobId { get; set; }
        public int? PositionId { get; set; }
        public int? CategoryId { get; set; }
        public int? Year { get; set; }
        public char? Profile { get; set; }
    }

    public class PlaysSearchingCriteria
    {
        public int? CategoryId { get; set; }
        public int? FestivalId { get; set; }
    }

    public class AwardsSearchingCriteria
    {
        public int? CategoryId { get; set; }
        public int? FestivalId { get; set; }
    }
}
