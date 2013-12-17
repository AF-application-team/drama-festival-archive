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
        //static IAF_LogicService DB = new AF_Logic();
        private static AFServiceClient _client = new AFServiceClient("WSHttpBinding_IAFService");
        public PositionDTO OriginalPosition { get; set; }
        public PositionDTO EditedPosition { get; set; }

        public async void Initialize(int id)
        {
            OriginalPosition = (await _client.GetPositionAsync(id)).Data;
            EditedPosition = new PositionDTO(OriginalPosition);
        }

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
