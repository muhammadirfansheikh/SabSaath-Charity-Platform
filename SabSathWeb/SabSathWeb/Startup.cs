using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SabSath.Application.Repositiories;
using SabSath.Data.DataRepository;

namespace SabSathWeb
{
    public class Startup
    {
        private const string DefaultCorsPolicyName = "localhost";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddMvc();//.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddControllers();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserDataDapperRepository, UserDataDapperRepository>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<ISecurityDataDapperRepository, SecurityDataDapperRepository>();
            services.AddScoped<ISetupService, SetupService>();
            services.AddScoped<ICompanyServices, CompanyServices>();
            services.AddScoped<ISetupDataDapperRepository, SetupDataDapperRepository>();
            services.AddScoped<ICompanyDataDapperRepository, CompanyDataDapperRepository>();
            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<IPaymentServices, PaymentServices>();
            services.AddScoped<IApplicantDataDapperRepository, ApplicantDataDapperRepository>();
            services.AddScoped<IPaymentDataDapperRepository, PaymentDataDapperRepository>();
            services.AddScoped<IReportingService, ReportingServices>();
            services.AddScoped<IReportingDataDapperRepository, ReportingDataDapperRepository>();

            services.AddScoped<IWebSiteDataDapperRepository, WebSiteDataDapperRepository>();

            services.AddScoped<IWebSiteService, WebSiteService>();

            services.AddScoped<IDashBoardDataDapperRepository, DashBoardDataDapperRepository>();

            services.AddScoped<IDashboardService, DashboardService>();


            services.AddResponseCaching();

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
            #region Cors








            string corsOriginsSettings = Configuration["App:CorsOrigins"];
            //Configure CORS for angular2 UI
            services.AddCors(options =>
            {
                //options.AddPolicy(DefaultCorsPolicyName, builder =>
                //{
                //    //App:CorsOrigins in appsettings.json can contain more than one address with splitted by comma.
                //    builder.AllowAnyOrigin()
                //        .AllowAnyHeader()
                //        .AllowAnyMethod()
                //        //.AllowCredentials()
                //        .SetPreflightMaxAge(TimeSpan.FromSeconds(10));

                //});
                //options.AddPolicy("Security",
                //  builder => builder.WithOrigins("http://localhost", "http://localhost:3000", "http://localhost:3001", "http://localhost:49596", "http://localhost:50489",
                //  "http://192.168.61.35:3000", "http://124.29.235.10:3000", "http://192.168.61.32:5000" , "http://192.168.61.32:5001",
                //   "http://192.168.61.233:80", "http://124.29.235.14:80", "https://124.29.235.14:443", "https://api.sabsaath.org", "http://api.sabsaath.org", "http://www.api.sabsaath.org", "https://www.api.sabsaath.org", "http://www.sabsaath.org", "https://sabsaath.org", "https://www.sabsaath.org", "http://00.00.00.00", "http://124.29.235.8:5000" , "http://192.168.61.32:9182" , "http://124.29.235.8:5001" , "http://124.29.235.8:9182",
                //  "http://192.168.61.35:3000", "http://124.29.235.10:3000", "http://192.168.61.32:5000" , "http://192.168.61.32:5001", "http://192.168.61.233:80", "http://192.168.61.233:443", "http://192.168.61.233:1000", "http://124.29.235.14:80", "https://124.29.235.14:443", "https://124.29.235.14:1000", "https://api.sabsaath.org", "http://api.sabsaath.org", "http://www.api.sabsaath.org", "https://www.api.sabsaath.org", "http://www.sabsaath.org", "https://sabsaath.org", "https://www.sabsaath.org", "http://00.00.00.00", "http://124.29.235.8:5000" , "http://192.168.61.32:9182", "http://192.168.61.32:4001", "http://124.29.235.8:5001", "http://124.29.235.8:4001", "http://192.168.61.32:9183", "http://124.29.235.8:9182", "http://sabsaath.org/", "http://124.29.235.8:9183").AllowAnyHeader()
                //  .AllowAnyMethod().AllowAnyOrigin()

                //  );

                //options.AddPolicy("Security",
                //  builder => builder.WithOrigins("http://localhost", "http://localhost:3000", "http://localhost:3001", "http://localhost:49596", "http://localhost:50489",
                //  "http://192.168.61.35:3000", "http://124.29.235.10:3000", "http://192.168.61.32:5000", "http://192.168.61.32:5001", "http://192.168.61.233:80", "http://124.29.235.14:80", "https://124.29.235.14:443", "https://api.sabsaath.org", "http://api.sabsaath.org", "http://www.api.sabsaath.org", "https://www.api.sabsaath.org", "http://www.sabsaath.org", "https://sabsaath.org", "https://www.sabsaath.org", "http://00.00.00.00", "http://124.29.235.8:5000", "http://192.168.61.32:9182", "http://192.168.61.32:4001", "http://124.29.235.8:5001", "http://124.29.235.8:4001", "http://192.168.61.32:9183", "http://124.29.235.8:9182", "http://124.29.235.8:9183", "http://124.29.235.8:443").AllowAnyHeader()
                //  .AllowAnyMethod().AllowAnyOrigin()

                //  );

                options.AddPolicy("Security",
                builder => builder.WithOrigins("http://localhost", "http://localhost:3000", "http://localhost:3001", "http://localhost:49596", "http://localhost:50489",
                "http://192.168.61.35:3000", "http://124.29.235.10:3000", "http://192.168.61.32:5000", "http://192.168.61.32:5001", "http://192.168.61.233:80", "http://124.29.235.14:80", "https://124.29.235.14:443", "https://api.sabsaath.org", "http://api.sabsaath.org", "http://www.api.sabsaath.org", "https://www.api.sabsaath.org", "http://www.sabsaath.org", "https://sabsaath.org", "https://www.sabsaath.org", "http://00.00.00.00", "http://124.29.235.8:5000", "http://192.168.61.32:9182", "http://192.168.61.32:4001", "http://124.29.235.8:5001", "http://124.29.235.8:4001", "http://192.168.61.32:9183", "http://124.29.235.8:9182", "http://124.29.235.8:9183", "http://124.29.235.8:443", "http://124.29.235.14:10001", "http://124.168.61.233:10001").AllowAnyHeader()
                .AllowAnyMethod().AllowAnyOrigin()

                );

            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseCors("Security");
            //}
            // app.UseMvc();
            app.UseStaticFiles();
            app.UseCors("Security");
            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseCors(DefaultCorsPolicyName); //Enable CORS!
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Ui}/{action=Index}/{id?}");

            });
        }
    }
}
