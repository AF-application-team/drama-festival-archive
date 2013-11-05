using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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


        [ForeignKey("FestivalId")]
        public virtual Festival Festival { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }
        [ForeignKey("EditedBy")]
        public virtual User Editor { get; set; }
    }
}
