using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendContactUsValidator : AbstractValidator<SendMessageDTO>
    {
        public SendContactUsValidator()
        {
            RuleFor(x=>x.Mail).NotEmpty().WithErrorCode("Mail alanı boş geçilemez");
            RuleFor(x=>x.Subject).NotEmpty().WithErrorCode("Konu boş geçilemez");
            RuleFor(x=>x.Name).NotEmpty().WithErrorCode("Lütfen isminizi giriniz");
            RuleFor(x=>x.MessageBody).NotEmpty().WithErrorCode("Lütfen mesajınızı yazınız");

            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Lütfen en az 5 karatkerlik konu başlığı yazın");
            RuleFor(x => x.Subject).MaximumLength(200).WithMessage("Lütfen konu başlığını biraz kısaltın");

            RuleFor(x => x.Mail).MinimumLength(20).WithMessage("Lütfen mail adresinizini istenen uzunlukta girin");
            RuleFor(x => x.Mail).MaximumLength(100).WithMessage("Lütfen mail adresinizi biraz kısaltın");
        }
    }
}
