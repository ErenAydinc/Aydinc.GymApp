using Starterkit._keenthemes;
using Starterkit._keenthemes.libs;
using Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.Localization.WebApi;
using Core.Persistence.WebApi;
using Core.Security;
using Core.Security.Encryption;
using Core.Security.JWT;
using Core.WebAPI.Extensions.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Infrastructure;
using Persistence;
using Microsoft.IdentityModel.Tokens;
using WebMVC;
using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices();
builder.Services.AddSecurityServices<int, int>();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IKTTheme, KTTheme>();
builder.Services.AddSingleton<IKTBootstrapBase, KTBootstrapBase>();
IConfiguration themeConfiguration = new ConfigurationBuilder()
                            .AddJsonFile("_keenthemes/config/themesettings.json")
                            .Build();

IConfiguration iconsConfiguration = new ConfigurationBuilder()
                            .AddJsonFile("_keenthemes/config/icons.json")
                            .Build();

KTThemeSettings.init(themeConfiguration);
KTIconsSettings.init(iconsConfiguration);

const string tokenOptionsConfigurationSection = "TokenOptions";
TokenOptions tokenOptions =
    builder.Configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>()
    ?? throw new InvalidOperationException($"\"{tokenOptionsConfigurationSection}\" section cannot found in configuration.");
builder
    .Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie()
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = $"X-Access-Token"; // todo : deðiþtirin.
    options.IdleTimeout = TimeSpan.FromMinutes(180);
    options.Cookie.IsEssential = true;
});
builder.Services.AddDistributedMemoryCache(); // InMemory
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(opt =>
    opt.AddDefaultPolicy(p =>
    {
        _ = p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    })
);

builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 10;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;

});

var app = builder.Build();
app.Use(async (context, next) =>
    {
        await next();
        if (context.Response.StatusCode == 404)
        {
            context.Request.Path = "/not-found";
            await next();
        }
    });

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//if (app.Environment.IsProduction())
//    app.ConfigureCustomExceptionMiddleware();
if (app.Environment.IsDevelopment())
    app.ConfigureCustomExceptionMiddleware();
_ = app.UseDbMigrationApplier();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseThemeMiddleware();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboards}/{action=Index}/{id?}");

const string webApiConfigurationSection = "WebAPIConfiguration";
WebApiConfiguration webApiConfiguration =
    app.Configuration.GetSection(webApiConfigurationSection).Get<WebApiConfiguration>()
    ?? throw new InvalidOperationException($"\"{webApiConfigurationSection}\" section cannot found in configuration.");
app.UseCors(opt => opt.WithOrigins(webApiConfiguration.AllowedOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials());

app.UseResponseLocalization();
app.Run();
