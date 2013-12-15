using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using AF_Desktop_Application_WCF.View_Models;
using AF_Models;

namespace AF_Desktop_Application.Edit_Windows
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
