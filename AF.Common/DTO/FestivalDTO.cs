using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Common.DTO
{
    public class FestivalDTO
    {
        public int FestivalId { get; set; }
        public int Year { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndDate { get; set; }

        public FestivalDTO() { }
        public FestivalDTO(FestivalDTO festival)
        {
            FestivalId = festival.FestivalId;
            Year = festival.Year;
            BeginningDate = festival.BeginningDate;
            EndDate = festival.EndDate;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var c = obj as FestivalDTO;
            if (c == null)
            {
                return false;
            }
            return (FestivalId == c.FestivalId) && (Year == c.Year) && (BeginningDate == c.BeginningDate) && (EndDate == c.EndDate);
        }
    }
}
