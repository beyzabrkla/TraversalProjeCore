using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDTO>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithErrorCode("Lütfen başlık giriniz");
            RuleFor(x => x.Content).NotEmpty().WithErrorCode("Lütfen içerik giriniz");

            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 karakterlik veri girişi yapın");
            RuleFor(x => x.Content).MinimumLength(20).WithMessage("Lütfen en az 20 karakterlik veri girişi yapın");

            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik veri girişi yapın");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Lütfen en fazla 500 karakterlik veri girişi yapın");

        }
    }
}
