using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class RelationPersonAwardMap : EntityTypeConfiguration<RelationPersonAward>
    {
        RelationPersonAwardMap()
        {
            // Primary Key
            this.HasKey(t => t.RelationPersonAwardId).Property(t => t.RelationPersonAwardId).HasColumnName("RelationPersonAwardId");
            //Property
            this.Property(t => t.PersonId).HasColumnName("PersonId");
            this.Property(t => t.AwardId).HasColumnName("AwardId");
            this.Property(t => t.EditDate).HasColumnName("EditDate");
            this.Property(t => t.EditedBy).HasColumnName("EditedBy");
            //Table 
            this.ToTable("RelationPersonAward");
            //Relations
            this.HasRequired(t => t.Person).WithMany().HasForeignKey(f => f.PersonId);
            this.HasRequired(t => t.Award).WithMany().HasForeignKey(f => f.AwardId);
            this.HasRequired(t => t.Editor).WithMany().HasForeignKey(f => f.EditedBy);
        }
    }
}
