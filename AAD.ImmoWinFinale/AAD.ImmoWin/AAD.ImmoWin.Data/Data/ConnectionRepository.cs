using AAD.ImmoWin.Data.Services;
using AAD.ImmoWin.Data.Enumerations;
using System;
using System.Data.Entity;

namespace AAD.ImmoWin.Data.Data
{
    public class ConnectionRepository : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            Klant k = new Klant { Voornaam = "Piet", Familienaam = "Pienter" };
            context.Klanten.Add(k);

            Klant k2 = new Klant { Voornaam = "Bert", Familienaam = "Bibber" };
            context.Klanten.Add(k2);

            Klant k3 = new Klant { Voornaam = "Theo", Familienaam = "Flitser" };
            context.Klanten.Add(k3);

            context.SaveChanges();

            Huis huis1 = new Huis(Huistype.Rijhuis, new Adres("Stormstraat", 1, 1000, "Brussel"), DateTime.Now, 50) { KlantId = k.Id };
            context.Huizen.Add(huis1);

            Appartement appartement1 = new Appartement(0, new Adres("Stormstraat", 2, 1000, "Leuven"), DateTime.Now, 100) { KlantId = k.Id };
            context.Appartementen.Add(appartement1);

            Appartement appartement2 = new Appartement(0, new Adres("Stormstraat", 2, 1000, "Leuven"), DateTime.Now, 100) { KlantId = k3.Id };
            context.Appartementen.Add(appartement2);

            context.SaveChanges();
        }

    }
}
