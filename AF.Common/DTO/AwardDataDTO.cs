using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Common.DTO
{
    public class AwardDataDTO
    {
        public int AwardId { get; set; }
        public int CategoryId { get; set; }
        public int PlayId { get; set; }

        public AwardDataDTO() {}

        public AwardDataDTO(AwardDataDTO award)
        {
            AwardId = award.AwardId;
            CategoryId = award.CategoryId;
            PlayId = award.PlayId;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var a = obj as AwardDataDTO;
            if (a == null)
            {
                return false;
            }

            return (AwardId == a.AwardId) && (PlayId == a.PlayId) && (CategoryId == a.CategoryId);
        }    
    }
}
