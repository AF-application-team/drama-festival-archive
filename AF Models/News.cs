using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class News
    {
        public int NewsId { get; set; }
        public string Text { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }
    }
}
