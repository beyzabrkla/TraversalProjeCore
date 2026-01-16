using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using Serilog;
using Serilog.Events;
using System.IO;
using TraversalProjeCore.CQRS.Handlers.DestinationHandlers;
using TraversalProjeCore.Models;

var builder = WebApplication.CreateBuilder(args);


// === SERILOG İLE DOSYA LOGLAMA KONFİGÜRASYONU ===
// 1. Serilog Logger'ı oluştur.
Log.Logger = new LoggerConfiguration()
    // Uygulamanın kendi logları için en düşük seviyeyi Debug olarak ayarla.
    .MinimumLevel.Debug()

    // SİSTEM LOGLARINI FİLTRELEME: Microsoft'tan gelen detay loglarını kes. 
    // Sadece Warning (Uyarı) ve üzeri seviyeleri kaydet.
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)

    // (Opsiyonel) Eğer EF Core'dan da çok log geliyorsa, onu da Warning seviyesine çekebilirsin.
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)

    .WriteTo.Console()  // Logları konsola da yaz (Bu kısım yerinde kalabilir)
    .WriteTo.File(      // Logları dosyaya yazma konfigürasyonu
        Path.Combine(Directory.GetCurrentDirectory(), "Logs", "log.txt"),
        rollingInterval: RollingInterval.Day, // Her gün yeni bir dosya oluştur
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

// 2. ASP.NET Core'un kendi loglama sistemini Serilog ile değiştir.
builder.Host.UseSerilog();


// === SERVİS KAYDI (SERVICES) ===

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddHttpClient();

builder.Services.ContainerDependencies();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllersWithViews(config =>
{
    // Global Authorization Policy
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddScoped<GetAllDestinationQueryHandler>();

OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

var app = builder.Build();


// === İSTEK BORU HATTI (PIPELINE) ===

// Uygulama kapanırken Log.CloseAndFlush() çağrısını garanti eder.
app.Lifetime.ApplicationStopped.Register(Log.CloseAndFlush);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

//Kimlik doğrulama, yetkilendirmeden önce çalışmalıdır.
app.UseAuthentication();
app.UseAuthorization();

// Alan (Area) Rotası (Eski UseEndpoints içindeki rota)
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets(); // Özel varlık haritalama metodu


app.Run();