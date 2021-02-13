using InternalDslTaskManagement.Builder;
using InternalDslTaskManagement.Builder.Interfaces;
using InternalDslTaskManagement.Dsl;
using InternalDslTaskManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InternalDslTaskManagement
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
            // https://andrewlock.net/how-to-register-a-service-with-multiple-interfaces-for-in-asp-net-core-di/
            services.AddSingleton<TaskBuilder>();
            services.AddSingleton<IRootBuilder, RootBuilder>();
            services.AddSingleton<ITaskBuilder>(x => x.GetRequiredService<TaskBuilder>());
            services.AddSingleton<ITaskBuilderService>(x => x.GetRequiredService<TaskBuilder>());
            services.AddSingleton<ILabelBuilder, LabelBuilder>();
            services.AddSingleton<ICommentBuilder, CommentBuilder>();

            services.AddSingleton<ITaskRepository, TaskRepository>();
            services.AddSingleton<ILabelRepository, LabelRepository>();

            services.AddSingleton<MdsdHomework>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            ;
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

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}