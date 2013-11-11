using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }


        [ForeignKey("EditedBy")]
        public virtual User Editor { get; set; }

        public Job() { }
        public Job(Job job)
        {
            JobId = job.JobId;
            JobTitle = job.JobTitle;
            EditDate = job.EditDate;
            EditedBy = job.EditedBy;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var j = obj as Job;
            if ((System.Object)j == null)
            {
                return false;
            }

            return (JobId == j.JobId) && (JobTitle == j.JobTitle);
        }
    }
}
