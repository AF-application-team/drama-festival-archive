using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class Award
    {
        public int AwardId { get; set; }
        public int CategoryId { get; set; }
        public int FestivalId { get; set; }
        public int PlayId { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }
    }
}
