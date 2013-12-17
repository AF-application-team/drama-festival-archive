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

        public PositionDTO() { }
        public PositionDTO(PositionDTO position)
        {
            PositionId = position.PositionId;
            PositionTitle = position.PositionTitle;
            Section = position.Section;
            Order = position.Order;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var c = obj as PositionDTO;
            if (c == null)
            {
                return false;
            }
            return (PositionId == c.PositionId) && (PositionTitle == c.PositionTitle) && (Section == c.Section) &&
                   (Order == c.Order);
        }
    }
}
