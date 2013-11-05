using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        PersonMap()
        {
            // Primary Key
            this.HasKey(t => t.PersonId).Property(t => t.PersonId).HasColumnName("PersonId");
            //Property
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Profile).HasColumnName("Profile"); //can make enum
            this.Property(t => t.EditDate).HasColumnName("EditDate");
            this.Property(t => t.EditedBy).HasColumnName("EditedBy");
            //Table 
            this.ToTable("People");
            //Relations
            this.HasRequired(t => t.Editor).WithMany().HasForeignKey(f => f.EditedBy);       
        }
    }
}
