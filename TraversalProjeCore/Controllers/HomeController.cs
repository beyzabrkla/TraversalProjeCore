using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TraversalProjeCore.Models;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // ILogger ile loglama işlemi yapılacak

        public HomeController(ILogger<HomeController> logger) // ILogger bağımlılığı constructor ile enjekte ediliyor
        {
            _logger = logger;
        }

        public IActionResult Index() // Ana sayfa aksiyonu
        {
            _logger.LogInformation("Index sayfası çağrıldı"); // Bilgi seviyesinde loglama
            _logger.LogError("Error log çağrıldı");// Hata seviyesinde loglama
            return View();
        }

        public IActionResult Privacy() // Gizlilik sayfası aksiyonu
        {
            DateTime d = Convert.ToDateTime(DateTime.Now.ToLongDateString()); // Şimdiki tarihi al
            _logger.LogInformation(d + " Privacy sayfası çağrıldı");// Bilgi seviyesinde loglama
            return View();
        }

        public IActionResult Test()
        {
            _logger.LogInformation("Test sayfası çağrıldı");// Bilgi seviyesinde loglama
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]// Önbellekleme ayarları
        public IActionResult Error()// Hata sayfası aksiyonu
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); // Hata modeli ile görünümü döndür
        }
    }
}