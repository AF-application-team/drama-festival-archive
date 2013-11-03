using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class PositionMap : EntityTypeConfiguration<Position>
    {
        PositionMap()
        {
            // Primary Key
            this.HasKey(t => t.PositionId).Property(t => t.PositionId).HasColumnName("PositionId");
            //Property
            this.Property(t => t.PositionTitle).HasColumnName("PositionTitle");
            this.Property(t => t.Section).HasColumnName("Section");
            this.Property(t => t.Order).HasColumnName("Order");
            this.Property(t => t.EditDate).HasColumnName("EditDate");
            this.Property(t => t.EditedBy).HasColumnName("EditedBy");
            //Table 
            this.ToTable("Positions");
            //Relations
            this.HasRequired(t => t.Edited).WithMany().HasForeignKey(f => f.EditedBy);       
        }
    }
}
