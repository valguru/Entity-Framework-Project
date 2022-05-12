﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ПР7.Models;

namespace ПР7
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            // получаем строку подключения из файла конфигурации
            //string connection = Configuration.GetConnectionString("DefaultConnection");
            // добавляем контекст PhoneDBContext в качестве сервиса в приложение
            //services.AddDbContext<PhoneDBContext>(options =>
            //   options.UseSqlServer(connection));
            services.AddDbContext<SongDBContext>();
            services.AddControllersWithViews();
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
