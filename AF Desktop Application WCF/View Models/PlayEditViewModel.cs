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
        //static AFServiceClient _client = new AFServiceClient();
        private AFServiceClient _client = MainViewModel.Client;
        private PlayDataDTO _originalPlay = null;
        public List<int> Ints = new List<int>() {1, 2, 3, 4, 5, 6};

        public PlayDataDTO OriginalPlay
        {
            get { return _originalPlay; }
            set
            {
                _originalPlay = value;
                EditedPlay = new PlayDataDTO(value);
            }
        }
        public PlayDataDTO EditedPlay { get; set; }
        public List<int> FestivalsList { get; set; }

        public PlayEditViewModel(List<int> fesitvalsList)
        {
            FestivalsList = fesitvalsList;
            EditedPlay = new PlayDataDTO();
        }

        public async Task<bool> SavePlay()
        {
            if (OriginalPlay == null)
            {
                await _client.AddPlayAsync(EditedPlay);
                return true;
            }
            else if (!EditedPlay.Equals(OriginalPlay))
            {
                await _client.UpdatePlayAsync(EditedPlay);
                return true;
            }
            return false;
        }
    }
}
