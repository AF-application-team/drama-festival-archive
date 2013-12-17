using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Common.DTO
{
    public class AwardMixedDTO
    {
        public int AwardId { get; set; }
        public string CategoryTitle { get; set; }
        public int FestivalId { get; set; }
        public string PlayTitle { get; set; }

        public AwardMixedDTO() { }

        public AwardMixedDTO(AwardMixedDTO award)
        {
            AwardId = award.AwardId;
            CategoryTitle = award.CategoryTitle;
            FestivalId = award.FestivalId;
            PlayTitle = award.PlayTitle;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var a = obj as AwardMixedDTO;
            if (a == null)
            {
                return false;
            }

            return (AwardId == a.AwardId) && (CategoryTitle == a.CategoryTitle) && (FestivalId == a.FestivalId) && (PlayTitle == a.PlayTitle);
        }    
    }
}
