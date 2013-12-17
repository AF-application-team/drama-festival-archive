using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Common.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    
        public UserDTO() { }
        public UserDTO(UserDTO user)
        {
            UserId = user.UserId;
            Login = user.Login;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var c = obj as UserDTO;
            if (c == null)
            {
                return false;
            }
            return (UserId == c.UserId) && (Login == c.Login) && (FirstName == c.FirstName) && (LastName == c.LastName) && (Email == c.Email);
        }    
    }
}
