using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AF_Models;

namespace AF.Common.DTO
{
    public class PlayCastDTO
    {
        public int PlayId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int FestivalId { get; set; }
        public int Day { get; set; }
        public int Order { get; set; }
        public string PlayedBy { get; set; }
        public string Motto { get; set; }

        public IEnumerable<PersonFunctionDTO> Helpers;
        public IEnumerable<PersonFunctionDTO> Cast;

        public PlayCastDTO()
        {
        }

        public PlayCastDTO(Play play)
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
    }
    
    

}
