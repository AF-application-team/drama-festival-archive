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
using System.Windows.Shapes;
using AF_Desktop_Application.View_Models;
using AF_Models;

namespace AF_Desktop_Application
{
    /// <summary>
    /// Interaction logic for AwardWindow.xaml
    /// </summary>
    public partial class AwardWindow : Window
    {
        public AwardEditViewModel AEViewModel { get; set; }
        
        public AwardWindow(List<int> festivalsList, ObservableCollection<Category> categoriesList)
        {
            AEViewModel = new AwardEditViewModel(festivalsList, categoriesList);
            InitializeComponent();
        }
        public AwardWindow(Award award, List<int> festivalsList, ObservableCollection<Category> categoriesList)
        {
            AEViewModel = new AwardEditViewModel(award, festivalsList, categoriesList);
            InitializeComponent();
        }

        private async void PlayTitleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            await AEViewModel.UpdateList(PlayTitleTextBox.Text);
            PlaysList.ItemsSource = AEViewModel.PlaysList;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            PlayFestivalComboBox.DataContext = AEViewModel.EditedAward;
            PlayCategoryComboBox.DataContext = AEViewModel.EditedAward;
            PlaysList.DataContext = AEViewModel.EditedAward;
           
            PlayFestivalComboBox.ItemsSource = AEViewModel.FestivalsList;
            PlayCategoryComboBox.ItemsSource = AEViewModel.CategoriesList;
            PlaysList.ItemsSource = AEViewModel.PlaysList;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = await AEViewModel.SaveAward();
        }

        
    }
}
