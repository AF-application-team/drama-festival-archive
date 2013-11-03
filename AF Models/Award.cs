using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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


        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("FestivalId")]
        public virtual Festival Festival { get; set; }
        [ForeignKey("PlayId")]
        public virtual Play Play { get; set; }
        [ForeignKey("EditedBy")]
        public virtual User Edited { get; set; }
    }
}
