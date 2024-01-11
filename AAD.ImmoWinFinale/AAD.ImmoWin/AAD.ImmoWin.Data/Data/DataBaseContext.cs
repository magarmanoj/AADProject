using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Data.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Appartement> Appartementen { get; set; }
        public DbSet<Huis> Huizen { get; set; }
        public DbSet<Adres> Adressen { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Woning> Woningen { get; set; }

        public DataBaseContext() : base("dbImmoWin1")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataBaseContext>());
        }
    }
}
