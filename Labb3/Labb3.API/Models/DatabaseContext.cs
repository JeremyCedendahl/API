using Labb3Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3.API.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PersonHobby> PersonHobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Data

            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 1, FirstName = "Jeremy", LastName = "Cedendahl", PhoneNumber = "0702556191" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 2, FirstName = "Basse", LastName = "Cedendahl", PhoneNumber = "07012345678" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 3, FirstName = "Johan", LastName = "Fältholm", PhoneNumber = "07012335679" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 4, FirstName = "Anton", LastName = "Olsson", PhoneNumber = "07012349587" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 5, FirstName = "Carina", LastName = "Cedendahl", PhoneNumber = "073234232" });

            modelBuilder.Entity<Hobby>().HasData(new Hobby { HobbyId = 1, Title = "Art", Description = "Paint or draw artwork." });
            modelBuilder.Entity<Hobby>().HasData(new Hobby { HobbyId = 2, Title = "Music", Description = "Listen or/and create music." });
            modelBuilder.Entity<Hobby>().HasData(new Hobby { HobbyId = 3, Title = "Game Development", Description = "Code video games." });
            modelBuilder.Entity<Hobby>().HasData(new Hobby { HobbyId = 4, Title = "Sculpting", Description = "Sculpt models with clay or software." });

            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 1, HobbyId = 1, PersonId = 4, URL = "wikiart.org/" });
            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 2, HobbyId = 2, PersonId = 3, URL = "soundcloud.com/jerm-495708466" });
            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 3, HobbyId = 3, PersonId = 1, URL = "unity.com/" });
            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 4, HobbyId = 4, PersonId = 5, URL = "en.wikipedia.org/wiki/Sculpture" });
            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 5, HobbyId = 3, PersonId = 2, URL = "unrealengine.com/en-US/" });

            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby { PersonHobbyId = 1, HobbyId = 1, PersonId = 4 });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby { PersonHobbyId = 2, HobbyId = 2, PersonId = 3 });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby { PersonHobbyId = 3, HobbyId = 3, PersonId = 1 });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby { PersonHobbyId = 4, HobbyId = 4, PersonId = 5 });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby { PersonHobbyId = 5, HobbyId = 4, PersonId = 2 });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby { PersonHobbyId = 6, HobbyId = 3, PersonId = 2 });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby { PersonHobbyId = 7, HobbyId = 2, PersonId = 1 });
        }
    }
}