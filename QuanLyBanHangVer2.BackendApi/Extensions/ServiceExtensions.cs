using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using QuanLyBanHangVer2.Application.Catalog.Manage.Products;
using QuanLyBanHangVer2.Application.Catalog.Products.Manage;
using QuanLyBanHangVer2.Application.Catalog.Products.Public;
using QuanLyBanHangVer2.Application.Common;
using QuanLyBanHangVer2.Application.System.LoggerManager;

using QuanLyBanHangVer2.Application.System.Users;
using QuanLyBanHangVer2.Data.Entities.Concrete;

namespace QuanLyBanHangVer2.BackendApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void InjectionService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddTransient<IStorageService, StorageService>();
            services.AddTransient<IPulbicProductService, PulbicProductService>();
            services.AddTransient<IManageProductService, ManageProductService>();

            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<IUsersService, UserService>();
        }
    }
}