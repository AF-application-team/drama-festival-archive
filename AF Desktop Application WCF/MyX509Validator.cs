using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Selectors;
namespace AF_Desktop_Application_WCF
{
    public class MyX509Validator : X509CertificateValidator
    {
        public override void Validate(
        X509Certificate2 certificate)
        {
            if (certificate == null ||
            certificate.SubjectName.Name != "CN=AFCert")
            {
                throw new SecurityTokenValidationException(
                "Certificate validation error");
            }
        }
    }
}
