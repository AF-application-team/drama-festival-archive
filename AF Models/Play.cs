﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class Play
    {
        public int PlayId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int FestivalId { get; set; }
        public int Day { get; set; }
        public int Order { get; set; }
        public string PlayedBy { get; set; }
        public string Motto { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }


        [ForeignKey("FestivalId")]
        public virtual Festival Festival { get; set; }
        [ForeignKey("EditedBy")]
        public virtual User Edited { get; set; }
    }
}
