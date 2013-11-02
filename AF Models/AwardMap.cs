using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;

namespace AF_Models
{
    public class AwardMap : EntityTypeConfiguration<Award>
    {
        AwardMap()
        {
            // Primary Key
            this.HasKey(t => t.AwardId).Property(t => t.AwardId).HasColumnName("AwardId");
            //Property
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.FestivalId).HasColumnName("FestivalId");
            this.Property(t => t.PlayId).HasColumnName("PlayId");
            this.Property(t => t.EditDate).HasColumnName("EditDate");
            this.Property(t => t.EditedBy).HasColumnName("EditedBy");
            //Table 
            this.ToTable("Awards");
            //Relations
            this.HasRequired(t => t.Category).WithMany().HasForeignKey(f => f.CategoryId);
            this.HasRequired(t => t.Festival).WithMany().HasForeignKey(f => f.FestivalId);
            this.HasRequired(t => t.Play).WithMany().HasForeignKey(f => f.PlayId);
            this.HasRequired(t => t.Edited).WithMany().HasForeignKey(f => f.EditedBy);       
        }
    }
}
