using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiganlRApi.DAL;
using SiganlRApi.Model;

namespace SiganlRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorService _visitorService;

        public VisitorController(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateVisitor() // async eklendi
        {
            Random random = new Random();
            // ForEach içinde await kullanabilmek için döngüyü düzeltiyoruz
            for (int x = 1; x <= 10; x++)
            {
                foreach (Ecity item in Enum.GetValues(typeof(Ecity)))
                {
                    var newVisitor = new Visitor
                    {
                        City = item,
                        CityVisitCount = random.Next(100, 2000),
                        VisitDate = DateTime.UtcNow.AddDays(x)
                    };
                    // await kullanarak kilitlenmeyi önlüyoruz
                    await _visitorService.SaveVisitor(newVisitor);
                    await Task.Delay(1000); // Thread.Sleep yerine asenkron gecikme
                }
            }
            return Ok("Ziyaretçiler başarılı bir şekilde eklendi");
        }
    }
}
