using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AF_Models
{
    public class Category 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int Group { get; set; }
        public int Order { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }


        [ForeignKey("EditedBy")]
        public virtual User Editor { get; set; }

        public Category() { }
        public Category(Category category)
        {
            CategoryId = category.CategoryId;
            Title = category.Title;
            Group = category.Group;
            Order = category.Order;
            EditDate = category.EditDate;
            EditedBy = category.EditedBy;
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            var c = obj as Category;
            if ((System.Object)c == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (CategoryId == c.CategoryId) && (Title == c.Title) && (Group == c.Group) && (Order == c.Order);
        }
    }
}
