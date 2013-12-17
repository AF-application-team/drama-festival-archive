using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AF.Common.DTO;
using AF_Desktop_Application_WCF.AFServiceReference;

namespace AF_Desktop_Application_WCF.View_Models
{
    public class JobEditViewModel
    {
        //private static AFServiceClient _client = new AFServiceClient("WSHttpBinding_IAFService");
        private AFServiceClient _client = MainViewModel.Client;
        private JobDTO _originalJob;

        public JobDTO OriginalJob
        {
            get { return _originalJob; } 
            set { 
                _originalJob = value; 
                EditedJob = new JobDTO(value); 
            }
        }
        public JobDTO EditedJob { get; set; }

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
                await _client.UpdateJobAsync(EditedJob);
            }
            return true;
        }
    }
}
