using System;
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
        public virtual User Editor { get; set; }

        public Play() { }

        public Play(Play play)
        {
            PlayId = play.PlayId;
            Title = play.Title;
            Author = play.Author;
            FestivalId = play.FestivalId;
            Day = play.Day;
            Order = play.Order;
            Motto = play.Motto;
            PlayedBy = play.PlayedBy;
            EditedBy = play.EditedBy;
            EditDate = play.EditDate;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            
            var p = obj as Play;
            if ((System.Object)p == null)
            {
                return false;
            }

            return (PlayId == p.PlayId) && (Title == p.Title) && (Author == p.Author) && (FestivalId == p.FestivalId) &&
                   (Day == p.Day) && (Order == p.Order) && (Motto == p.Motto) && (PlayedBy == p.PlayedBy);
        }
    }
}
