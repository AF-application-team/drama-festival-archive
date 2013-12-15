using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AF_DataAccessLayer;
using AF_Models;
using System.Data.Entity;
using SimpleCrypto;

namespace TestingConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            string pass = "";
            int id=0;
            ICryptoService cryptoService = new PBKDF2();
            const string pepper = "50.L1`(f761OJdG6fc835M(5(+Ju2!P6,4330_N*/%xz<j7(N15KC'8l997'0c0CEg";

            Console.WriteLine("Select user by id:");
            if (int.TryParse(Console.ReadLine(),out id))
            {
                using (var context = new AF_Context())
                {
                    try
                    {
                        User user = context.Users.First(u => u.UserId == id);
                        if (user != null)
                        {
                            while (string.IsNullOrEmpty(pass))
                            {
                                Console.WriteLine("Input Password:");
                                pass = Console.ReadLine();
                            }
                            user.Salt = cryptoService.GenerateSalt();
                            user.Password = cryptoService.Compute(cryptoService.Compute(pass, user.Salt), pepper);

                        }
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }



        }
    }
}
