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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AF_Constants;

namespace AF_Desktop_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IAF_LogicService DB = new IAF_LogicService();
        
        public MainWindow()
        {
            InitializeComponent();
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
            if (true == new PlayEditWindow(Constants.EditModes.AddMode).ShowDialog())
                MessageBox.Show("Refresh");
        }

        private void EditPlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (true == new PlayEditWindow(Constants.EditModes.EditMode).ShowDialog())
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

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ConfigTab.IsSelected)
                this.CategoryDataGrid.
        }
    }
}
