using System.Windows;
using AF.Common.DTO;
using AF_Desktop_Application_WCF.View_Models;

namespace AF_Desktop_Application_WCF.Edit_Windows
{
    /// <summary>
    /// Interaction logic for JobEditWindow.xaml
    /// </summary>
    public partial class JobEditWindow : Window
    {
        public JobEditViewModel JEViewModel { get; set; }
        public JobEditWindow(JobDTO job)
        {
            InitializeComponent();
            JEViewModel = new JobEditViewModel();
            JEViewModel.Initialize(job.JobId);
            this.DataContext = JEViewModel.EditedJob;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = await JEViewModel.SaveChanges();
        }
    }
}
