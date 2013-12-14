using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AF_BusinessLogic;
using AF_Models;

namespace AF_Desktop_Application
{
    public class CategoryEditViewModel
    {
        static IAF_LogicService DB = new AF_Logic();
        public Category OriginalCategory { get; set; }
        public Category EditedCategory { get; set; }
        
        async public static Task<CategoryEditViewModel> BuildCategoryEditViewModel(int originalCategoryId)  
        {       
            Category tmpData = await DB.GetCategory(originalCategoryId);
            return new CategoryEditViewModel(tmpData);
        }       

        // private constructor called by the async method
        
        public CategoryEditViewModel(Category originalCategory)
        {
            OriginalCategory = originalCategory;
            EditedCategory = new Category(OriginalCategory);
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
                await DB.UpdateCategory(EditedCategory);
            }
            return true;
        }
    }
}
