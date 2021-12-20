using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using RocketApi.Models;

namespace RocketApi
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
            services.AddCors(policy => policy.AddPolicy("Policy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddControllers();
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var serverVersion = new MySqlServerVersion(new System.Version(8, 0, 27));
            services.AddDbContext<ApplicationContext>(options =>
            options.UseMySql(connectionString, serverVersion));

            var connectionStringPg = Configuration.GetConnectionString("PostgreSQLConnection");
            services.AddDbContext<SecondApplicationContext>(options =>
            options.UseNpgsql(connectionStringPg));

        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("Policy");


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
