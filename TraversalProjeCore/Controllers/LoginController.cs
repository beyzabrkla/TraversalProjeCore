using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string username, string password, string confirmPassword)
        {
            // Here you would typically add logic to create a new user account,
            // such as validating input, hashing the password, and saving to a database.
            if (password != confirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return View();
            }
            // Simulate user creation
            // UserService.CreateUser(username, password);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet] 
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
