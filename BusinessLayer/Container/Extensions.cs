using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUOW;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUOW;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Container
{
    // Sınıfı statik yapıyoruz, böylece extension metodu tanımlayabiliriz.
    public static class Extensions
    {
        // Metodu da statik yapıyoruz ve 'this IServiceCollection' kullanıyoruz böylece new lemeye gerek kalmadan metodu çağırabiliriz.
        public static void ContainerDependencies(this IServiceCollection services)
        {

            services.AddScoped<ICommentService, CommentManager>();// ICommentService bağımlılığı
            services.AddScoped<ICommentDal, EFCommentDal>();// ICommentDal bağımlılığı

            services.AddScoped<IDestinationService, DestinationManager>();// IDestinationService bağımlılığı
            services.AddScoped<IDestinationDal, EFDestinationDal>();// IDestinationDal bağımlılığı

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EFAppUserDal>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EFReservationDal>();

            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EFGuideDal>();

            services.AddScoped<IExcelService, ExcelManager>();
            services.AddScoped<IPdfService, PdfManager>();

            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EFContactUsDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EFAnnouncementDal>();

            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountDal, EfAccountDal>();

            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal, EFTestimonialDal>();
            
            services.AddScoped<IUOWDal, UOWDal>();
        }

        public static void CustomerValidator(this IServiceCollection services)
        { 
            services.AddTransient<IValidator<AnnouncementAddDTO>,AnnouncementValidator>();
        }
    }
}

