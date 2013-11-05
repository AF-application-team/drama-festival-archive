using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class RelationPersonPlayJob
    {
        public int RelationPersonPlayJobId { get; set; }
        public int PersonId { get; set; }
        public int PlayId { get; set; }
        public int JobId { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }


        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        [ForeignKey("PlayId")]
        public virtual Play Play { get; set; }
        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
        [ForeignKey("EditedBy")]
        public virtual User Editor { get; set; }
    }
}
