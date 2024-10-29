
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using TheBattleLibrary.API.Middlewares;
using TheBattleLibrary.Data;
using TheBattleLibrary.Data.Entities;
using TheBattleLibrary.Services;
using TheBattleLibrary.Services.Abstractions;
using TheBattleLibrary.Services.Security;

namespace TheBattleLibrary.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            // setting this up to use the DI-enabled logger instead of the Serilog static Log. class
            // to enforce the di pattern
            var serilogger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();
            builder.Logging.AddSerilog(serilogger);


            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin();
                                      policy.AllowAnyMethod();
                                      policy.AllowAnyHeader();
                                  });
            });
            
            Data.Startup.ConfigureServices(builder.Services, builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            builder.Services.AddSingleton(serviceProvider =>
            {
                return new TokenGenerator(serviceProvider.GetRequiredService<ILogger<TokenGenerator>>(), serviceProvider.GetRequiredService<IConfiguration>());
            });
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer((x) =>
                {
                    try
                    {
                        var config = JwtConfiguration.GetConfiguration(builder.Configuration);

                        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                        {
                            IssuerSigningKey = new SymmetricSecurityKey(config.Key),
                            ValidIssuer = config.Issuer,
                            ValidAudience = config.Audience,
                            ValidateAudience = true,
                            ValidateIssuer = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true
                        };

                    }
                    catch (Exception ex)
                    {
                        Log.Fatal(ex, ex.Message);
                        throw;
                    }
                });

            var app = builder.Build();

            // Apply migrations on startup
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
                dbContext.Database.Migrate();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
