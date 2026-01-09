using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
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

        }
    }
}
