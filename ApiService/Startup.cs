using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiService.Data;
using ApiService.Models;
using ApiService.Models.Interfaces;
using ApiService.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ApiService {
    public class Startup {
        
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<DataContext>();
            services.AddScoped<IAuthRepo, AuthRepo>();
            services.AddTransient<IUserRepo, UserRepo>();

            // 01.09.2020 - Tryig the supplier repo
            //services.AddTransient<ILoadentRepo<Supplier>, SupplierRepo>();
            services.AddTransient<ISupplierRepo, SupplierRepo>();

            services.AddAutoMapper(typeof(UserRepo).Assembly);
            // Tell automapper what assembly to get the mapping profiles from
            // That is THIS assembly, so use the class we created with the masps
            //services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddControllersWithViews().AddNewtonsoftJson(opt => {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            // Added this!!!
            //services.AddCors();
            // 01.31.2021
            services.AddCors(options => {

                options.AddDefaultPolicy(defaultBuilder => {
                    defaultBuilder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });

                options.AddPolicy("ErpApiCorsPolicy",
                                  builder => {
                                      builder.AllowAnyOrigin()
                                             .AllowAnyMethod()
                                             .AllowAnyHeader();
                                  });

            });

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Erp.Api", Version = "v1" }) );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json","Erp.Api v1"));
            } else {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Erp.Api v1"));
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // REMOVED THIS TO TEST
            //app.UseStaticFiles();

            // ADDED THIS CORS
            //app.UseCors(X509EncryptingCredentials => X509EncryptingCredentials.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            // 01.31.2021
            app.UseCors();


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

        }

        // /////////////////////////////////

        /*
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<DataContext>();
            services.AddTransient<IAuthRepo, AuthRepo>();
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddAutoMapper(typeof(UserRepo).Assembly);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => {
                        options.TokenValidationParameters = new TokenValidationParameters {
                            ValidateIssuer = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                            ValidateAudience = true
                        };
                    });
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson();
            //services.AddControllers();
            //services.AddControllersWithViews().AddNewtonsoftJson(OptionsBuilderConfigurationExtensions => {
            //    OptionsBuilderConfigurationExtensions.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            //app.UseCors(X509EncryptingCredentials => X509EncryptingCredentials.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }


        */
    }
}
