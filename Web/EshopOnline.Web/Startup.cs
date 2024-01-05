using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using EshopOnline.Infra.Data.Context;
using EshopOnline.Infra.IoC;

namespace EshopOnline.Web
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
            //services.AddSwaggerGen();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
             {
                 option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
                 option.AddSecurityRequirement(
                     new OpenApiSecurityRequirement
                     {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
                     }
                 );
             });

            #region IoC
            RegisterService(services);
            #endregion


            #region db context
            services.AddDbContext<EshopOnlineContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DbContext"));
            });
            #endregion

            services.AddControllers();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        #region IoC
        public static void RegisterService(IServiceCollection services)
        {
            DependencyContainer.RegisterService(services);
        }
        #endregion
    }
}
