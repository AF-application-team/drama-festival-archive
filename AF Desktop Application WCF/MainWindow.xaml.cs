using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Security;
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
using AF.Common.DTO;
using AF_Constants;
using AF_Desktop_Application_WCF.Edit_Windows;

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
#if DEBUG
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(
            delegate
            {
                return true;
            });
#endif

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

        private async void EditPlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlaysDataGrid.SelectedIndex != -1)
            {
                var play = (PlayDataDTO) PlaysDataGrid.SelectedItem;
                //TODO Czy okna nie powinien wywoływać ViewModel??
                if (new PlayEditWindow((await MainViewModel.Client.GetPlayAsync(play.PlayId)).Data, MViewModel.FestivalsList).ShowDialog() == true)
                {
                    PlaysSearchButton_Click(this, new RoutedEventArgs());
                }

            //if (true == new PlayEditWindow(Constants.EditModes.EditMode, new Play{PlayId = 3,Title = "TytułSztuki",Author = "Szekspir",Day = 1,EditDate = new DateTime(), EditedBy = 1}).ShowDialog())
            // MessageBox.Show("Refresh");
            }
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
            new AwardWindow(MViewModel.CategoriesList).ShowDialog();
        }
        private void RemoveAwardButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private async void EditAwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (AwardsDataGrid.SelectedIndex != -1)
            {
                var a = ((AwardMixedDTO)AwardsDataGrid.SelectedItem);
                //TODO Czy okna nie powinien wywoływać ViewModel??

                if (new AwardWindow((await MainViewModel.Client.GetAwardAsync(a.AwardId)).Data, a, MViewModel.CategoriesList).ShowDialog() == true)
                {
                    AwardsSearchButton_Click(this, new RoutedEventArgs());
                }
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
            AddJobTextBox.Text = "";
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
            CategoryDTO c = (CategoryDTO)tb.DataContext;
            if (new CategoryEditWindow((await MainViewModel.Client.GetCategoryAsync(c.CategoryId)).Data).ShowDialog() == true)
            {
                await RefreshCategories();
            }
        }

        private async void Job_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var tb = (TextBlock)sender;
            JobDTO j = (JobDTO)tb.DataContext;
            if (new JobEditWindow((await MainViewModel.Client.GetJobAsync(j.JobId)).Data).ShowDialog() == true)
            {
                await RefreshJobs();
            }
        }

        private async void Position_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var tb = (TextBlock)sender;
            PositionDTO p = (PositionDTO)tb.DataContext;
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
            ComboBox cb = (ComboBox)sender;
            if (e.Key == Key.Delete)
                cb.SelectedIndex = -1;
        }

        private async void UserMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var mi = (MenuItem)sender;

            int n = int.Parse(mi.Tag.ToString());

            MViewModel.ChangeUser(n);

            var menu = ((MenuItem) (mi.Parent)).Items;
            foreach (var obj in menu)
            {
                var menuItem = ((MenuItem) obj);
                if (int.Parse(menuItem.Tag.ToString()) != n)
                    menuItem.IsChecked = false;
                else
                    menuItem.IsChecked = true;
            }
        }
    }
}
