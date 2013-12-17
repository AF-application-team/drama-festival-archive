using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Common.DTO
{
    public class PlayDataDTO
    {
        public int PlayId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int FestivalId { get; set; }
        public int Day { get; set; }
        public int Order { get; set; }
        public string PlayedBy { get; set; }
        public string Motto { get; set; }

        public PlayDataDTO() { }
        public PlayDataDTO(PlayDataDTO play)
        {
            PlayId = play.PlayId;
            Title = play.Title;
            Author = play.Author;
            FestivalId = play.FestivalId;
            Day = play.Day;
            Order = play.Order;
            PlayedBy = play.PlayedBy;
            Motto = play.Motto;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var c = obj as PlayDataDTO;
            if (c == null)
            {
                return false;
            }
            return (PlayId == c.PlayId) && (Title == c.Title) && (Author == c.Author) && (FestivalId == c.FestivalId) && (Day == c.Day) && (Order == c.Order) && (PlayedBy == c.PlayedBy) && (Motto == c.Motto);
        }
    }
}
