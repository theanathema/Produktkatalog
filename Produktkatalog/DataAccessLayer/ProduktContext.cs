using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Produktkatalog.DataAccessLayer
{
    public class ProduktContext : DbContext
    {
        public ProduktContext() : base("DefaultConnectionProdukt")
        {
            
        }

        public DbSet<Models.Produkt> Produkter { get; set; }
    }
}

    
