using ChatGptNet;
using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using DevExpress.Office.Services.Implementation;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports.Security;
using fincheckup.Models; 
using fincheckup.Models.Hvvn;
using fincheckup.Services;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace fincheckup
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        //public class RedirectToWwwRule : IRule
        //{
        //    public virtual void ApplyRule(RewriteContext context)
        //    {
        //        var req = context.HttpContext.Request;
        //        if (req.Host.Host.Equals("localhost", StringComparison.OrdinalIgnoreCase))
        //        {
        //            context.Result = RuleResult.ContinueRules;
        //            return;
        //        }

        //        if (req.Host.Value.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
        //        {
        //            context.Result = RuleResult.ContinueRules;
        //            return;
        //        }

        //        var wwwHost = new HostString($"{req.Host.Value}");
        //        var newUrl = UriHelper.BuildAbsolute(req.Scheme, wwwHost, req.PathBase, req.Path, req.QueryString);
        //        var response = context.HttpContext.Response;
        //        response.StatusCode = 301;
        //        response.Headers[HeaderNames.Location] = newUrl;
        //        context.Result = RuleResult.EndResponse;
        //    }
        //}
        public static IAiModelConnect FooServiceInstance { get; private set; }
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            Database.ConnectionString = connectionString;
            services.AddSession(opts =>
            {
                opts.Cookie.IsEssential = true;
                opts.IdleTimeout = TimeSpan.FromMinutes(30);
                opts.Cookie.MaxAge = TimeSpan.FromDays(360);
                opts.Cookie.HttpOnly = true;
            });
            services.AddMvc(options => options.EnableEndpointRouting = false).AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddMemoryCache();

            services.AddSingleton<IWzoneSWRService, WzoneSWRService>();
            services.AddSingleton<IWChkWordSWRService, WChkWordSWRService>();
            services.AddSingleton<IWChkSWRService, WChkSWRService>();
            services.AddSingleton<IWzonerSWRService, WzonerSWRService>();
            //services.AddSingleton<WzoneSWRService>();
            //services.AddSingleton<WChkWordSWRService>();
            //services.AddSingleton<WChkSWRService>(); 
            services.AddAuthentication(options =>
            {

                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/index";
                options.LogoutPath = "/LogOut";
                options.ExpireTimeSpan = TimeSpan.FromDays(365);
                options.Cookie.MaxAge = TimeSpan.FromDays(365);
                options.SlidingExpiration = false;

            });
            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = int.MaxValue; // if don't set    default value is: 30 MB
            });
            //services.Configure<IISServerOptions>(options =>
            //{
            //    options.MaxRequestBodySize = int.MaxValue; // or your desired value
            //});
            //services.AddScoped<IMyService, IAiModelConnect>();
            services.AddSingleton<IAiModelConnect>();
            services.AddRefitClient<IUploadFileApi>()
           .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://10.242.3.20:200"));
            services.Configure<FormOptions>(x =>
            {
              
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
                x.MultipartBoundaryLengthLimit = int.MaxValue;
                x.MultipartHeadersCountLimit = int.MaxValue;
                x.MultipartHeadersLengthLimit = int.MaxValue;
            });
            // Adds ChatGPT service using settings from IConfiguration.
            services.AddChatGpt(Configuration,
                httpClient =>
                {
                    // Configures retry policy on the inner HttpClient using Polly.
                    httpClient.AddStandardResilienceHandler(options =>
                    {
                        options.AttemptTimeout.Timeout = TimeSpan.FromMinutes(1);
                        options.CircuitBreaker.SamplingDuration = TimeSpan.FromMinutes(3);
                        options.TotalRequestTimeout.Timeout = TimeSpan.FromMinutes(3);
                    });
                });

            //ReminderAccountPut rn = new ReminderAccountPut();
            //rn.id = 1;
            //rn.accountGroupId = 3;
            //rn.name = "A2-Ticari Alacaklarzz";
            //rn.accountType = AccountType.RevenueType;
            //rn.startValue = 12;
            //rn.finishValue = 12;

            //ApiWarnConnect nnn = new ApiWarnConnect();
            //var chk = nnn.PutAccount(rn);
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/index";
                options.SlidingExpiration = true;
            });
            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = 209715200;
            });

            //services.Configure<IISServerOptions>(options =>
            //{
            //    options.AllowSynchronousIO = true;
            //});
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.ExpireTimeSpan = TimeSpan.FromDays(365);
            //});


            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddControllers();
            services.AddDevExpressControls(); 
            services
                .AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
 
            services.ConfigureReportingServices(configurator =>
            {
                configurator.ConfigureWebDocumentViewer(viewerConfigurator =>
                {
                    viewerConfigurator.UseCachedReportSourceBuilder();
                });
            });

            services.AddAuthentication(
      CertificateAuthenticationDefaults.AuthenticationScheme)
      .AddCertificate();
            services.AddAntiforgery(options =>
            {
                options.Cookie.Expiration = TimeSpan.FromHours(1);
            });
            //services.AddControllersWithViews();
            services.AddRouting(options => options.LowercaseUrls = true);
           
            services.AddDataProtection();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowCorsPolicy", builder =>
                {
                    builder
                        .WithOrigins(
                            "https://dkweb.fincheckup.ai",
                            "https://dkmobile.fincheckup.ai",
                            "http://localhost:8085",
                            "http://localhost:8086"
                        )
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });
            services.AddSingleton<IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
            services.AddIdentityCore<HhvnUsers>();
            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/");
                    options.Conventions.AuthorizeFolder("/Admin");
                    options.Conventions.AuthorizeFolder("/Transaction");
                    options.Conventions.AllowAnonymousToPage("/Index");
                    options.Conventions.AllowAnonymousToPage("/sso");
                    options.Conventions.AllowAnonymousToPage("/ssoconsult");
                    options.Conventions.AllowAnonymousToPage("/LoginArea");
                    options.Conventions.AllowAnonymousToPage("/masterkobi");
                    options.Conventions.AllowAnonymousToPage("/Login");
                    options.Conventions.AllowAnonymousToPage("/EnableAuthenticator");
                    options.Conventions.AllowAnonymousToPage("/LoginWith2fa");
                    options.Conventions.AllowAnonymousToPage("/gizlilik");
                    options.Conventions.AllowAnonymousToPage("/about");
                    options.Conventions.AllowAnonymousToPage("/kullanici");
                    options.Conventions.AllowAnonymousToPage("/contact");
                    options.Conventions.AllowAnonymousToPage("/kvkk");
                    options.Conventions.AllowAnonymousToPage("/cozumlerimiz");
                    options.Conventions.AllowAnonymousToPage("/payment");
                    options.Conventions.AllowAnonymousToPage("/pageget");
                    options.Conventions.AllowAnonymousToPage("/dijitalkopru");
                    options.Conventions.AllowAnonymousToPage("/urunlerimiz");
                     options.Conventions.AllowAnonymousToPage("/masterkobipack");
                    options.Conventions.AllowAnonymousToPage("/Request3D");
                    options.Conventions.AllowAnonymousToPage("/CancelUrl");
                    options.Conventions.AllowAnonymousToPage("/SuccessUrl");
                    //options.Conventions.AllowAnonymousToPage("/project");
                    //options.Conventions.AllowAnonymousToPage("/contact");

                });
            services.ConfigureApplicationCookie(options => { options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None; });

   

        }
        public class CustomResponseHeaderMiddleware
        {
            private readonly RequestDelegate _next;

            public CustomResponseHeaderMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            //public async Task Invoke(HttpContext context)
            //{
            //    //To add Headers AFTER everything you need to do this
            //    context.Response.OnStarting(state =>
            //    {
            //        var httpContext = (HttpContext)state;
            //        httpContext.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000");
            //        httpContext.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            //        httpContext.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
            //        httpContext.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
            //        //... and so on
            //        return Task.CompletedTask;
            //    }, context);

            //    await _next(context);
            //}
        } 
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IAiModelConnect fooService) 
        {
            FooServiceInstance = fooService;
            ScriptPermissionManager.GlobalInstance = new ScriptPermissionManager(ExecutionMode.Unrestricted);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Error");
                app.UseHsts(options =>
                {
                    options.MaxAge(days: 365).IncludeSubdomains().Preload();
                });

            }

            //app.UseDeveloperExceptionPage();
            app.UseDevExpressControls();
            //app.UseCsp(options =>
            //{

            //    options.UpgradeInsecureRequests();
            //    options.BlockAllMixedContent()
            //    .ScriptSources(s =>
            //    {
            //        s.Self().CustomSources("https://www.google.com/recaptcha/api.js", "https://www.gstatic.com/recaptcha/", "https://ssl.gstatic.com", "https://www.googletagmanager.com/gtag/", "https://ajax.aspnetcdn.com/");

            //        // Force hashes into custom sources. Can't be done with CustomSources(...)
            //        // because CustomSources(...) checks if strings are uris
            //        //s.CustomSources = s.CustomSources.Concat(new[] { "'sha256-...='" });
            //    })
            //    .ScriptSources(s =>
            //    {
            //        s.UnsafeInline();

            //    })
            //      .ScriptSources(s =>
            //      {
            //          s.UnsafeEval();

            //      })
            //    .StyleSources(s => s.Self())
            //    .StyleSources(s => s.UnsafeInline())
            //    .FontSources(s => s.Self())
            //    .FormActions(s => s.Self())
            //    .FrameAncestors(s => s.Self())
            //    .ImageSources(s => s.Self().CustomSources("https://www.googletagmanager.com/gtag/","data:"))
            //    .FrameSources(f =>
            //     {
            //         f.SelfSrc = true;
            //         f.Self().CustomSources("https://www.google.com/recaptcha/",
            //             "https://www.gstatic.com/recaptcha/", "https://www.google.com/maps/");
            //     });

            //});


            app.UseXfo(option =>
            {
                option.Deny();
            });
            app.UseXXssProtection(option =>
            {
                option.EnabledWithBlockMode();
            });
            app.UseXContentTypeOptions();
            app.UseDeveloperExceptionPage();
            //app.UseReferrerPolicy(opts => opts.NoReferrer());
            //var options = new RewriteOptions();
            //app.UseMiddleware(typeof(CustomResponseHeaderMiddleware));

            var supportedCultures = new List<CultureInfo>
            {
            new CultureInfo("tr-TR"),
            new CultureInfo("en-US"),
            };
            //app.UseXXssProtection(options => options.EnabledWithBlockMode());

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                HttpOnly = HttpOnlyPolicy.Always,
                MinimumSameSitePolicy = SameSiteMode.Strict,
                Secure = CookieSecurePolicy.Always
            });

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                DefaultRequestCulture = new RequestCulture("tr-TR")

            });

            //app.Use(async (context, next) =>
            //{
            //    if (context.Response.Headers.All(x => x.Key != "Feature-Policy"))
            //        context.Response.Headers.Add("Feature-Policy", new[] { "accelerometer 'none'; camera 'none'; geolocation 'self'; gyroscope 'none'; magnetometer 'none'; microphone 'none'; payment 'none'; usb 'none'" });
            //    if (context.Response.Headers.All(x => x.Key != "Permissions-Policy"))
            //        context.Response.Headers.Add("Permissions-Policy", "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()");

            //    await next();


            //});


            //options.Rules.Add(new RedirectToWwwRule());
            //app.UseRewriter(options);
             app.UseHttpsRedirection();

            //app.UseAuthentication();
            //app.UseStaticFiles();
            //app.UseSession();
            //app.UseMvc();

            //app.UseHsts();
          
            app.UseSession();
            app.UseCors("AllowCorsPolicy");
            app.UseAuthentication();
            app.UseMvc();
            app.UseRouting();

            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
name: "areaRoute",
pattern: "{area:exists}/{controller}/{action}");

                endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

        }
    }
}
