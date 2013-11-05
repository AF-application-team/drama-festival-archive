using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;

namespace AF_Models
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        CategoryMap() 
        {
            //Primary 
            this.HasKey(t => t.CategoryId).Property(t => t.CategoryId).HasColumnName("CategoryId");//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Properties
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Group).HasColumnName("Group");
            this.Property(t => t.Order).HasColumnName("Order");
            this.Property(t => t.EditDate).HasColumnName("EditDate");
            this.Property(t => t.EditedBy).HasColumnName("EditedBy");
            //Table
            this.ToTable("Categories");
            //Relations
            this.HasRequired(t => t.Editor).WithMany().HasForeignKey(f => f.EditedBy);
        }
    }
} 
