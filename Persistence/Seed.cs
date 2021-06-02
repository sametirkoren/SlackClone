using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(UserManager<AppUser> userManager){
            if(!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{
                        Id = "1",
                        UserName="Samet",
                        Email = "sametirkoren@gmail.com"
                    },

                    new AppUser{
                        Id = "2",
                        UserName="Meva",
                        Email = "mevakun@gmail.com"
                    },

                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user,"Aqswde123!.");
                }
            }
        }
    }
}