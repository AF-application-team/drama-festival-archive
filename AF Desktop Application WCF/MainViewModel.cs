using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AF.Common.DTO;
using AF.Common.Queries;
using AF.Common.Requests;
using AF_Desktop_Application_WCF.AFServiceReference;

namespace AF_Desktop_Application_WCF
{
    public class MainViewModel
    {
        //static IAF_LogicService DB = new AF_Logic();
        static public AFServiceClient Client = new AFServiceClient("WSHttpBinding_IAFService");
        static public UserDTO LoggedUser { get; set; }
        public List<int> FestivalsList { get; set; }
        private string[] _logins = { "Janusz", "Ania", "Janusz" };
        private string[] _passes = { "AFtest", "hobbit", "WrongPassword" };

        public MainViewModel()
        {
            PlaysCriteria = new PlaysSearchingCriteria();
            PeopleCriteria = new PeopleSearchingCriteria();
            AwardsCriteria = new AwardsSearchingCriteria();
        }
        public async Task Initialize()
        {
            Client.ClientCredentials.UserName.UserName = _logins[0];
            Client.ClientCredentials.UserName.Password = _passes[0];

            await RefreshCategories();
            await RefreshPositions();
            await RefreshJobs();

            FestivalsList = new List<int>();
            int f = (await Client.CountFestivalsAsync()).Data;
            for (int i = 1; i < f; i++)
                FestivalsList.Add(i);
        }

        #region Tab Properties
        #region People Tab
        public PeopleSearchingCriteria PeopleCriteria { get; set; }
        public int PeoplePage { get; set; }
        public ObservableCollection<PersonDataDTO> QuerriedPeople { get; set; }
        #endregion
        #region Plays Tab
        public PlaysSearchingCriteria PlaysCriteria { get; set; }
        public int PlaysPage { get; set; }
        public ObservableCollection<PlayDataDTO> QuerriedPlays { get; set; }
        #endregion
        #region Awards Tab
        public AwardsSearchingCriteria AwardsCriteria { get; set; }
        public int AwardsPage { get; set; }
        public List<AwardMixedDTO> QuerriedAwards { get; set; }
        #endregion
        #region Configuration Tab
        public ObservableCollection<CategoryDTO> CategoriesList { get; set; }
        public ObservableCollection<JobDTO> JobsList { get; set; }
        public ObservableCollection<PositionDTO> PositionsList { get; set; }

        #endregion
        #endregion

        #region Refeshing Lists
        public async Task RefreshCategories()
        {
            CategoriesList = new ObservableCollection<CategoryDTO>((await Client.GetAllCategoriesAsync()).Data);
        }
        public async Task RefreshJobs()
        {
            JobsList = new ObservableCollection<JobDTO>((await Client.GetAllJobsAsync()).Data);
        }
        public async Task RefreshPositions()
        {
            PositionsList = new ObservableCollection<PositionDTO>((await Client.GetAllPositionsAsync()).Data);
        }
        #endregion

        public async Task AddCategory(string title, int group, int order)
        {
            if (title != "")
            {
                await Client.AddCategoryAsync(new CategoryDTO { Title = title, Group = group, Order = order });
                await RefreshCategories();
            }
        }
        public async Task AddJob(string title)
        {
            if (title != "")
            {
                await Client.AddJobAsync(new JobDTO { JobTitle = title });
                await RefreshJobs();
            }
        }
        public async Task AddPosition(string title, int section, int order)
        {
            if (title != "")
            {
                await Client.AddPositionAsync(new PositionDTO { PositionTitle = title, Section = section, Order = order });
                await RefreshPositions();
            }
        }

        #region Searching
        public async Task SearchPlays(int pageNr, int pageAmount)
        {
            QuerriedPlays = new ObservableCollection<PlayDataDTO>((await Client.SearchPlaysAsync(PlaysCriteria, pageNr, pageAmount)).Data);
        }

        public async Task SearchAwards(int pageNr, int pageAmount)
        {
            QuerriedAwards = (await Client.SearchAwardsAsync(AwardsCriteria, pageNr, pageAmount)).Data;
        }
        #endregion

        public void ChangeUser(int n)
        {
            Client = new AFServiceClient("WSHttpBinding_IAFService");
            Client.ClientCredentials.UserName.UserName = _logins[n];
            Client.ClientCredentials.UserName.Password = _passes[n];
        }

    }
}
