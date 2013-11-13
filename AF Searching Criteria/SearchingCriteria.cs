using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AF_Searching_Criteria
{
    public class PeopleSearchingCriteria
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; } 
        public int? JobIdFilter { get; set; }
        public int? PositionIdFilter { get; set; }
        public int? CategoryIdFilter { get; set; }
        public int? YearFilter { get; set; }
        public char? ProfileFilter { get; set; }
    }

    public class PlaysSearchingCriteria
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Motto { get; set; }
        public int? CategoryIdFilter { get; set; }
        public int? FestivalIdFilter { get; set; }

        public override string ToString()
        {
            return "PlaysSearchingCryteria \n" +
                   "[Title=" + Title + "] \n" +
                   "[Author=" + Author + "] \n" +
                   "[Motto=" + Motto +"] \n" +
                   "[CategoryIdFilter=" + CategoryIdFilter + "] \n" +
                   "[FestivalIdFilter=" + FestivalIdFilter + "]";
        }
    }

    public class AwardsSearchingCriteria
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int? CategoryIdFilter { get; set; }
        public int? FestivalIdFilter { get; set; }

        public override string ToString()
        {
            return "PlaysSearchingCryteria \n" +
                   "[Title=" + Title + "] \n" +
                   "[Author=" + Author + "] \n" +
                   "[CategoryIdFilter=" + CategoryIdFilter + "] \n" +
                   "[FestivalIdFilter=" + FestivalIdFilter + "]";
        }
    }
}
