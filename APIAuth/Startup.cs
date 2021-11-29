//using APIAuth.Database;
//using EAMSWebAPI.Classi;
//using XpoSerialization.EAMS_OL_PA;
//using EAMSWebAPI.EAMS_OL_PA;
//using Microsoft.EntityFrameworkCore;
using APIAuth.Database;
using APIAuth.Modelli;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace APIAuth
{
    public class Startup
    {
        //private readonly ILogger _logger;
        public Startup(IConfiguration configuration)
        //public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            //_logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // da qui nuovo
            Configurazione.Stringaconnessione = Configuration.GetConnectionString("ConnectionString");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddDatabaseJsonOptions();   //.Add_APISIGAS_JsonOptions(); //  .AddEAMS_OL_PAJsonOptions();
            // .AddDxSampleModelJsonOptions();
            services.AddCors();
            services.AddXpoDefaultUnitOfWork(true, (DataLayerOptionsBuilder options) =>
                options.UseConnectionString(Configuration.GetConnectionString("ConnectionString"))
                // .UseAutoCreationOption(AutoCreateOption.DatabaseAndSchema) // debug only
                .UseEntityTypes(ConnectionHelper.GetPersistentTypes()));

            #region
            //services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);             //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            #endregion
            // Register the Swagger services
            //services.AddSwaggerDocument();
            // Register the Swagger services
            services.AddSwaggerDocument(configure =>
            {
                configure.ExcludedTypeNames = new string[] {
                    "DevExpress.Xpo.XPObject",
                    "DevExpress.Xpo.XPCustomObject",
                    "DevExpress.Xpo.XPLiteObject",
                    "DevExpress.Xpo.XPBaseObject",
                    "DevExpress.Xpo.PersistentBase"
                    };

                configure.PostProcess = document =>
                {
                    document.Info.Version = "V 21.11.1";
                    document.Info.Title = "Protec Web API";
                    document.Info.Description = "";
                    document.Info.TermsOfService = "Protec srl";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Protec srl",
                        Email = "protec@protecsrl.biz",
                        Url = "https://protecsrl.biz"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://protecsrl.biz"
                    };
                    document.BasePath = "/"; //PlatformServices.Default.Application.ApplicationBasePath;

                    document.Host = "http://notifichesms.protecsrl.biz/";
                    NSwag.OpenApiServer _Server = new NSwag.OpenApiServer
                    {
                        Url = "http://notifichesms.protecsrl.biz", //" https://development.gigantic-server.com/v1 ",
                        Description = " Server di sviluppo "
                    };
                    document.Servers.Add(_Server);

                };
            });

            //_logger.LogInformation("Added TodoRepository to services");

            //////////
            services.AddMvc(options => options.EnableEndpointRouting = false);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            // qui
            if (env.IsDevelopment())
            {
                //_logger.LogInformation("In Development environment");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for 
                // production scenarios, see https://aka.ms/aspnetcore-hsts
                app.UseHsts();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            #region Configurazione 
            Configurazione.StringaClient = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[1].ToString(); //ExtractProto(HttpRequest request);
            #endregion

            #region app USE PROVA
            //app.Run(async context =>
            //{
            //    string path = ExtractHost(context);

            //    if (!BasicAuthenticationAttribute.IsAutenticate(context.Request))
            //    {
            //        await context.Response.WriteAsync("Hello, World!");// return GetNewRdLNotFound();
            //    }
            //    //await context.Response.WriteAsync("Hello, World!");
            //});

            //app.Use(async (context, next) =>
            //{
            //    try
            //    {
            //        // Request method, scheme, and path
            //        _logger.LogDebug("Request Method: {Method}", context.Request.Method);
            //        _logger.LogDebug("Request Scheme: {Scheme}", context.Request.Scheme);
            //        _logger.LogDebug("Request Path: {Path}", context.Request.Path);

            //        // Headers
            //        foreach (var header in context.Request.Headers)
            //        {
            //            _logger.LogDebug("Header: {Key}: {Value}", header.Key, header.Value);
            //        }

            //        // Connection: RemoteIp
            //        _logger.LogDebug("Request RemoteIp: {RemoteIpAddress}",
            //            context.Connection.RemoteIpAddress);
            //    }
            //    catch
            //    { }

            //    string aut = context.Request.Headers["Authorization"];
            //    if (!string.IsNullOrEmpty(aut))
            //    {
            //        if (!BasicAuthenticationAttribute.IsAutenticate(context.Request))
            //        {
            //            //context.Authentication.
            //            _logger.LogDebug("non connesso" );
            //        }
            //        else
            //        {
            //            _logger.LogDebug(" si connesso");

            //        }

            //    }

            //    await next();
            //});
            #endregion

            #region CONFIGURAZIONE SWAGGER
            // Register the Swagger generator and the Swagger UI middlewares
            #region PROVA DI USEAPI
            //app.UseOpenApi(config => config.PostProcess = (document, request) =>  // +		((Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo)((Microsoft.AspNetCore.Http.DefaultHttpContext)((Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest)request).HttpContext).Connection).LocalIpAddress	{127.0.0.1}	System.Net.IPAddress

            //{
            //    Console.WriteLine(ExtractHost(request));
            //});
            //#if DEBUG
            //            Debug.WriteLine("Mode=Debug");
            //#else
            //    Debug.WriteLine("Mode=Release"); 
            //#endif
            #endregion

#if DEBUG
            app.UseOpenApi(); // QUESTO è OBSOLETO[app.UseSwagger();]
            Console.WriteLine("Mode=Debug");
#else
            app.UseOpenApi(config => config.PostProcess = (document, request) =>
                        {
                            //Change document server settings to public// ExtractHost(request);
                          //  document.Host = "http://eams.engie.it/";
                            document.Host = "http://x-eams.engie.it/"; 
            
            //    base path
            //document.BasePath = "/apieams";// ExtractPath(request);   // ExtractPath(request);            /// @@@@@@  questo va cambiato in funzione del sito di destinazione di publicazione
                           // document.BasePath = "/apitest";
                            document.BasePath = "/apiunimoretest"; 

 
                        });
#endif
            app.UseSwaggerUi3();
            #endregion
            app.UseHttpsRedirection();
            app.UseMvc();




        }
    }
}
