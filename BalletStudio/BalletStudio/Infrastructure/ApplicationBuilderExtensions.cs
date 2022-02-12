using BalletStudio.Data;
using BalletStudio.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BalletStudio.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);
            SeedTeachers(services);
            SeedGroups(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<BalletStudioDbContext>();

            data.Database.Migrate();



        }

        private static void SeedTeachers(IServiceProvider services)
        {
            var data = services.GetRequiredService<BalletStudioDbContext>();

            if (data.Teachers.Any())
            {
                return;
            }

            data.Teachers.Add(new Teacher
            {
                FirstName = "Mihaela",
                LastName = "Barzilova",
                
            });

            data.SaveChanges();
        }

        private static void SeedGroups(IServiceProvider services)
        {
            var data = services.GetRequiredService<BalletStudioDbContext>();

            if (data.Groups.Any())
            {
                return;
            }

            data.Groups.Add(new Group
            {
                Teacher = data.Teachers.FirstOrDefault()

            }) ;

            data.SaveChanges();
        }
    }
}
