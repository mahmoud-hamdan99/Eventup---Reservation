using EventReservation.Core.Common;
using EventReservation.Core.Helpers;
using EventReservation.Core.Repository;
using EventReservation.Core.Service;
using EventReservation.Infra.Common;
using EventReservation.Infra.Repository;
using EventReservation.Infra.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Stripe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.API
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
            services.AddCors(options => options.AddPolicy("CorePolicy", builder => {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddControllers();

            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICardService, Infra.Service.CardService>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILoctationService, LocationService>();

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventService, Infra.Service.EventService>();

            services.AddScoped<IAboutusRepository, AboutusRepository>();
            services.AddScoped<IAboutusService, AboutusService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped< IUserService, UserService > ();

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IWebsiteRepository, WebsiteRepository>();  
            services.AddScoped<IWebsiteService, WebsiteService>();


            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewService, Infra.Service.ReviewService>();

            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IDbContext, DbContext>();

            services.AddScoped<IContactusRepository, ContactusRepository>();
            services.AddScoped<IContactusService, ContactusService>();

            services.AddScoped<IHallRepository, HallRepository>();
            services.AddScoped<IHallService, HallService>();

            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<ITestimonialService, TestimonialService>();

            services.AddScoped<IChartRepository, ChartRepository>();
            services.AddScoped<IChartService, ChartService>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value))
                };
            });
           
        

            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe:Secretkey").Value;
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorePolicy");
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(ConfigurationPath.Combine(Directory.GetCurrentDirectory() + @"\Images")),
                RequestPath = new PathString("/Images")


            }); ;

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
