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

        #region Global parameters
            #region for People Tab
            public ObservableCollection<Person> QuerriedPeople { get; set; }

            #endregion
            #region for Plays Tab
            public ObservableCollection<Play> QuerriedPlays { get; set; }

            #endregion
            #region Awards Tab
            public ObservableCollection<Award> QuerrieAwards { get; set; } 
            
            #endregion
            #region Configuration Tab
            public ObservableCollection<Category> CategoriesList { get; set; }
            public ObservableCollection<Job> JobsList { get; set; }
            public ObservableCollection<Position> Positions { get; set; } 
            
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
                //PlaysList = new ObservableCollection<Play>(await DB.GetPlaysPaged(1,10));
                //PlaysDataGrid.ItemsSource = PlaysList;
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
            CategoriesList = new ObservableCollection<Category>(await DB.GetAllCategories());
            CategoriesListBox.ItemsSource = CategoriesList;
            //JobsList = new ObservableCollection<Job>(await DB.GetAllJobs());
            //JobsListBox.ItemsSource = JobsList;
            //CategoriesList = new ObservableCollection<Position>(await DB.GetAllPositions());
            //CategoriesListBox.ItemsSource = CategoriesList;
            TabControl.IsEnabled = true;

        }
    }
}
