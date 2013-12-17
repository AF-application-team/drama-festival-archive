using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Common.DTO
{
    public class JobDTO
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }

        public JobDTO() { }
        public JobDTO(JobDTO job)
        {
            JobId = job.JobId;
            JobTitle = job.JobTitle;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var c = obj as JobDTO;
            if (c == null)
            {
                return false;
            }
            return (JobId == c.JobId) && (JobTitle == c.JobTitle);
        }
    }
}
