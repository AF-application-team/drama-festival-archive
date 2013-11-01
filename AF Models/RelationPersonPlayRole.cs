using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class RelationPersonPlayRole
    {
        public int RelationPresonPlayRoleId { get; set; }
        public int PersonId { get; set; }
        public int PlayId { get; set; }
        public string Role { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }
    }
}
