using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Common.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int Group { get; set; }
        public int Order { get; set; }

        public CategoryDTO() { }
        public CategoryDTO(CategoryDTO category)
        {
            CategoryId = category.CategoryId;
            Title = category.Title;
            Group = category.Group;
            Order = category.Order;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var c = obj as CategoryDTO;
            if (c == null)
            {
                return false;
            }
            return (CategoryId == c.CategoryId) && (Title == c.Title) && (Group == c.Group) && (Order == c.Order);
        }
    }
}
