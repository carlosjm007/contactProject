using ContactProject.Context;
using ContactProject.Models;
using ContactProject.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactProject
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
            services.AddSingleton<IContactService, ContactService>();
            services.AddSingleton<IMongoContactContext, MongoContactContext>();
            services.AddSingleton(s =>
            {
                var mongoClient = new MongoClient(Configuration.GetSection("ContactDatabaseSettings")
                    .GetSection("ConnectionString").Value);
                var database = mongoClient.GetDatabase(Configuration.GetSection("ContactDatabaseSettings")
                    .GetSection("DatabaseName").Value);
                return database.GetCollection<ContactModel>(Configuration.GetSection("ContactDatabaseSettings")
                    .GetSection("CollectionName").Value);
            });
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
