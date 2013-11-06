using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AF_Constants;
using AF_BusinessLogic;
using AF_Models;

namespace AF_Desktop_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static IAF_LogicService DB = new AF_Logic();
        static User LoggedUser { get; set; }

        #region Global parameters
        #region for People Tab
        public ObservableCollection<Person> QuerriedPeople { get; set; }
        public int PeoplePerPage { get; set; }

        #endregion
        #region for Plays Tab
        public ObservableCollection<Play> QuerriedPlays { get; set; }
        public int PlaysPerPage { get; set; }
        #endregion
        #region Awards Tab
        public ObservableCollection<Award> QuerrieAwards { get; set; }
        public int AwardsPerPage { get; set; }
        #endregion
        #region Configuration Tab
        public ObservableCollection<Category> CategoriesList { get; set; }
        public ObservableCollection<Job> JobsList { get; set; }
        public ObservableCollection<Position> PositionsList { get; set; } 
            
        #endregion
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            //this.CategoriesListBox = DB.GetAllCategories();
            //this.PlaysList =new ObservableCollection<Play>(await DB.GetPlaysPaged(1, 10));
        }
        
        #region PeopleTab
        private void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemovePersonButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditPersonButton_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region PlaysTab
        private void AddPlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (true == new PlayEditWindow(Constants.EditModes.AddMode, new Play()).ShowDialog())
                MessageBox.Show("Refresh");
        }

        private void EditPlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (true == new PlayEditWindow(Constants.EditModes.EditMode, new Play{PlayId = 3,Title = "TytułSztuki",Author = "Szekspir",Day = 1,EditDate = new DateTime(), EditedBy = 1}).ShowDialog())
                MessageBox.Show("Refresh");
        }

        private void RemovePlayButton_Click(object sender, RoutedEventArgs e)
        {
            
        } 
        #endregion

        #region AwardsTab
        private void AddAwardButton_Click(object sender, RoutedEventArgs e)
        {
            var awardDialog = new AwardWindow();
            awardDialog.ShowDialog();
        }
        private void RemoveAwardButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditAwardButton_Click(object sender, RoutedEventArgs e)
        {

        } 
        #endregion

        private async void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabControl.SelectedIndex==3)
            {
                
            }
            else if (TabControl.SelectedIndex == 2)
            {
                
            }
        }

        private void PlayRow_Loaded(object sender, RoutedEventArgs e)
        {
            //var row = sender as DataGridRow;
            //row.InputBindings.Add(new MouseBinding(MyCommands.MyCommand,
            //        new MouseGesture() { MouseAction = MouseAction.LeftDoubleClick }));
        }

        private async void SaveMenu_Click(object sender, RoutedEventArgs e)
        {
            this.QuerriedPlays = new ObservableCollection<Play>(await DB.GetPlaysPaged(1, 10));
            PlaysDataGrid.ItemsSource = QuerriedPlays;
        }

        private async void MainWindow_Initialized(object sender, EventArgs e)
        {
            RefreshCategories();
            RefreshPositions();
            RefreshJobs();

            LoggedUser = await DB.GetUser(1);
            this.IsEnabled = true;
        }

        #region Refeshing Lists
        private async void RefreshCategories()
        {
            CategoriesList = new ObservableCollection<Category>(await DB.GetAllCategories());
            CategoriesListBox.ItemsSource = CategoriesList;
            AwardCategoryFilter.ItemsSource = CategoriesList;
            PersonAwardFilter.ItemsSource = CategoriesList;
        }
        private async void RefreshJobs()
        {
            JobsList = new ObservableCollection<Job>(await DB.GetAllJobs());
            PersonJobFilter.ItemsSource = JobsList;
            JobsListBox.ItemsSource = JobsList;
        }
        private async void RefreshPositions()
        {
            PositionsList = new ObservableCollection<Position>(await DB.GetAllPositions());
            PersonPositionFilter.ItemsSource = PositionsList;
            PositionsListBox.ItemsSource = PositionsList;

        } 
        #endregion
        #region Adding Categories, Jobs and Positions
        private async void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO Poprawić hardcodowane wartości służące do ustawienia kategorii w kolejności za pomocą procedur składowanych!!
            AddCategoryButton.IsEnabled = false;
            var cat = new Category
            {
                Title = AddCategoryTextBox.Text,
                EditDate = DateTime.Now,
                EditedBy = LoggedUser.UserId,
                Group = 7,
                Order = 10
            };
            await DB.AddCategory(cat);
            AddCategoryTextBox.Text = "";
            RefreshCategories();
            AddCategoryButton.IsEnabled = true;
        }
        private async void AddJobButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO Poprawić hardcodowane wartości służące do ustawienia kategorii w kolejności za pomocą procedur składowanych!!
            AddJobButton.IsEnabled = false;
            var job = new Job
            {
                JobTitle = AddJobTextBox.Text,
                EditDate = DateTime.Now,
                EditedBy = LoggedUser.UserId,
            };
            await DB.AddJob(job);
            AddJobTextBox.Text = "";
            RefreshJobs();
            AddJobButton.IsEnabled = true;
        }

        private async void AddPositionButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO Poprawić hardcodowane wartości służące do ustawienia kategorii w kolejności za pomocą procedur składowanych!!
            AddPositionButton.IsEnabled = false;
            var position = new Position
            {
                PositionTitle = AddPositionTextBox.Text,
                EditDate = DateTime.Now,
                EditedBy = LoggedUser.UserId,
                Section = 12,
                Order = 6
            };
            await DB.AddPosition(position);
            AddPositionTextBox.Text = "";
            RefreshPositions();
            AddPositionButton.IsEnabled = true;
        } 
        #endregion
    }
}
