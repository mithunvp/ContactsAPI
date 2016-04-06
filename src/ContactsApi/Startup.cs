using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ContactsApi.Repository;
using Newtonsoft.Json.Serialization;

namespace ContactsApi
{
    public class Startup
    {        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                    .AddApiExplorer()
                    .AddJsonFormatters(a => a.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddSwaggerGen();
            services.AddSingleton<IContactsRepository, ContactsRepository>();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();
            app.UseMvc();

            app.UseSwaggerGen();
            app.UseSwaggerUi();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
