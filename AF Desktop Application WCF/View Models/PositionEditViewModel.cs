using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AF_BusinessLogic;
using AF_Models;

namespace AF_Desktop_Application_WCF.View_Models
{
    public class PositionEditViewModel
    {
        static IAF_LogicService DB = new AF_Logic();
        public Position OriginalPosition { get; set; }
        public Position EditedPosition { get; set; }

        async public static Task<PositionEditViewModel> BuildPositionEditViewModel(int originalPositionId)
        {
            Position tmpData = await DB.GetPosition(originalPositionId);
            return new PositionEditViewModel(tmpData);
        }

        // private constructor called by the async method

        public PositionEditViewModel(Position originalPosition)
        {
            OriginalPosition = originalPosition;
            EditedPosition = new Position(OriginalPosition);
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
                await DB.UpdatePosition(EditedPosition);
            }
            return true;
        }
    }
}
