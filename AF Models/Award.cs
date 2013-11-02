using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AF_Models
{
    public class Award
    {
        public int AwardId { get; set; }
        public int CategoryId { get; set; } //check if its better to store just id / but then double querrying?
        public int FestivalId { get; set; }
        public int PlayId { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }


        public virtual Category Category { get; set; }
        public virtual Festival Festival { get; set; }
        public virtual Play Play { get; set; }
        public virtual User Edited { get; set; }
    }
}
