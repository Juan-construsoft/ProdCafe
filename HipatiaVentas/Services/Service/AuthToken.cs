using HipatiaVentas.Models;
using HipatiaVentas.Services.IService;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace HipatiaVentas.Services.Service
{
    public class AuthToken : IAuthToken
    {
        private readonly IConfiguration configuration;

        public AuthToken(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

        public string GenerarToken(AuthModel authModel)
        {
            string SecretPassword = configuration["JWT:SecretPassword"];
            string Issuer = configuration["JWT:Issuer"];
            string Audience = configuration["JWT:Audience"];
            string Expire = configuration["JWT:Expire"];
            string key = configuration["JWT:key"];
            string ApiKey = configuration["JWT:ApiKey"];

            if (key.Equals(authModel.Key) && ApiKey.Equals(authModel.ApiKey))
            {
                var symmetricSecurityKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(SecretPassword)
                    );
                var signingCredentials = new SigningCredentials(
                        symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                    );
                var header = new JwtHeader(signingCredentials);

                var payload = new JwtPayload(
                        issuer: Issuer,
                        audience: Audience,
                        claims: null,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddMinutes(Convert.ToInt32(Expire))
                    );

                var token = new JwtSecurityToken(
                        header,
                        payload
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);

            }
            else
                return null;
        }
    }
}
