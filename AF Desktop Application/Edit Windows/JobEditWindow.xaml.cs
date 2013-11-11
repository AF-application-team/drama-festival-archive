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
