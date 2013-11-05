using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class Festival
    {
        public int FestivalId { get; set; }
        public int Year { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }


        [ForeignKey("EditedBy")]
        public virtual User Editor { get; set; }
    }
}
