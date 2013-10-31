using AF_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_DataAccessLayer
{
    public interface IAF_DataAccess
    {
        #region Person
        int AddPerson(Person newPerson);
        void RemovePerson(int id);
        Person GetPerson(int id);
        List<Person> GetPeoplePaged(int pageNr, int pageAmount);
        void UpdatePerson(Person updateData);
        #endregion
    }
}
