using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class JobMap : EntityTypeConfiguration<Job>
    {
        JobMap()
        {
            //Primary 
            this.HasKey(t => t.JobId).Property(t => t.JobId).HasColumnName("JobId");
            //Properties
            this.Property(t => t.JobTitle).HasColumnName("JobTitle");
            this.Property(t => t.EditDate).HasColumnName("EditDate");
            this.Property(t => t.EditedBy).HasColumnName("EditedBy");
            //Table
            this.ToTable("Jobs");
            //Relations
            this.HasRequired(t => t.Edited).WithMany().HasForeignKey(f => f.EditedBy); 
        }
    }
}
