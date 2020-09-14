using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomodoro.DAL;
using Pomodoro.DAL.Interfaces;
using Pomodoro.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Pomodoro
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddControllers();

            services.AddDbContext<PomodoroDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PomodoroConnection"), x => x.MigrationsAssembly("Pomodoro.DAL")));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPomodoroService, PomodoroService>();
            services.AddScoped<IDictionaryService, DictionaryService>();

            services.AddAutoMapper(typeof(Startup));

            //services.AddCors(); // Make sure you call this previous to AddMvc
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
            app.UseCors("AllowSpecificOrigin");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
