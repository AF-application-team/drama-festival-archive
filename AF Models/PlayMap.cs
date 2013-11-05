using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;

namespace AF_Models
{
    public class PlayMap : EntityTypeConfiguration<Play>
    {
        PlayMap()
        {
            // Primary Key
            this.HasKey(t => t.PlayId).Property(t => t.PlayId).HasColumnName("PlayId");
            //Property
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.FestivalId).HasColumnName("FestivalId");
            this.Property(t => t.Day).HasColumnName("Day");
            this.Property(t => t.Order).HasColumnName("Order");
            this.Property(t => t.PlayedBy).HasColumnName("PlayedBy");
            this.Property(t => t.Motto).HasColumnName("Motto");
            this.Property(t => t.EditDate).HasColumnName("EditDate");
            this.Property(t => t.EditedBy).HasColumnName("EditedBy");
            //Table 
            this.ToTable("Plays");
            //Relations
            this.HasRequired(t => t.Festival).WithMany().HasForeignKey(f => f.FestivalId);
            this.HasRequired(t => t.Editor).WithMany().HasForeignKey(f => f.EditedBy);       
        }
    }
}
