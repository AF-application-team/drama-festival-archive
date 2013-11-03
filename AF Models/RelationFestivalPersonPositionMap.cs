using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class RelationFestivalPersonPositionMap : EntityTypeConfiguration<RelationFestivalPersonPosition>
    {
        RelationFestivalPersonPositionMap()
        {
            // Primary Key
            this.HasKey(t => t.RelationFestivalPersonPositionId).Property(t => t.RelationFestivalPersonPositionId).HasColumnName("RelationFestivalPersonPositionId");
            //Property
            this.Property(t => t.FestivalId).HasColumnName("FestivalId");
            this.Property(t => t.PersonId).HasColumnName("PersonId");
            this.Property(t => t.PositionId).HasColumnName("PositionId");
            this.Property(t => t.EditDate).HasColumnName("EditDate");
            this.Property(t => t.EditedBy).HasColumnName("EditedBy");
            //Table 
            this.ToTable("RelationFestivalPersonPosition");
            //Relations
            this.HasRequired(t => t.Festival).WithMany().HasForeignKey(f => f.FestivalId);
            this.HasRequired(t => t.Person).WithMany().HasForeignKey(f => f.PersonId);
            this.HasRequired(t => t.Position).WithMany().HasForeignKey(f => f.PositionId);
            this.HasRequired(t => t.Edited).WithMany().HasForeignKey(f => f.EditedBy);
        }
    }
}
