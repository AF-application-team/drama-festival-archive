using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AF.Common.DTO;
using AF_Desktop_Application_WCF.AFServiceReference;

namespace AF_Desktop_Application_WCF.View_Models
{
    public class PlayEditViewModel
    {
        static AFServiceClient _client = new AFServiceClient();
        private PlayDataDTO originalPlay = null;
        public List<int> Ints = new List<int>() {1, 2, 3, 4, 5, 6};
        public PlayDataDTO EditedPlay { get; set; }
        public List<int> FestivalsList { get; set; }

        public PlayEditViewModel(List<int> fesitvalsList)
        {
            FestivalsList = fesitvalsList;
            EditedPlay = new PlayDataDTO();
        }

        public async void Initialize(int id)
        {
            originalPlay = (await _client.GetPlayAsync(id)).Data;
            EditedPlay = new PlayDataDTO(originalPlay);
        }

        public async Task<bool> SavePlay()
        {
            if (originalPlay == null)
            {
                await _client.AddPlayAsync(EditedPlay);
                return true;
            }
            else if (!EditedPlay.Equals(originalPlay))
            {
                await _client.UpdatePlayAsync(EditedPlay);
                return true;
            }
            return false;
        }
    }
}
