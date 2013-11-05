using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class FestivalMap : EntityTypeConfiguration<Festival>
    {
        FestivalMap()
        {
            // Primary Key
            this.HasKey(t => t.FestivalId).Property(t => t.FestivalId).HasColumnName("FestivalId");
            //Property
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.BeginningDate).HasColumnName("BeginningDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.EditDate).HasColumnName("EditDate");
            this.Property(t => t.EditedBy).HasColumnName("EditedBy");
            //Table 
            this.ToTable("Festivals");
            //Relations
            this.HasRequired(t => t.Editor).WithMany().HasForeignKey(f => f.EditedBy);       
        }
    }
}
