
using Labb4AvanceradNET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Labb4AvanceradNET.Models
{
    public class ProgramDbContext : DbContext
    {


        public ProgramDbContext(DbContextOptions<ProgramDbContext> options) : base(options)
        {


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Webbsite> Webbsites { get; set; }

        public DbSet<UserInterest> UserInterests { get; set; }
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<UserInterest>()
            //    .HasKey(ui => new { ui.UserId, ui.InterestId });
            //modelBuilder.Entity<UserInterest>()
            //    .HasOne(ui => ui.User)
            //    .WithMany(ui => ui.Interests)
            //    .HasForeignKey(ui => ui.UserId);
            //modelBuilder.Entity<UserInterest>()
            //    .HasOne(ui => ui.Interest)
            //    .WithMany(ui => ui.Users)
            //    .HasForeignKey(ui => ui.InterestId);



            // Data for Interests
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                Id = 1,
                InterestName = "Padel",
                Description = "Padel is a sport which combines action with fun and social interaction. " +
                "It’s a great sport for players of all ages and skills, as it is both quick and easy to pick up." +
                " Most players get the basics within the first half an hour of playing " +
                "so that they can enjoy the game.",

            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                Id = 2,
                InterestName = "Golf",
                Description = "Golf is an individual sport played by hitting a ball with a club from a tee into a hole. " +
                "The object is to get the ball into the hole with the least number of swings or strokes of the club. " +
                "Golf is a hugely popular sport that is enjoyed by people of all ages.",

            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                Id = 3,
                InterestName = "Basketball",
                Description = "Basketball is a game played between two teams of five players each on a rectangular court," +
                " usually indoors. Each team tries to score by tossing the ball through the opponent's goal, " +
                "an elevated horizontal hoop and net called a basket.",

            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                Id = 4,
                InterestName = "Crossfit",
                Description = "A form of high intensity interval training, CrossFit is a strength and conditioning workout" +
                " that is made up of functional movement performed at a high intensity level. These movements are actions" +
                " that you perform in your day-to-day life, like squatting, pulling, pushing etc.",

            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                Id = 5,
                InterestName = "Running",
                Description = "Running is by definition the fastest means for an animal to move on foot. " +
                "It is defined in sporting terms as a gait in which at some point all feet are off the ground at the same time. " +
                "It is a form of both anaerobic exercise and aerobic exercise. Running is a complex, coordinated process which involves the entire body.",

            });

            // Data for Webbsites
            modelBuilder.Entity<Webbsite>().HasData(new Webbsite { Id = 1, WebbsiteName = "World Padel Tour", WebbsiteAdress = "https://www.worldpadeltour.com", InterestId = 1 });
            modelBuilder.Entity<Webbsite>().HasData(new Webbsite { Id = 2, WebbsiteName = "PGA Tour", WebbsiteAdress = "https://www.pgatour.com", InterestId = 2 });
            modelBuilder.Entity<Webbsite>().HasData(new Webbsite { Id = 3, WebbsiteName = "NBA", WebbsiteAdress = "https://www.nba.com", InterestId = 3 });
            modelBuilder.Entity<Webbsite>().HasData(new Webbsite { Id = 4, WebbsiteName = "Crossfit", WebbsiteAdress = "https://www.crossfit.com", InterestId = 4 });
            modelBuilder.Entity<Webbsite>().HasData(new Webbsite { Id = 5, WebbsiteName = "Runners World", WebbsiteAdress = "https://www.runnersworld.com", InterestId = 5 });

            // Data for Users
            modelBuilder.Entity<User>().HasData(new User { Id = 1, FirstName = "Viktor", LastName = "Gunnarsson", PhoneNumber = "0720043420" });
            modelBuilder.Entity<User>().HasData(new User { Id = 2, FirstName = "Erik", LastName = "Norell", PhoneNumber = "0720043421" });
            modelBuilder.Entity<User>().HasData(new User { Id = 3, FirstName = "Lukas", LastName = "Rose", PhoneNumber = "0720043422" });
            modelBuilder.Entity<User>().HasData(new User { Id = 4, FirstName = "Erik", LastName = "Risholm", PhoneNumber = "0720043423" });

            modelBuilder.Entity<UserInterest>().HasData(new UserInterest {UserId = 1, InterestId = 1 , UserInterestId = 1});
            modelBuilder.Entity<UserInterest>().HasData(new UserInterest { UserId = 2, InterestId = 1, UserInterestId = 2 });
            modelBuilder.Entity<UserInterest>().HasData(new UserInterest { UserId = 3, InterestId = 4, UserInterestId = 3 });
            modelBuilder.Entity<UserInterest>().HasData(new UserInterest { UserId = 3, InterestId = 3, UserInterestId = 4 });



        }
    } 
}
