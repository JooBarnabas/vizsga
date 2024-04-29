using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using JWT;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace jwttest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DecodeJwt(ConvertJwtStringToJwtSecurityToken("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.FbifnHjdk-a_mvFaUIKogMD3vbUmNT8OJ1JcWS43554"));
        }
        public static JwtSecurityToken ConvertJwtStringToJwtSecurityToken(string? jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);

            return token;
        }
        public static void DecodeJwt(JwtSecurityToken token)
        {
            var keyId = token.Header.Kid;
            var audience = token.Audiences.ToList();
            //var claims = token.Claims.Select(claim => (claim.Type, claim.Value)).ToList();
            var claims = token.Claims.Select(claim =>  claim.Value).ToList();
            //Console.WriteLine(claims[1]);
            string a = claims[1].ToString();
        }

    }
}