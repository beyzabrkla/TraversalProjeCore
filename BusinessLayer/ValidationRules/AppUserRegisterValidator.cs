using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTOs> //DTO KATMANINDAN KALITIM ALIYORUZ
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithErrorCode("Lütfen isim giriniz");
            RuleFor(x => x.Surname).NotEmpty().WithErrorCode("Lütfen soyisim giriniz");
            RuleFor(x => x.Mail).NotEmpty().WithErrorCode("Mail boş olamaz");
            RuleFor(x => x.Username).NotEmpty().WithErrorCode("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithErrorCode("Lütfen bir Şifre giriniz");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithErrorCode("Şifreyi tekrar giriniz");

            RuleFor(x => x.Username).MinimumLength(5).WithMessage("Lütfen en az 5 karakterlik kullanıcı adı girin");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakterlik kullanıcı adı girin");
            RuleFor(x => x.Password).Equal(y=>y.ConfirmPassword).WithMessage("Şifreler birbiriyle uyuşmuyor. Lütfen tekrar deneyin");
        }
    }
}
