using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class NewsMap : EntityTypeConfiguration<News>
    {
         NewsMap()
        {
            // Primary Key
            this.HasKey(t => t.NewsId).Property(t => t.NewsId).HasColumnName("NewsId");
            //Property
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.EditDate).HasColumnName("EditDate");
            this.Property(t => t.EditedBy).HasColumnName("EditedBy");
            //Table 
            this.ToTable("News");
            //Relations
            this.HasRequired(t => t.Edited).WithMany().HasForeignKey(f => f.EditedBy);       
        }
    }
}
