using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AF.Common.DTO;
using AF_Desktop_Application_WCF.AFServiceReference;

namespace AF_Desktop_Application_WCF.View_Models
{
    public class CategoryEditViewModel
    {
        //private AFServiceClient _client = new AFServiceClient("WSHttpBinding_IAFService");
        private AFServiceClient _client = MainViewModel.Client;
        private CategoryDTO _originalCategory;

        public CategoryDTO OriginalCategory
        {
            get { return _originalCategory; }
            set
            {
                _originalCategory = value;
                EditedCategory = new CategoryDTO(value);
            }
        }
        public CategoryDTO EditedCategory { get; set; }

        public async Task<bool> SaveChanges()
        {
            if (EditedCategory.Title.Trim() == "")
            {
                MessageBox.Show("Kategoria musi mieć nazwę! Dane nie zostaną przesłane.");
                return false;
            }

            if (EditedCategory.Equals(OriginalCategory))
                return true;
            else
            {
                await _client.UpdateCategoryAsync(EditedCategory);
            }
            return true;
        }
    }
}
