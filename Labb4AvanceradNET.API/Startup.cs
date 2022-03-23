using Labb4AvanceradNET.API.Models;
using Labb4AvanceradNET.API.Services;
using Labb4AvanceradNET.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Labb4AvanceradNET.API.API
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
            services.AddControllers();

            services.AddDbContext<ProgramDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("UserContextConnection")));

            //services AddScoped
            services.AddScoped<IProgramRepository<User>, UserRepository>();
            services.AddScoped<IProgramRepository<Interest>, InterestRepository>();
            services.AddScoped<IProgramRepository<Website>, WebsiteRepository>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
