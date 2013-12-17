using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AF.Common.DTO;
using AF_Desktop_Application_WCF.AFServiceReference;

namespace AF_Desktop_Application_WCF.View_Models
{
    public class PositionEditViewModel
    {
        //private static AFServiceClient _client = new AFServiceClient("WSHttpBinding_IAFService");
        private AFServiceClient _client = MainViewModel.Client;
        private PositionDTO _originalPosition;
        public PositionDTO OriginalPosition { 
            get { return _originalPosition; }
            set
            {
                _originalPosition = value; 
                EditedPosition=new PositionDTO(value);
            } 
        }

        public PositionDTO EditedPosition { get; set; }

        public async Task<bool> SaveChanges()
        {
            if (EditedPosition.PositionTitle.Trim() == "")
            {
                MessageBox.Show("Pozycja musi mieć nazwę! Dane nie zostaną przesłane.");
                return false;
            }

            if (EditedPosition.Equals(OriginalPosition))
                return true;
            else
            {
                await _client.UpdatePositionAsync(EditedPosition);
            }
            return true;
        }
    }
}
