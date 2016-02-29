using System;
using System.Collections.Generic;
using EventsApp.Models;
using System.Data.Entity.Migrations;

namespace EventsApp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AppDbContext context)
        {
            SeedEvents(context);
            SeedUsers(context);
            SeedEventUsers(context);
        }

        private void SeedEventUsers(AppDbContext context)
        {
            context.Events.Find(1).Users.Add(context.Users.Find(1));
            context.Events.Find(1).Users.Add(context.Users.Find(2));
            context.Events.Find(2).Users.Add(context.Users.Find(1));
            context.SaveChanges();
        }

        private void SeedEvents(AppDbContext context)
        {
            var events = new List<Event>
            {
                new Event { Title = "Event 1", Location = "London", Time = DateTime.Now.AddHours(4)}, 
                new Event { Title = "Event 2", Location = "San Francisco", Time = DateTime.Now.AddDays(-1).AddHours(6)},
                new Event { Title = "Event 3", Location = "Los Angeles", Time = DateTime.Now.AddDays(2).AddHours(2)},
            };

            context.Events.AddRange(events);
            context.SaveChanges();
        }

        private void SeedUsers(AppDbContext context)
        {
            var users = new List<User>()
            {
                new User {Name = "Arsene Wenger", Age = 67, Email = "wenger@eventapp.com"},
                new User {Name = "Olivier Giroud", Age = 28, Email = "giroud@eventapp.com"},
                new User {Name = "Theo Walcott", Age = 26, Email = "walcott@eventapp.com"},
                new User {Name = "Metsul Ozil", Age = 26, Email = "ozil@eventapp.com"},
                new User {Name = "Alexis Sanchez", Age = 29, Email = "sanchez@eventapp.com"},
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }


    }
}
