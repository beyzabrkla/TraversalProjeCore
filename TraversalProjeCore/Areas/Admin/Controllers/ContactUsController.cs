using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

[Area("Admin")]
[Route("Admin/ContactUs")]
public class ContactUsController : Controller
{
    private readonly IContactUsService _contactUsService;
 
    public ContactUsController(IContactUsService contactUsService)
    {
        _contactUsService = contactUsService;
    }

    [Route("Index")]
    public IActionResult Index()
    {
        var values = _contactUsService.TGetListContactUsByTrue();
        return View(values);
    }

    [Route("DeleteContactUs/{id}")]
    public IActionResult DeleteContactUs(int id)
    {
        var value = _contactUsService.TGetById(id);
        _contactUsService.TDelete(value);
        return RedirectToAction("Index");
    }

    [Route("ContactUsDetails/{id}")]
    public IActionResult ContactUsDetails(int id)
    {
        var value = _contactUsService.TGetById(id);
        return View(value);
    }
}