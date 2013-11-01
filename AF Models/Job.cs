using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }
    }
}
