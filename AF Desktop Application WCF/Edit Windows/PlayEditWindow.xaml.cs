using AF_Constants;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for PlayEditWindow.xaml
    /// </summary>
    public partial class PlayEditWindow : Window
    {
        public PlayEditViewModel PEViewModel { get; set; }
        public PlayEditWindow(List<int> fesitvalsList)
        {
            PEViewModel =new PlayEditViewModel(fesitvalsList);
            InitializeComponent();
        }

        public PlayEditWindow(Play editedPlay, List<int> fesitvalsList)
        {
            PEViewModel = new PlayEditViewModel(editedPlay, fesitvalsList);
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            this.DataContext = PEViewModel.EditedPlay;
            FestivalComboBox.ItemsSource = PEViewModel.FestivalsList;
            DayComboBox.ItemsSource = PEViewModel.Ints;
            OrderComboBox.ItemsSource = PEViewModel.Ints;

        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = await PEViewModel.SavePlay();
        }
    }
}
