using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AF_BusinessLogic;
using AF_Models;
using AF.Common.Queries;

namespace AF_Desktop_Application.View_Models
{
    public class AwardEditViewModel
    {
        private AF_Logic DB = new AF_Logic();
        private Award originalAward=null;
        public Award EditedAward { get; set; }
        public List<Play> PlaysList { get; set; }
        public List<int> FestivalsList { get; set; }
        public ObservableCollection<Category> CategoriesList { get; set; }

        public AwardEditViewModel(List<int> festivalsList, ObservableCollection<Category> categoriesList)
        {
            FestivalsList = festivalsList;
            CategoriesList = categoriesList;
            EditedAward = new Award();
        }

        public AwardEditViewModel(Award editedAward,List<int> festivalsList, ObservableCollection<Category> categoriesList)
        {
            FestivalsList = festivalsList;
            CategoriesList = categoriesList;
            originalAward = editedAward;
            var l = new List<Play>();
            l.Add(editedAward.Play);
            PlaysList = l;
            EditedAward = new Award(editedAward);
        }
        public async Task UpdateList(string s)
        {
            PlaysList = await DB.SearchPlays(new PlaysSearchingCriteria(){Title = s},  1, 35);
        }
        public async Task<bool> SaveAward()
        {
            if (originalAward == null)
            {
                await DB.AddAward(EditedAward.PlayId, EditedAward.FestivalId, EditedAward.CategoryId,
                    MainViewModel.LoggedUser.UserId);
                return true;
            }
            else if (!EditedAward.Equals(originalAward))
            {
                EditedAward.EditedBy = MainViewModel.LoggedUser.UserId; 
                await DB.UpdateAward(EditedAward);
                return true;
            }
            return false;
        }
    }
}
