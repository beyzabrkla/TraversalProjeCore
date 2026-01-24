using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.Areas.Member.Controllers
{
    [Area("Member")]
    public class LanguageController : Controller
    {
        public IActionResult Index(string culture, string returnUrl)
        {
            // Dili tarayıcı çerezi (cookie) olarak kaydet
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            // Kullanıcıyı kaldığı sayfaya geri gönder
            return LocalRedirect(returnUrl);
        }
    }
}
