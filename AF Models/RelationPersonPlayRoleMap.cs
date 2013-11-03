using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class RelationPersonPlayRoleMap : EntityTypeConfiguration<RelationPersonPlayRole>
    {
        RelationPersonPlayRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.RelationPersonPlayRoleId).Property(t => t.RelationPersonPlayRoleId).HasColumnName("RelationPersonPlayRoleId");
            //Property
            this.Property(t => t.PersonId).HasColumnName("PersonId");
            this.Property(t => t.PlayId).HasColumnName("PlayId");
            this.Property(t => t.Role).HasColumnName("Role");
            this.Property(t => t.EditDate).HasColumnName("EditDate");
            this.Property(t => t.EditedBy).HasColumnName("EditedBy");
            //Table 
            this.ToTable("RelationPersonPlayRole");
            //Relations
            this.HasRequired(t => t.Person).WithMany().HasForeignKey(f => f.PersonId);
            this.HasRequired(t => t.Play).WithMany().HasForeignKey(f => f.PlayId);
            this.HasRequired(t => t.Edited).WithMany().HasForeignKey(f => f.EditedBy);
        }
    }
}
