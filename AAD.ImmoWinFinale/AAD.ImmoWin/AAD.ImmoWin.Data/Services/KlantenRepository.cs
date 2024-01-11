
using AAD.ImmoWin.Data.Data;
using AAD.ImmoWin.Data.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Data.Services
{
    public static class KlantenRepository
    {
        public static DataBaseContext context = new DataBaseContext();

        public static List<Klant> GetKlanten()
        {
            return context.Klanten.Include(k => k.Eigendommen).ToList();
        }

        public static List<Appartement> GetAppartementen()
        {
            return context.Appartementen.Include(a => a.Klant).ToList();
        }

        public static Klant AddKlant(Klant klant)
        {
            context.Klanten.Add(klant);
            context.SaveChanges();

            if (klant.Eigendommen != null && klant.Eigendommen.Any())
            {
                List<Woning> woningenList = new List<Woning>();

                foreach (var eigendom in klant.Eigendommen)
                {
                    Woning woning = (Woning)eigendom;

                    woning.KlantId = klant.Id;

                    woningenList.Add(woning);
                }

                context.Woningen.AddRange(woningenList);
                context.SaveChanges();
            }
            return klant;
        }

        public static Klant UpdateKlant(Klant klant)
        {
            context.Klanten.AddOrUpdate(klant);
            context.SaveChanges();
            return klant;
        }


        public static void UpdateKlantByID(int id, Klant klant)
        {
            Klant k = context.Klanten.Find(id);
            if (k != null)
            {
                context.Entry(k).CurrentValues.SetValues(klant);
                context.SaveChanges();
            }
            context.SaveChanges();
        }

        public static void RemoveKlantByID(int klantID)
        {
            Klant klant = context.Klanten.FirstOrDefault(k => k.Id == klantID);
            if (klant != null)
            {
                context.Klanten.Remove(klant);
                context.SaveChanges();
            }
        }
        public static bool HeeftEigendommen(int id)
        {
            return context.Appartementen.Any(a => a.Klant.Id == id) || context.Huizen.Any(h => h.Klant.Id == id);
        }

    }

}


