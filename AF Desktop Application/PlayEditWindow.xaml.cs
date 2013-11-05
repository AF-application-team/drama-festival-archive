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
using AF_Models;

namespace AF_Desktop_Application
{
    /// <summary>
    /// Interaction logic for PlayEditWindow.xaml
    /// </summary>
    public partial class PlayEditWindow : Window
    {
        private int _editMode = Constants.EditModes.ReadMode;
        public Play EditedPlay { get; set; }
 
        public PlayEditWindow(int editMode, Play editedPlay)
        {
            InitializeComponent();
            _editMode = editMode;
            EditedPlay = editedPlay;
            if (_editMode == Constants.EditModes.ReadMode)
            {
                this.TitleTextBox.IsEnabled = false;
                this.AuthorTextBox.IsEnabled = false;
                this.FestivalComboBox.IsEnabled = false;
                this.DayComboBox.IsEnabled = false;
                this.OrderComboBox.IsEnabled = false;
                this.PlayedByTextBox.IsEnabled = false;
                this.MottoTextBox.IsEnabled = false;
            }
            else if (_editMode == Constants.EditModes.EditMode || _editMode == Constants.EditModes.AddMode)
            {
                
            }
            this.DataContext = EditedPlay;

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
