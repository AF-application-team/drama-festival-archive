using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class RelationFestivalPersonPosition
    {
        public int RelationFestivalPersonPositionId { get; set; }
        public int FestivalId { get; set; }
        public int PersonId { get; set; }
        public int PositionId { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }
    }
}
