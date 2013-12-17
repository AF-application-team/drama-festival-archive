using System.Windows;
using AF.Common.DTO;
using AF_Desktop_Application_WCF.View_Models;

namespace AF_Desktop_Application_WCF.Edit_Windows
{
    /// <summary>
    /// Interaction logic for CategoryEditWindow.xaml
    /// </summary>
    public partial class CategoryEditWindow : Window
    {
        public CategoryEditViewModel CEViewModel { get; set; }
        public CategoryEditWindow(CategoryDTO category)
        {
            CEViewModel = new CategoryEditViewModel {OriginalCategory = category};
            InitializeComponent();
            this.DataContext = CEViewModel.EditedCategory;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = await CEViewModel.SaveChanges();
        }
    }
}
