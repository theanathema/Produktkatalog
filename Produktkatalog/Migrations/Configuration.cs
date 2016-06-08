namespace Produktkatalog.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Produktkatalog.DataAccessLayer.ProduktContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Produktkatalog.DataAccessLayer.ProduktContext context)
        {
            context.Produkter.AddOrUpdate(
                p => p.Namn,
                    new Produkt { Namn = "Guld 1 gram", Beskrivning = "Ett gram guld.", Pris = 305 },
                    new Produkt { Namn = "Silver 1 gram", Beskrivning = "Ett gram silver.", Pris = 4.4 },
                    new Produkt { Namn = "Koppar 1 kilogram", Beskrivning = "Ett kilogram (kg) koppar.", Pris = 20 } 
            );
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
        }
    }
}
