using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Proxsure_API.Models;
using Proxsure_API.Models.Context;
using Proxsure_API.Models.SuscriptionModels;
using Proxsure_API.Models.Users;

namespace Proxsure_API {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddAutoMapper ();
            services.AddDbContext<ApplicationDbContext> (options => options.UseSqlServer (Configuration.GetConnectionString ("userDB")));

            services.AddScoped<ISuscriptionRepository, SuscriptionRepository> ();

            services.AddDefaultIdentity<ApplicationUser> (config => {
                    config.SignIn.RequireConfirmedEmail = true;
                })
                .AddRoles<IdentityRole> ()
                .AddEntityFrameworkStores<ApplicationDbContext> ()
                .AddDefaultTokenProviders ();

            services.AddAuthentication ("Bearer")
                .AddIdentityServerAuthentication (options => {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "Proxsure_API1";
                });

            services.AddCors ();

            services.AddMvcCore ()
                .AddAuthorization ()
                .AddJsonFormatters ();

            services.AddMvc ()
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
            }
            app.UseCors (
                builder => builder.WithOrigins ("http://localhost:4200")
                .AllowAnyHeader ()
            );
            app.UseAuthentication ();
            app.UseHttpsRedirection ();
            app.UseMvc ();
        }
    }
}