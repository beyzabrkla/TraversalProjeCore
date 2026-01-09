using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Rehber Adı boş geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmı boş geçilemez.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen Görsel seçiniz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakterlik rehber adı giriniz.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Lütfen rehber adını kısaltın.");
        }
    }
}
