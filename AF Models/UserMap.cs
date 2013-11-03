using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;

namespace AF_Models
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        UserMap()
        {
            //Primary 
            this.HasKey(t => t.UserId).Property(t => t.UserId).HasColumnName("UserId");
            //Properties
            this.Property(t => t.Login).HasColumnName("Login");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Email).HasColumnName("Email");
            //Table
            this.ToTable("User");
        }    
    }
}
