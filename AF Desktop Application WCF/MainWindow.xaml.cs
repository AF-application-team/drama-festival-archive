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
using AF_Desktop_Application.Edit_Windows;
using AF_Models;

namespace AF_Desktop_Application_WCF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MainViewModel MViewModel { get; set; }
        public MainWindow()
        {
            MViewModel = new MainViewModel();
            InitializeComponent();
        }
        private async void MainWindow_Initialized(object sender, EventArgs e)
        {
            this.DataContext = MViewModel;
            await MViewModel.Initialize();
            await RefreshCategories();
            await RefreshJobs();
            await RefreshPositions();

            PlayFestivalFilter.ItemsSource = MViewModel.FestivalsList;
            PlaysSearchToolBar.DataContext = MViewModel.PlaysCriteria;
            PlaysFiltersPanel.DataContext = MViewModel.PlaysCriteria;

            PeopleSearchToolBar.DataContext = MViewModel.PeopleCriteria;

            AwardsSearchToolBar.DataContext = MViewModel.AwardsCriteria;
            AwardFestivalFilter.ItemsSource = MViewModel.FestivalsList;
            AwardsFiltersPanel.DataContext = MViewModel.AwardsCriteria;
        }
        
        #region PeopleTab Buttons
        private void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemovePersonButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditPersonButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PeopleSearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion 

        #region PlaysTab Buttons
        private void AddPlayButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO Czy okna nie powinien wywoływać ViewModel??
            new PlayEditWindow(MViewModel.FestivalsList).ShowDialog();
        }

        private void EditPlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlaysDataGrid.SelectedIndex != -1)
                //TODO Czy okna nie powinien wywoływać ViewModel??
                if (new PlayEditWindow((Play)PlaysDataGrid.SelectedItem, MViewModel.FestivalsList).ShowDialog() == true)
                {
                    PlaysSearchButton_Click(this, new RoutedEventArgs());
                }
            
            //if (true == new PlayEditWindow(Constants.EditModes.EditMode, new Play{PlayId = 3,Title = "TytułSztuki",Author = "Szekspir",Day = 1,EditDate = new DateTime(), EditedBy = 1}).ShowDialog())
            // MessageBox.Show("Refresh");
        }

        private void RemovePlayButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void PlaysSearchButton_Click(object sender, RoutedEventArgs e)
        {
            var ppp = int.Parse(PlaysPerPageComboBox.Text);
            await MViewModel.SearchPlays(1, ppp);
            PlaysDataGrid.ItemsSource = MViewModel.QuerriedPlays;
        }
        #endregion

        #region AwardsTab Buttons
        private void AddAwardButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO Czy okna nie powinien wywoływać ViewModel??
            new AwardWindow(MViewModel.FestivalsList, MViewModel.CategoriesList).ShowDialog();
        }
        private void RemoveAwardButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void EditAwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (AwardsDataGrid.SelectedIndex != -1)
                //TODO Czy okna nie powinien wywoływać ViewModel??
                if (new AwardWindow((Award) AwardsDataGrid.SelectedItem, MViewModel.FestivalsList,
                        MViewModel.CategoriesList).ShowDialog() == true)
                {
                    AwardsSearchButton_Click(this,new RoutedEventArgs());
                }
        }
        private async void AwardsSearchButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("" + MViewModel.AwardsCriteria.ToString());
            var app = int.Parse(AwardsPerPageComboBox.Text);
            await MViewModel.SearchAwards(1, app);
            AwardsDataGrid.ItemsSource = MViewModel.QuerriedAwards;
        }
        #endregion
        
        #region Categories, Jobs and Positions
        #region Adding
        private async void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            await MViewModel.AddCategory(AddCategoryTextBox.Text, 7, 10);
            AddCategoryTextBox.Text = "";
            CategoriesListBox.ItemsSource = MViewModel.CategoriesList;
        }   
        private async void AddJobButton_Click(object sender, RoutedEventArgs e)
        {
            await MViewModel.AddJob(AddJobTextBox.Text);
            AddJobTextBox.Text="";
            JobsListBox.ItemsSource = MViewModel.JobsList;
        }
        private async void AddPositionButton_Click(object sender, RoutedEventArgs e)
        {
            await MViewModel.AddPosition(AddPositionTextBox.Text, 12, 7);
            AddPositionTextBox.Text = "";
            PositionsListBox.ItemsSource = MViewModel.PositionsList;
        } 
        #endregion
        #region Edition Window showing
        private async void Category_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var tb = (TextBlock)sender;
            Category c = (Category)tb.DataContext;
            if (new CategoryEditWindow(c).ShowDialog() == true)
            {
                await RefreshCategories();
            }
        }

        private async void Job_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var tb = (TextBlock)sender;
            Job j = (Job)tb.DataContext;
            if (new JobEditWindow(j).ShowDialog() == true)
            {
                await RefreshJobs();
            }
        }

        private async void Position_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var tb = (TextBlock)sender;
            Position p = (Position)tb.DataContext;
            if (new PositionEditWindow(p).ShowDialog() == true)
            {
                await RefreshPositions();
            }
        } 
        #endregion
		#endregion
        
        #region Refeshing Lists
        private async Task RefreshCategories()
        {
            await MViewModel.RefreshCategories();
            CategoriesListBox.ItemsSource = MViewModel.CategoriesList;
            //PlayAwardFilter.ItemsSource = MViewModel.CategoriesList;
            AwardCategoryFilter.ItemsSource = MViewModel.CategoriesList;
            PersonAwardFilter.ItemsSource = MViewModel.CategoriesList;
        }
        private async Task RefreshJobs()
        {
            await MViewModel.RefreshJobs();
            PersonJobFilter.ItemsSource = MViewModel.JobsList;
            JobsListBox.ItemsSource = MViewModel.JobsList;
        }
        private async Task RefreshPositions()
        {
            await MViewModel.RefreshPositions();
            PersonPositionFilter.ItemsSource = MViewModel.PositionsList;
            PositionsListBox.ItemsSource = MViewModel.PositionsList;

        }
        #endregion
        
        private void PlayRow_Loaded(object sender, RoutedEventArgs e)
        {
            //var row = sender as DataGridRow;
            //row.InputBindings.Add(new MouseBinding(MyCommands.MyCommand,
            //        new MouseGesture() { MouseAction = MouseAction.LeftDoubleClick }));
        }

        private async void SaveMenu_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(TitlePlayTextBox.DataContext.ToString()+"\n Selected Cat="+PlayAwardFilter.SelectedValue);
            //MessageBox.Show("Index = " + CategoriesListBox.SelectedIndex);
            //QuerriedPlays = new ObservableCollection<Play>(await DB.GetPlaysPaged(1, 10));
            //PlaysDataGrid.ItemsSource = QuerriedPlays;
            //this.QuerriedAwards = new ObservableCollection<Award>(await DB.GetAwardsPaged(1, 10));
            //AwardsDataGrid.ItemsSource = QuerriedAwards;
        }


        private void ClearComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            ComboBox cb = (ComboBox) sender;
            if (e.Key == Key.Delete)
                cb.SelectedIndex = -1;
        }

        private async void UserMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var mi = (MenuItem) sender;

            if (await MViewModel.ChangeUser(int.Parse(mi.Tag.ToString())))
            {
                UserMenuItem1.IsChecked = !UserMenuItem1.IsChecked;
                UserMenuItem2.IsChecked = !UserMenuItem2.IsChecked;
            }

        }
    }
}
