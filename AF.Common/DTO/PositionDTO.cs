using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Common.DTO
{
    public class PositionDTO
    {
        public int PositionId { get; set; }
        public string PositionTitle { get; set; }
        public int Section { get; set; }
        public int Order { get; set; }
    }
}
