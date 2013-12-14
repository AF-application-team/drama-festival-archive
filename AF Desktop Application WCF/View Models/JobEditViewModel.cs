using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AF_BusinessLogic;
using AF_Models;

namespace AF_Desktop_Application
{
    public class JobEditViewModel
    {
        static IAF_LogicService DB = new AF_Logic();
        public Job OriginalJob { get; set; }
        public Job EditedJob { get; set; }

        async public static Task<JobEditViewModel> BuildJobEditViewModel(int originalJobId)
        {
            Job tmpData = await DB.GetJob(originalJobId);
            return new JobEditViewModel(tmpData);
        }

        public JobEditViewModel(Job originalJob)
        {
            OriginalJob = originalJob;
            EditedJob = new Job(OriginalJob);
        }

        public async Task<bool> SaveChanges()
        {
            if (EditedJob.JobTitle.Trim() == "")
            {
                MessageBox.Show("Praca musi mieć nazwę! Dane nie zostaną przesłane.");
                return false;
            }

            if (EditedJob.Equals(OriginalJob))
                return true;
            else
            {
                await DB.UpdateJob(EditedJob);
            }
            return true;
        }
    }
}
