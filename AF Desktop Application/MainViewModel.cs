using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AF_BusinessLogic;
using AF_Models;
using AF_Searching_Criteria;

namespace AF_Desktop_Application
{
    public class MainViewModel
    {
        static IAF_LogicService DB = new AF_Logic();
        static public User LoggedUser { get; set; }
        public List<int> FestivalsList { get; set; }


        public MainViewModel()
        {
            PlaysCriteria = new PlaysSearchingCriteria();
            PeopleCriteria = new PeopleSearchingCriteria();
            AwardsCriteria = new AwardsSearchingCriteria();
        }
        public async Task Initialize()
        {
            await RefreshCategories();
            await RefreshPositions();
            await RefreshJobs();
            FestivalsList = new List<int>();
            int f = await DB.CountFestivals();
            for (int i = 1; i < f; i++)
                FestivalsList.Add(i);
            LoggedUser = await DB.GetUser(1);
        }
        
        #region Tab Properties
        #region People Tab
        public PeopleSearchingCriteria PeopleCriteria { get; set; }
        public int PeoplePage { get; set; }
        public ObservableCollection<Person> QuerriedPeople { get; set; }
        #endregion
        #region Plays Tab
        public PlaysSearchingCriteria PlaysCriteria { get; set; }
        public int PlaysPage { get; set; }
        public ObservableCollection<Play> QuerriedPlays { get; set; }
        #endregion
        #region Awards Tab
        public AwardsSearchingCriteria AwardsCriteria { get; set; }
        public int AwardsPage { get; set; }
        public List<Award> QuerriedAwards { get; set; }
        #endregion
        #region Configuration Tab
        public ObservableCollection<Category> CategoriesList { get; set; }
        public ObservableCollection<Job> JobsList { get; set; }
        public ObservableCollection<Position> PositionsList { get; set; }

        #endregion
        #endregion

        #region Refeshing Lists
        public async Task RefreshCategories()
        {
            CategoriesList = new ObservableCollection<Category>(await DB.GetAllCategories());
        }
        public async Task RefreshJobs()
        {
            JobsList = new ObservableCollection<Job>(await DB.GetAllJobs());
        }
        public async Task RefreshPositions()
        {
            PositionsList = new ObservableCollection<Position>(await DB.GetAllPositions());
        }
        #endregion

        public async Task AddCategory(string title, int group, int order)
        {
            if (title != "")
            {
                await DB.AddCategory(title, group , order, LoggedUser.UserId);
                await RefreshCategories();
            }
        }
        public async Task AddJob(string title)
        {
            if (title != "")
            {
                await DB.AddJob(title, LoggedUser.UserId);
                await RefreshJobs();
            }
        }
        public async Task AddPosition(string title, int section, int order)
        {
            if (title != "")
            {
                await DB.AddPosition(title, section, order, LoggedUser.UserId);
                await RefreshPositions();
            }
        }

        #region Searching
        public async Task SearchPlays(int pageNr, int pageAmount)
        {
            QuerriedPlays = new ObservableCollection<Play>(await DB.SearchPlays(PlaysCriteria, pageNr, pageAmount));
        }

        public async Task SearchAwards(int pageNr, int pageAmount)
        {
            QuerriedAwards = await DB.SearchAwards(AwardsCriteria, pageNr, pageAmount);
        } 
        #endregion

        public async Task<bool> ChangeUser(int userId)
        {
            if (LoggedUser.UserId == userId)
                return false;
            else 
                LoggedUser = await DB.GetUser(userId);
            return true;
        }

    }
}
