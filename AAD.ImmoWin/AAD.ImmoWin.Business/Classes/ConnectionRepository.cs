using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Business.Classes
{
    public class ConnectionRepository : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            SeedData(context);
        }


        public void SeedData(DataBaseContext context)
        {
            if (!context.Klanten.Any())
            {
                
                Klant k = new Klant { Voornaam = "Piet", Familienaam = "Pienter" };
                Huis huis1 = new Huis(Business.Enumerations.Huistype.Rijhuis, new Adres("Stormstraat", 1, 1000, "Brussel"), DateTime.Now, 50);
                context.Huizen.Add(huis1);

                Klant k2 = new Klant { Voornaam = "Bert", Familienaam = "Bibber" };
                Huis huis2 = new Huis(Business.Enumerations.Huistype.Rijhuis, new Adres("Stormstraat", 1, 2000, "Brussel"), DateTime.Now, 50);
                context.Huizen.Add(huis2);

                Klant k3 = new Klant { Voornaam = "Theo", Familienaam = "Flitser" };
                Appartement appartement2 = new Appartement(0, new Adres("Stormstraat", 2, 1000, "Leuven"), DateTime.Now, 100);
                context.Appartementen.Add(appartement2);

                k.Eigendommen.Add(appartement2);
                k.Eigendommen.Add(huis1);
                k3.Eigendommen.Add(huis1);
                k3.Eigendommen.Add(huis1);

                context.Klanten.Add(k);
                context.Klanten.Add(k2);
                context.Klanten.Add(k3);

                context.SaveChanges();
            }
        }
    }
}
