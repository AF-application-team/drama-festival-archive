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
        static AFServiceClient _client = new AFServiceClient("WSHttpBinding_IAFService");
        public CategoryDTO OriginalCategory { get; set; }
        public CategoryDTO EditedCategory { get; set; }
        
        public async void Initialize(int id)
        {
            OriginalCategory = (await _client.GetCategoryAsync(id)).Data;
            EditedCategory = new CategoryDTO(OriginalCategory);
        }

        public async Task<bool> SaveChanges()
        {
            if (EditedCategory.Title.Trim() == "")
            {
                MessageBox.Show("Kategoria musi mieć nazwę! Dane nie zostaną przesłane.");
                return false;
            }
            
            if(EditedCategory.Equals(OriginalCategory))
                return true;
            else
            {
                await _client.UpdateCategoryAsync(EditedCategory);
            }
            return true;
        }
    }
}
