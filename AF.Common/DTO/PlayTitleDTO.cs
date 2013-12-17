using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Common.DTO
{
    public class PlayTitleDTO
    {
        public int PlayId { get; set; }
        public string Title { get; set; }

        public PlayTitleDTO() { }
        public PlayTitleDTO(PlayTitleDTO play)
        {
            PlayId = play.PlayId;
            Title = play.Title;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var c = obj as PlayTitleDTO;
            if (c == null)
            {
                return false;
            }
            return (PlayId == c.PlayId) && (Title == c.Title);
        }
    }
}
