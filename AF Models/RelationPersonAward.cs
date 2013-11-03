using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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


        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        [ForeignKey("AwardId")]
        public virtual Award Award { get; set; }
        [ForeignKey("EditedBy")]
        public virtual User Edited { get; set; }
    }
}
