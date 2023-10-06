using System.Net;
using AppMVC.ExtendMethods;
using AppMVC.Models;
using AppMVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

namespace AppMVC
{
    public class Startup
    {
        private readonly IConfiguration _Configuration;
        public static string ContentRootPath {get; set;}
        public Startup(IConfiguration configuration, IWebHostEnvironment evn)
        {
            _Configuration = configuration;
            
            ContentRootPath = evn.ContentRootPath;

        }

        public void ConfigureServices(IServiceCollection Services)
        {
            Services.AddControllersWithViews();
            Services.AddRazorPages();
            var mailSetting = _Configuration.GetSection("MailSetting");
            Services.Configure<MailSettings>(mailSetting);
            Services.AddSingleton<IEmailSender, SendMailService>();

            Services.AddSingleton(typeof(ProductService), typeof(ProductService));
            Services.AddSingleton(typeof(PlanetService), typeof(PlanetService));

            Services.AddOptions();
            
             Services.AddDbContext<AppDbContext>(options => {
                var connection = _Configuration.GetConnectionString("AppConnectionString");
                options.UseSqlServer(connection);
            });

            Services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            Services.Configure<IdentityOptions>(options =>{
                //// Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                // Default User settings.
                options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            Services.ConfigureApplicationCookie(options =>{
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.AccessDeniedPath = "/Denied";
            }); 

              Services.AddAuthentication().AddGoogle(options =>{
                var configGG = _Configuration.GetSection("Authentication:Google");
                options.ClientId = configGG["ClientId"];
                options.ClientSecret = configGG["ClientSecret"];
                options.CallbackPath = "/dang-nhap-google";
            });

            //Register IdentityErrorDescriber
            Services.AddSingleton<IdentityErrorDescriber, AppIdentityErrorDescriber>();


            // Add services to the container.
            
            // Services.Configure<RazorViewEngineOptions> (options => {
            //     options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
            // });

           
           
        }

        public void Configure(WebApplication app, IHostEnvironment evn)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.AddStatusCodePage();
            //app.UseStatusCodePages();
            
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthorization();

            // app.MapControllerRoute(
            //     name: "default",
            //     pattern: "{controller=Home}/{action=Index}/{id?}");
            // app.MapRazorPages();

            app.UseEndpoints(endpoints =>{
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                //app.MapRazorPages();

                endpoints.MapAreaControllerRoute(
                    name : "product",
                    pattern: "/{controller}/{action=Index}/{id?}",
                    areaName: "ProductManager"
                );

                endpoints.MapAreaControllerRoute(
                    name: "DbManage",
                    pattern: "/{controller}/{action=Index}",
                    areaName: "Database"
                );
            });
            app.Run();
        }
    }
}