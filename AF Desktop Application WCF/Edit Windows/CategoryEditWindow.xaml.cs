using System.Windows;
using AF_Desktop_Application_WCF.View_Models;
using AF_Models;

namespace AF_Desktop_Application.Edit_Windows
{
    /// <summary>
    /// Interaction logic for CategoryEditWindow.xaml
    /// </summary>
    public partial class CategoryEditWindow : Window
    {
        public CategoryEditViewModel CEViewModel { get; set; }
        public CategoryEditWindow(Category category)
        {
            InitializeComponent();
            CEViewModel = new CategoryEditViewModel(category);
            this.DataContext = CEViewModel.EditedCategory;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = await CEViewModel.SaveChanges();
        }
    }
}
