using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7Assignment.Models
{
    //creates class for identification table
    public static class IdentitySeedData
    {
        //sets initial admin username and password
        private const string adminUser = "Admin";
        private const string adminPassword = "Password123456!";

        //This method makes sure that the Identity table is populated when it runs
        public static async void EnsurePopulated (IApplicationBuilder app)
        {
            AppIdentityDBContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDBContext>();

            //Gets any migrations that haven't been migrated yet
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByIdAsync(adminUser);

            //if the user is null, it fills the fields with the seed data
            if (user == null)
            {
                user = new IdentityUser(adminUser);

                user.Email = "admin@yeet.com";
                user.PhoneNumber = "555-1234";

                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
