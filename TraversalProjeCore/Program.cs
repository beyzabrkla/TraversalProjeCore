using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using TraversalProjeCore.Models;

var builder = WebApplication.CreateBuilder(args);

// === SERVİS KAYDI (SERVICES) ===
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>(); //Özel doğrulayıcı ekledik

builder.Services.AddControllersWithViews(config =>
{
    // Global Authorization Policy
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});


var app = builder.Build();

// === İSTEK BORU HATTI (PIPELINE) ===
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Eğer statik dosya kullanıyorsanız (CSS, JS) bunu ekleyin
app.UseRouting();

//Kimlik doğrulama, yetkilendirmeden önce çalışmalıdır.
app.UseAuthentication();
app.UseAuthorization();

// Alan (Area) Rotası (Eski UseEndpoints içindeki rota)
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapStaticAssets(); // Özel varlık haritalama metodu
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets(); // Özel varlık haritalama metodu


app.Run();