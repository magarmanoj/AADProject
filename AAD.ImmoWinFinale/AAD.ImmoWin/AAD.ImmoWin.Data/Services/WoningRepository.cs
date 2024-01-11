
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
    public static class WoningRepository
    {
        public static DataBaseContext context { get; set; }
        static WoningRepository()
        {
            context = new DataBaseContext();
        }


        public static List<Appartement> GetAppartementen()
        {
            return context.Appartementen.Include(a => a.Klant).Include(a => a.Adres).ToList();
        }

        public static List<Huis> GetHuizen()
        {
            return context.Huizen.Include(a => a.Klant).Include(a => a.Adres).ToList();
        }

        public static Woning AddWoning(Woning woning, int klantId)
        {
            woning.KlantId = klantId;
            context.Woningen.Add(woning);
            context.SaveChanges();
            return woning;
        }


        public static void UpdateWoning(int id, Woning updatedWoning)
        {
            Woning woning = context.Woningen.Find(id);
            if (woning != null)
            {
                context.Entry(woning).CurrentValues.SetValues(updatedWoning);
                context.SaveChanges();
            }
        }
        public static void RemoveWoning(Woning woning)
        {
            context.Woningen.Remove(woning as Woning);
            context.SaveChanges();
        }

        public static void RemoveWoningByID(int id)
        {
            Woning woning = context.Woningen.FirstOrDefault(w => w.Id == id);
            if (woning != null)
            {
                Adres adres = woning.Adres;

                context.Woningen.Remove(woning);

                if (adres != null)
                {
                    context.Adressen.Remove(adres);
                }

                context.SaveChanges();
            }
        }
    }

}


