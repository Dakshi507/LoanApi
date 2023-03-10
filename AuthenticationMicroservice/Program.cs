

using AuthenticationMicroservice.Context;
using AuthenticationMicroservice.Repository;


using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnStr")));

builder.Services.AddCors(o =>
   o.AddPolicy("corspolicy", builder =>
   {
       builder.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader();
   }));



builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IAuthRepo, AuthRepo>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options => {
      options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
              .GetBytes(configuration.GetSection("AppSettings:Token").Value)),
          ValidateIssuer = false,
          ValidateAudience = false
      };
  });



builder.Services.AddControllers();
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
//app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseCors("corspolicy");

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();


app.MapControllers();



app.Run();