using EntityLayer.Concrete; 
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalProjeCore.Areas.Member.Models;

namespace TraversalProjeCore.Areas.Member.Controllers
{
    [Area("Member")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = values.Name;
            userEditViewModel.Surname = values.Surname;
            userEditViewModel.PhoneNumber = values.PhoneNumber;
            userEditViewModel.Mail = values.Email;
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory(); // projenin kök dizinini alır
                var extension = Path.GetExtension(p.Image.FileName); // dosya uzantısını alır
                var imageName = Guid.NewGuid() + extension; // benzersiz bir dosya adı oluşturur
                var saveLocation = Path.Combine(resource, "wwwroot/UserImages/", imageName); // dosyanın kaydedileceği yolu belirler
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await p.Image.CopyToAsync(stream); // Dosya kopyalanır
                } // using bloğu bitince 'stream' otomatik olarak kapatılır ve kaynak serbest bırakılır (stream.Dispose())

                user.ImageUrl = imageName;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
           var result = await _userManager.UpdateAsync(user); // kullanıcıyı günceller
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login", new { area = "" });
            }
            return View();
        }
    }
}
