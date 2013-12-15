using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using AF_DataAccessLayer;
using AF_Models;
using SimpleCrypto;

namespace AF.Services
{
    public class UserValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            using (var context = new AF_Context())
            {
                const string pepper = "50.L1`(f761OJdG6fc835M(5(+Ju2!P6,4330_N*/%xz<j7(N15KC'8l997'0c0CEg";
                ICryptoService cryptoService = new PBKDF2();
                try
                {
                    User u = context.Users.First(c => c.Login == userName);
                    bool verified = cryptoService.Compare(cryptoService.Compute(cryptoService.Compute(password, u.Salt), pepper),u.Password);
                    if (!verified)
                        throw new SecurityTokenException("Wrong Username or Password");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}