namespace PetFinder.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetFinder.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PetFinder.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Location.AddOrUpdate(x => x.LocationID,
               new Location() { LocationID = 1, ZipCode = "53201" },
               new Location() { LocationID = 1, ZipCode = "53201" },
               new Location() { LocationID = 2, ZipCode = "53202" },
               new Location() { LocationID = 3, ZipCode = "53203" },
               new Location() { LocationID = 4, ZipCode = "53204" },
               new Location() { LocationID = 5, ZipCode = "53205" },
               new Location() { LocationID = 6, ZipCode = "53206" },
               new Location() { LocationID = 7, ZipCode = "53207" },
               new Location() { LocationID = 8, ZipCode = "53208" },
               new Location() { LocationID = 9, ZipCode = "53209" },
               new Location() { LocationID = 10, ZipCode = "53210" },
               new Location() { LocationID = 11, ZipCode = "53211" },
               new Location() { LocationID = 12, ZipCode = "53212" },
               new Location() { LocationID = 13, ZipCode = "53213" },
               new Location() { LocationID = 14, ZipCode = "53214" },
               new Location() { LocationID = 15, ZipCode = "53215" },
               new Location() { LocationID = 16, ZipCode = "53216" },
               new Location() { LocationID = 17, ZipCode = "53217" },
               new Location() { LocationID = 18, ZipCode = "53218" },
               new Location() { LocationID = 19, ZipCode = "53219" },
               new Location() { LocationID = 20, ZipCode = "53220" },
               new Location() { LocationID = 21, ZipCode = "53221" },
               new Location() { LocationID = 22, ZipCode = "53222" },
               new Location() { LocationID = 23, ZipCode = "53223" },
               new Location() { LocationID = 24, ZipCode = "53224" },
               new Location() { LocationID = 25, ZipCode = "53225" },
               new Location() { LocationID = 26, ZipCode = "53226" },
               new Location() { LocationID = 27, ZipCode = "53227" },
               new Location() { LocationID = 28, ZipCode = "53228" },
               new Location() { LocationID = 29, ZipCode = "53233" },
               new Location() { LocationID = 30, ZipCode = "53235" },
               new Location() { LocationID = 31, ZipCode = "53110" },
               new Location() { LocationID = 32, ZipCode = "53129" },
               new Location() { LocationID = 33, ZipCode = "53130" },
               new Location() { LocationID = 34, ZipCode = "53132" },
               new Location() { LocationID = 35, ZipCode = "53154" },
               new Location() { LocationID = 36, ZipCode = "53172" }
       );
            context.Color.AddOrUpdate(x => x.ColorID,
                    new Color() { ColorID = 1, Hue = "Black" },
                    new Color() { ColorID = 1, Hue = "Brown" },
                    new Color() { ColorID = 1, Hue = "Yellow" },
                    new Color() { ColorID = 1, Hue = "White" },
                    new Color() { ColorID = 1, Hue = "Red" },
                    new Color() { ColorID = 1, Hue = "Calico" },
                    new Color() { ColorID = 1, Hue = "Tabby" }
                );
            context.AnimalType.AddOrUpdate(x => x.AnimalTypeID,
                new AnimalType() { AnimalTypeID = 1, Species = "Dog" },
                new AnimalType() { AnimalTypeID = 1, Species = "Cat" },
                new AnimalType() { AnimalTypeID = 1, Species = "Bird" },
                new AnimalType() { AnimalTypeID = 1, Species = "Horse" },
                new AnimalType() { AnimalTypeID = 1, Species = "Hamster" },
                new AnimalType() { AnimalTypeID = 1, Species = "Snake" }
            );
        }
    }
}
