using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AF_Models;

namespace AF.Common.DTO
{
    public class PersonFunctionDTO
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

        public PersonFunctionDTO() { }
        public PersonFunctionDTO(PersonFunctionDTO person)
        {
            PersonId = person.PersonId;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Role = person.Role;
        }

        public static PersonFunctionDTO FromJobEntity(RelationPersonPlayJob relation)
        {
            return new PersonFunctionDTO()
            {
                PersonId = relation.PersonId,
                FirstName = relation.Person.FirstName,
                LastName = relation.Person.LastName,
                Role = relation.Job.JobTitle
            };
        }

        public static PersonFunctionDTO FromRoleEntity(RelationPersonPlayRole relation)
        {
            return new PersonFunctionDTO()
            {
                PersonId = relation.PersonId,
                FirstName = relation.Person.FirstName,
                LastName = relation.Person.LastName,
                Role = relation.Role
            };
        }
    }
}
