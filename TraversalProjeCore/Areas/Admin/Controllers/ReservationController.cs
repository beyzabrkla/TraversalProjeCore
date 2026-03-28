using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

[Area("Admin")]
[Route("Admin/Reservation")]
public class ReservationController : Controller
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [Route("Index")]
    public IActionResult Index()
    {
        // Manager'da yazdığın TGetList metodu tüm tabloyu getirecek
        var values = _reservationService.TGetList();
        return View(values);
    }

    [Route("DeleteReservation/{id}")]
    public IActionResult DeleteReservation(int id)
    {
        var value = _reservationService.TGetById(id);
        _reservationService.TDelete(value);
        return RedirectToAction("Index");
    }

    [Route("AcceptReservation/{id}")]
    public IActionResult AcceptReservation(int id)
    {
        var value = _reservationService.TGetById(id);
        value.Status = "Onaylandı";
        _reservationService.TUpdate(value);
        return RedirectToAction("Index");
    }

    [Route("RejectReservation/{id}")]
    public IActionResult RejectReservation(int id)
    {
        var value = _reservationService.TGetById(id);
        value.Status = "İptal Edildi";
        _reservationService.TUpdate(value);
        return RedirectToAction("Index");
    }


}