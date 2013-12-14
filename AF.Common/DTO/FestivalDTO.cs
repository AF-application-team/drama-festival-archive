using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Common.DTO
{
    public class FestivalDTO
    {
        public int FestivalId { get; set; }
        public int Year { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }
    }
}
