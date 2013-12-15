using System.Windows;
using AF_Desktop_Application_WCF.View_Models;
using AF_Models;

namespace AF_Desktop_Application.Edit_Windows
{
    /// <summary>
    /// Interaction logic for JobEditWindow.xaml
    /// </summary>
    public partial class JobEditWindow : Window
    {
        public JobEditViewModel JEViewModel { get; set; }
        public JobEditWindow(Job job)
        {
            InitializeComponent();
            JEViewModel = new JobEditViewModel(job);
            this.DataContext = JEViewModel.EditedJob;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = await JEViewModel.SaveChanges();
        }
    }
}
