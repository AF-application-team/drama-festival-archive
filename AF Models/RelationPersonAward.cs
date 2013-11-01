using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class RelationPersonAward
    {
        public int RelationPersonAwardId { get; set; }
        public int PersonId { get; set; }
        public int AwardId { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }
    }
}
