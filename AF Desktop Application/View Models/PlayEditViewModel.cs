using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AF_BusinessLogic;
using AF_Models;

namespace AF_Desktop_Application.View_Models
{
    public class PlayEditViewModel
    {
        private AF_Logic DB = new AF_Logic();
        private Play originalPlay = null;
        public List<int> Ints = new List<int>() {1, 2, 3, 4, 5, 6};
        public Play EditedPlay { get; set; }
        public List<int> FestivalsList { get; set; }

        public PlayEditViewModel(List<int> fesitvalsList)
        {
            FestivalsList = fesitvalsList;
            EditedPlay = new Play();
        }

        public PlayEditViewModel(Play editedPlay, List<int> fesitvalsList)
        {
            FestivalsList = fesitvalsList;
            originalPlay = editedPlay;
            EditedPlay = new Play(editedPlay);
        }

        public async Task<bool> SavePlay()
        {
            if (originalPlay == null)
            {
                EditedPlay.EditedBy = MainViewModel.LoggedUser.UserId;
                await DB.AddPlay(EditedPlay);
                return true;
            }
            else if (!EditedPlay.Equals(originalPlay))
            {
                EditedPlay.EditedBy = MainViewModel.LoggedUser.UserId;
                await DB.UpdatePlay(EditedPlay);
                return true;
            }
            return false;
        }
    }
}
