using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;

namespace AF.Services
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
