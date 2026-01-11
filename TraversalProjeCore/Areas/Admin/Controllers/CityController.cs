using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TraversalProjeCore.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;
        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CityList()
        {
            try
            {
                var list = _destinationService.TGetList();
                var jsonValues = JsonConvert.SerializeObject(list ?? new List<Destination>());
                return Json(jsonValues);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Veri alınırken hata oluştu.", detail = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult CityGetById(int id)
        {
            try
            {
                var destination = _destinationService.TGetById(id);

                if (destination == null)
                    return NotFound(new { message = "Şehir bulunamadı." });

                var jsonValue = JsonConvert.SerializeObject(destination);
                return Json(jsonValue);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Hata oluştu.", detail = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CityAdd([FromBody] Destination destination)
        {
            try
            {
                if (destination == null || string.IsNullOrEmpty(destination.City) || destination.Capacity <= 0)
                {
                    return BadRequest(new { message = "Geçersiz veri. Şehir adı veya Kapasite boş olamaz." });
                }

                destination.DestinationId = 0; 
                _destinationService.TAdd(destination);
                return Json(JsonConvert.SerializeObject(destination));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Şehir eklenirken hata oluştu.", detail = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CityUpdate([FromBody] Destination destination)
        {
            try
            {
                if (destination == null || destination.DestinationId<= 0)
                    return BadRequest(new { message = "Geçersiz veri. Güncellenecek şehir ID'si eksik." });

                _destinationService.TUpdate(destination);

                var jsonValue = JsonConvert.SerializeObject(destination);
                return Json(jsonValue);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Şehir güncellenirken hata oluştu.", detail = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CityDelete(int id)
        {
            try
            {
                var destination = _destinationService.TGetById(id);

                if (destination == null)
                    return NotFound(new { message = "Silinecek şehir bulunamadı." });

                _destinationService.TDelete(destination);
                return Json(new { success = true, message = "Silme başarılı." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Şehir silinirken hata oluştu.", detail = ex.Message });
            }
        }
    }
}