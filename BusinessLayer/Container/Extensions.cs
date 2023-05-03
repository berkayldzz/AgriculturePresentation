using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        // programcs de tuttuğumuz değerleri buraya taşıdık.

        // Listeleme işlemimi farklı bir yöntem kullanarak constructor ile yapmıştık.
        // Fakat bu işlem hata verdi.Bu hatayı constructorları yakalayacak olan komutlar ile çözeceğiz.

        public static void ContainerDependencies(this IServiceCollection services)
        {

            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IServiceDal, EfServiceDal>();

            services.AddScoped<ITeamService, TeamManager>();
            services.AddScoped<ITeamDal, EfTeamDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementsDal, EfAnnouncementDal>();

            services.AddScoped<IImageService, ImageManager>();
            services.AddScoped<IImageDal, EfImageDal>();

            services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<IAddressDal, EfAddressDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();

            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();

            services.AddScoped<IAdminService, AdminManager>();
            services.AddScoped<IAdminDal, EfAdminDal>();
        }

    }
}
