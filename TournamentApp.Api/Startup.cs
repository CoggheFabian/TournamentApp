using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TournamentApp.Model;
using TournamentApp.Model.ConfigManager;
using TournamentApp.Repositories.Implementation.MatchRepo;
using TournamentApp.Repositories.Implementation.RoundRepo;
using TournamentApp.Repositories.Implementation.TournamentRepo;
using TournamentApp.Repositories.Implementation.UserRepo;
using TournamentApp.Repositories.Implementation.UserTournamentRepo;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Services.Config;
using TournamentApp.Services.MatchService;
using TournamentApp.Services.RoundService;
using TournamentApp.Services.TournamentRoundService;
using TournamentApp.Services.TournamentService;
using TournamentApp.Services.UserService;

namespace TournamentApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TournamentDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "TournamentApp.Api", Version = "v1"});
            });

            services.AddScoped<ITournamentRepository, TournamentRepository>();
            services.AddTransient<ITournamentService, TournamentService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddScoped<ITournamentRoundService, TournamentRoundService>();

            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddTransient<IMatchService, MatchService>();

            services.AddScoped<IUserTournamentRepository, UserTournamentRepository>();

            services.AddScoped<IRoundRepository, RoundRepository>();
            services.AddTransient<IRoundService, RoundService>();

            services.AddSingleton<IDbConfigManager, DbConfigManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TournamentApp.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}