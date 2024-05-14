using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace loja.controllers;

public class TokenGenerator
{
    //metodo de criaçao do token sera transportado para uma classe especifica
    public string GenerateToken(string data)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        // Esta chave secreta será armazenada em uma variável de ambiente por questões de segurança
        var secretKey = Encoding.ASCII.GetBytes("qwertyuiopasdfghjklzxcvbnmqwerty");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddHours(1), // O token expira em uma hora
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(secretKey),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
