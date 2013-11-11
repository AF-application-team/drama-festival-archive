using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string PositionTitle { get; set; }
        public int Section { get; set; }
        public int Order { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }


        [ForeignKey("EditedBy")]
        public virtual User Editor { get; set; }

        public Position() { }
        public Position(Position position)
        {
            PositionId = position.PositionId;
            PositionTitle = position.PositionTitle;
            Section = position.Section;
            Order = position.Order;
            EditDate = position.EditDate;
            EditedBy = position.EditedBy;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var p = obj as Position;
            if ((System.Object)p == null)
            {
                return false;
            }

            return (PositionId == p.PositionId) && (PositionTitle == p.PositionTitle) && (Section == p.Section) && (Order == p.Order);
        }
    }
}
