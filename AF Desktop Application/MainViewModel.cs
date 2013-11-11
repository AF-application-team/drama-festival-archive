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
        static User LoggedUser { get; set; }

        #region Global parameters
        #region People Tab
        public ObservableCollection<Person> QuerriedPeople { get; set; }
        public int PeoplePage { get; set; }

        #endregion
        #region Plays Tab
        public ObservableCollection<Play> QuerriedPlays { get; set; }
        public int PlaysPage { get; set; }
        #endregion
        #region Awards Tab
        public ObservableCollection<Award> QuerriedAwards { get; set; }
        public int AwardsPage { get; set; }
        #endregion
        #region Configuration Tab
        public ObservableCollection<Category> CategoriesList { get; set; }
        public ObservableCollection<Job> JobsList { get; set; }
        public ObservableCollection<Position> PositionsList { get; set; }

        #endregion
        #endregion

        public PlaysSearchingCriteria PlaysCriteria { get; set; }
        public PeopleSearchingCriteria PeopleCriteria { get; set; }
        public AwardsSearchingCriteria AwardsCriteria { get; set; }

        public async Task Initialize()
        {
            await RefreshCategories();
            await RefreshPositions();
            await RefreshJobs();

            LoggedUser = await DB.GetUser(1);
        }

        #region Refeshing Lists
        public async Task RefreshCategories()
        {
            CategoriesList = new ObservableCollection<Category>(await DB.GetAllCategories());
            //CategoriesListBox.ItemsSource = CategoriesList;
            //AwardCategoryFilter.ItemsSource = CategoriesList;
            //PersonAwardFilter.ItemsSource = CategoriesList;
        }
        public async Task RefreshJobs()
        {
            JobsList = new ObservableCollection<Job>(await DB.GetAllJobs());
            //PersonJobFilter.ItemsSource = JobsList;
            //JobsListBox.ItemsSource = JobsList;
        }
        public async Task RefreshPositions()
        {
            PositionsList = new ObservableCollection<Position>(await DB.GetAllPositions());
            //PersonPositionFilter.ItemsSource = PositionsList;
            //PositionsListBox.ItemsSource = PositionsList;

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

    }
}
