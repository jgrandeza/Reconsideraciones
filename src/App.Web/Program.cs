using System.Globalization;
using App.Data;
using App.Services.IServices;
using App.Services.Services;
using App.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager Configuration = builder.Configuration;
// Add services to the container.
builder.Services.Configure<FormOptions>(x =>
{

    x.ValueLengthLimit = int.MaxValue; // Limit on individual form values
    x.MultipartBodyLengthLimit = int.MaxValue; // Limit on form body size
    x.MultipartHeadersLengthLimit = int.MaxValue; // Limit on form header size
});
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = int.MaxValue;  //2GB
});
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContextApp>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
//builder.Services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
builder.Services.Configure<SchemaOracle>(Configuration.GetSection("SchemaOracle"));
builder.Services.Configure<FTPSettings>(Configuration.GetSection("FTPSettings"));
builder.Services.Configure<URLReadFile>(Configuration.GetSection("URLReadFile"));
builder.Services.Configure<Auth>(Configuration.GetSection("Auth"));
builder.Services.AddTransient<IFileUploadFTP, FileUploadFTP>();
builder.Services.AddTransient<IReadSolicitudRecon, RecSolicitud>();
builder.Services.AddTransient<IAuxiliares, Serv_Auxiliares>();
builder.Services.AddTransient<IMaestros, Serv_Maestros>();
builder.Services.AddTransient<IResumenRec, Serv_ResumenRec>();
builder.Services.AddTransient<ISELReconsideraciones, Serv_SELReconsideraciones>();
builder.Services.AddTransient<IINSReconsideraciones, Serv_INSReconsideraciones>();
builder.Services.AddTransient<IUPDReconsideraciones, Serv_UPDReconsideraciones>();
builder.Services.AddTransient<IDELReconsideraciones, Serv_DELReconsideraciones>();
builder.Services.AddTransient<ISELSiasis, Serv_SELSiasis>();
builder.Services.AddTransient<IValRcRvRecosideraciones, Serv_ValRcRvRecosideraciones>();
builder.Services.AddTransient<IRptReconsideraciones, Serv_RptReconsideraciones>();

builder.Services.AddCors(o => o.AddPolicy("AllowAllOrigins", builder =>
{
    builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
}));
builder.Services.AddMvc(m => m.EnableEndpointRouting = false);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//Idioma y moneda
var cultureInfo = new CultureInfo("es-PE");
cultureInfo.NumberFormat.CurrencySymbol = "S/.";

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

