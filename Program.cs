
/*
no terminal: dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
*/
/*Codigo padraopara lib de autenticacao*/
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;
/*Final do codigo padrao para libs*/
using loja.controllers;
using Microsoft.IdentityModel.Tokens;



var builder = WebApplication.CreateBuilder(args);


// codigo padrao: configuraçao metodo de autenticacao
builder.Services.AddAuthentication()
    .AddJwtBearer(options=>{
        options.TokenValidationParameters= new TokenValidationParameters{
            ValidateIssuer=false,
            ValidateAudience=false,
            ValidateIssuerSigningKey=true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes("qwertyuiopasdfghjklzxcvbnmqwerty")
            )
        };
    });
//Fim da configuraçao da autenticação
        




// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/login", async (HttpContext context) =>
{
    //Receber o request.body
    using var reader =
        new System.IO.StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();

    //Deserializar o objeto Json 
    var json = JsonDocument.Parse(body);
    //invocar o UserController
    var username = json.RootElement.GetProperty("username").GetString();
    var password = json.RootElement.GetProperty("password").GetString();
    //linha opcional
    userController userController = new userController();
    // se o user existe e te senha => gerar o token (credencial que da acesso aos demais endpoints)
    var token ="";
    if(userController.login(username, password)){
        //Gerar o token
        var tokenGenerator = new TokenGenerator();
        token = tokenGenerator.GenerateToken(username);
    }
    return token;
});




app.Run();

/*
String GenerateToken(String data){
    var tokenHandler = new JwtSecurityTokenHandler();
    //Esta chave secreta sera gravada em uma variavel de ambiente por questao de seguranca
    var secretKey = Encoding.ASCII.GetBytes("qwertyuiopasdfghjklzxcvbnmqwerty");
    var tokenDescriptor = new SecurityTokenDescriptor{
        Expires = DateTime.UtcNow.AddHours(1), //O token expira em uma hora
        SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(secretKey),
            SecurityAlgorithms.HmacSha256Signature
        )
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
}
*/

/*
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
*/