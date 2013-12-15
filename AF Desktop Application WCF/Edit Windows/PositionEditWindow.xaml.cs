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
using AF_Desktop_Application_WCF.View_Models;
using AF_Models;

namespace AF_Desktop_Application_WCF
{
    /// <summary>
    /// Interaction logic for PositionEditWindow.xaml
    /// </summary>
    public partial class PositionEditWindow : Window
    {
       public PositionEditViewModel PEViewModel { get; set; }
       public PositionEditWindow(Position position)
        {
            InitializeComponent();
            PEViewModel = new PositionEditViewModel(position);
            this.DataContext = PEViewModel.EditedPosition;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = await PEViewModel.SaveChanges();
        }
    }
}
