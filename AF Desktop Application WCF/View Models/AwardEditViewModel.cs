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
        static AFServiceClient _client = new AFServiceClient("secureBinding");
        private AwardDataDTO originalAward = null;
        public AwardDataDTO EditedAward { get; set; }
        public List<PlayTitleDTO> PlaysList { get; set; }
        public ObservableCollection<CategoryDTO> CategoriesList { get; set; }

        public AwardEditViewModel( ObservableCollection<CategoryDTO> categoriesList)
        {
            CategoriesList = categoriesList;
            EditedAward = new AwardDataDTO();
        }

        public async void Initialize(int id)
        {
            originalAward = (await _client.GetAwardAsync(id)).Data;
            var l = new List<PlayTitleDTO>();
            l.Add((await _client.GetPlayTitleAsync(originalAward.PlayId)).Data);
            PlaysList = l;
            EditedAward = new AwardDataDTO(originalAward);
        }
        public async Task UpdateList(string s)
        {
            PlaysList = (await _client.SearchPlaysTitlesAsync(new PlaysSearchingCriteria(){Title = s},  1, 35)).Data;
        }
        public async Task<bool> SaveAward()
        {
            if (originalAward == null)
            {
                await _client.AddAwardAsync(EditedAward);
                return true;
            }
            else if (!EditedAward.Equals(originalAward))
            {
                await _client.UpdateAwardAsync(EditedAward);
                return true;
            }
            return false;
        }
    }
}
