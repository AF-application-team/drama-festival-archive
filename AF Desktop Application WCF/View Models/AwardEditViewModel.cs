using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AF.Common.DTO;
using AF.Common.Queries;
using AF_Desktop_Application_WCF.AFServiceReference;

namespace AF_Desktop_Application_WCF.View_Models
{
    public class AwardEditViewModel
    {
        //static AFServiceClient _client = new AFServiceClient("secureBinding");
        private AFServiceClient _client = MainViewModel.Client;
        private AwardDataDTO _originalAward = null;
        private AwardMixedDTO _mixedDTO = null;

        public AwardDataDTO OriginalAward
        {
            get { return _originalAward; }
            set
            {
                _originalAward = value; 
                EditedAward = new AwardDataDTO(value);
            }
        }
        public AwardDataDTO EditedAward { get; set; }
        public AwardMixedDTO MixedDTO
        {
            get { return _mixedDTO; }
            set
            {
                _mixedDTO = value;
                
                PlaysList= new List<PlayTitleDTO>{new PlayTitleDTO {PlayId = _originalAward.PlayId, Title = value.PlayTitle}};
            }
        }
        public List<PlayTitleDTO> PlaysList { get; set; }
        public ObservableCollection<CategoryDTO> CategoriesList { get; set; }

        public AwardEditViewModel(ObservableCollection<CategoryDTO> categoriesList)
        {
            CategoriesList = categoriesList;
        }

        public async Task UpdateList(string s)
        {
            PlaysList = (await _client.SearchPlaysTitlesAsync(new PlaysSearchingCriteria(){Title = s},  1, 35)).Data;
        }
        public async Task<bool> SaveAward()
        {
            if (OriginalAward == null)
            {
                await _client.AddAwardAsync(EditedAward);
                return true;
            }
            else if (!EditedAward.Equals(OriginalAward))
            {
                await _client.UpdateAwardAsync(EditedAward);
                return true;
            }
            return false;
        }
    }
}
