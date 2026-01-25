using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalProjeCore.Models;

namespace TraversalProjeCore.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "beyzailetisimapp@gmail.com"); //gönderici bilgileri
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail); //alıcı bilgileri
            mimeMessage.To.Add(mailboxAddressTo);

            var bodybuilder = new BodyBuilder();
            bodybuilder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodybuilder.ToMessageBody();

            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient smtpClient = new SmtpClient(); 
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("beyzailetisimapp@gmail.com", "hbtdyifpjtrshoiv");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return View();
        }
    }
}
