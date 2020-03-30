using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using labnet.EntityFramework;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace labnet
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(AzureADB2CDefaults.AuthenticationScheme)
              .AddAzureADB2C(options => Configuration.Bind("AzureAdB2C", options));

            var connection = Configuration["DatabaseConnectionString"];
			services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddApplicationInsightsTelemetry();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info
            //    {
            //        Title = "labnet",
            //        Version = "v1",
            //        Description = "Swagger example",
            //        Contact = new Contact
            //        {
            //            Name = "Zhanna Solobchuk",
            //            Email = "solobchuk.zhanna@gmail.com"
            //        }
            //    });
            //    // Set the comments path for the Swagger JSON and UI.
            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    c.IncludeXmlComments(xmlPath);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            //Enable middleware to serve generated Swagger as a JSON endpoint.
            //app.UseSwagger();
         

            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            //// specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "labnet API v1");
                
            //});


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        


        }

        //public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
        //{
        //    public void Apply(Operation operation, OperationFilterContext context)
        //    {
        //        var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
        //        var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeFilter);
        //        var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);

        //        if (isAuthorized && !allowAnonymous)
        //        {
        //            if (operation.Parameters == null)
        //                operation.Parameters = new List<IParameter>();

        //            operation.Parameters.Add(new NonBodyParameter
        //            {
        //                Name = "Authorization",
        //                In = "header",
        //                Description = "access token",
        //                Required = true,
        //                Type = "string"
        //            });
        //        }
        //    }
        }
}
