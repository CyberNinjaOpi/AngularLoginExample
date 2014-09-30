using ArtGallery.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Migrations;

namespace ArtGallery.Data
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext db, bool seedRoles = true, bool seedUsers = true, bool seedArtworks = true)
        {
            var user01 = new ApplicationUser()
            {
                UserName = "SuperAdmin",
                Email = "superadmin@mail.com"
            };

            if (seedRoles)
            {
                RoleManager<IdentityRole> rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                if(!rm.RoleExists("Admin"))
                {
                    rm.Create(new IdentityRole("Admin"));
                }
                db.SaveChanges();
            }

            if (seedUsers)
            {
                UserManager<ApplicationUser> um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                if (um.FindByName(user01.UserName) == null)
                {
                    var result = um.Create(user01, "pass123");
                    db.SaveChanges();
                    if (result.Succeeded)
                    {
                        um.AddToRole(user01.UserName, "Admin");
                        db.SaveChanges();
                    }
                }
            }

            if (seedArtworks)
            {
                var user = db.Users.Where(x => x.UserName == "SuperAdmin").FirstOrDefault();

                
                db.Artworks.AddOrUpdate(
                    x => x.Title,
                    new Artwork(user.Id, "https://www.global-art-exchange.com/wp-content/uploads/2013/11/art-auction.jpg", "Trees n Stuff", "A bold and colorful oil painting."),
                    new Artwork(user.Id, "http://www.stewartstephenson.com/images/thinlizzy2LG.jpg", "Reflection", "A thoughtful exploration of reflection.")
                    );
                db.SaveChanges();
            }
        }
    }
}
