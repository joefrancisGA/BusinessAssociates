using BusinessAssociate.API.BusinessAssociate;
using BusinessAssociates.EventStore;
using EGMS.BusinessAssociate.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BusinessAssociate.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //string connString = Configuration.GetConnectionString("EGMSBusinessAssociateConnection");
            //SessionFactory sessionFactory = new SessionFactory(connString);

            //services.AddSingleton(sessionFactory);
            //services.AddScoped<UnitOfWork>();
            services.AddControllers();
            //services.AddSingleton <IFactory<EGMSAssociatesContext>>();
            services.AddSingleton<EGMSAssociateRepository>();
            services.AddTransient<InternalAssociateCommandService>();

            services.AddSingleton(
                c =>
                    new InternalAssociateCommandService(
                        new EsAggregateStore(c.GetEsConnection())
                    )
            );
            //services.AddSingleton<BusinessAssociates.EventSourcing.ApplicationService<InternalAssociate>>();
            //services.AddDbContext<EGMSAssociate>(opt =>
            //opt.UseSqlServer(Configuration.GetConnectionString("EGMSBusinessAssociatesConnection"))
            //                                                 .EnableSensitiveDataLogging());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // ReSharper disable once UnusedMember.Global
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
