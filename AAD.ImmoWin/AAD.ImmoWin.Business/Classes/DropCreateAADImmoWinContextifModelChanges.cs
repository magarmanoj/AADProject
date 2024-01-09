using AAD.ImmoWin.Business.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Business.Classes
{
    public class DropCreateImmoWinContextifModelChanges : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            Klant klant;
            Woning woning;

            klant = new Klant("Theo", "Flitser");
            context.SaveChanges();
            KlantenRepository.AddKlant(klant);


            klant = new Klant("Bert", "Bibber");
            woning = new Huis(Business.Enumerations.Huistype.Rijhuis, new Adres("Stormstraat", 1, 1000, "Brussel"), DateTime.Now, 0);
            klant.Eigendommen.Add(woning);
            context.SaveChanges();
            KlantenRepository.AddKlant(klant);



            klant = new Klant("Junior", "Warwinkel");
            woning = new Appartement(0, new Adres("Stormstraat", 2, 1000, "Brussel"), DateTime.Now, 0);
            klant.Eigendommen.Add(woning);
            context.SaveChanges();
            KlantenRepository.AddKlant(klant);



            klant = new Klant("Piet", "Pienter");
            klant.Eigendommen.Add(new Appartement(1, new Adres("Stormstraat", 2, 1000, "Brussel"), DateTime.Now, 0));
            klant.Eigendommen.Add(new Huis(Business.Enumerations.Huistype.Rijhuis, new Adres("Stormstraat", 3, 1000, "Brussel"), DateTime.Now, 0));
            context.SaveChanges();
            KlantenRepository.AddKlant(klant);



            klant = new Klant("Hilarius", "Warwinkel");
            klant.Eigendommen.Add(new Huis(Business.Enumerations.Huistype.Vrijstaand, new Adres("Stormstraat", 5, 1000, "Brussel"), DateTime.Now, 0));
            klant.Eigendommen.Add(new Appartement(3, new Adres("Stormstraat", 2, 1000, "Brussel"), DateTime.Now, 0));
            klant.Eigendommen.Add(new Appartement(2, new Adres("Stormstraat", 2, 1000, "Brussel"), DateTime.Now, 0));
            klant.Eigendommen.Add(new Appartement(5, new Adres("Stormstraat", 2, 1000, "Brussel"), DateTime.Now, 0));
            klant.Eigendommen.Add(new Huis(Business.Enumerations.Huistype.Tweegevel, new Adres("Stormstraat", 1, 1000, "Brussel"), DateTime.Now, 0));
            klant.Eigendommen.Add(new Appartement(4, new Adres("Stormstraat", 2, 1000, "Brussel"), DateTime.Now, 0));
            KlantenRepository.AddKlant(klant);


            context.SaveChanges();

        }
    }

}
