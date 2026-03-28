using AutoMapper.Internal;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalProjeCore.Models;

namespace TraversalProjeCore.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail);

            if (user == null)
            {
                // Kullanıcı bulunamadığında sayfada mesaj çıkarır.
                ViewBag.Message = "Girilen mail adresi sistemde kayıtlı değil.";
                return View();
            }

            try
            {
                string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResetLink = Url.Action("ResetPassword", "PasswordChange",
                    new
                    {
                        userId = user.Id,
                        token = passwordResetToken
                    }, HttpContext.Request.Scheme);

                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "beyzailetisimapp@gmail.com");
                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordViewModel.Mail);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodybuilder = new BodyBuilder();
                bodybuilder.TextBody = "Şifrenizi sıfırlamak için linke tıklayın: " + passwordResetLink;
                mimeMessage.Body = bodybuilder.ToMessageBody();
                mimeMessage.Subject = "Şifre Değişiklik Talebi";

                using (var smtpClient = new SmtpClient())
                {
                    await smtpClient.ConnectAsync("smtp.gmail.com", 587, false);
                    await smtpClient.AuthenticateAsync("beyzailetisimapp@gmail.com", "qrmoackfzratkiky");
                    await smtpClient.SendAsync(mimeMessage);
                    await smtpClient.DisconnectAsync(true);
                }

                ViewBag.Message = "Şifre yenileme linki başarıyla gönderildi.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Mail gönderilirken bir hata oluştu: " + ex.Message;
            }

            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userId = TempData["userId"];
            var token = TempData["token"];
            if(userId == null || token == null)
            {
                ViewBag.Message = "Geçersiz istek.";
                return View();
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());
            await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordViewModel.Password);
            if(ModelState.IsValid)
            {
                ViewBag.Message = "Şifreniz başarıyla değiştirildi.";
                return RedirectToAction("SignIn","Login");
            }
            else
            {
                ViewBag.Message = "Şifre değiştirilemedi. Lütfen tekrar deneyin.";
                return View();
            }
        }
    }
}
