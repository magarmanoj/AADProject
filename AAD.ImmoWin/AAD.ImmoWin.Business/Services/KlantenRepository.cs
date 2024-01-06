using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Business.Services
{
    public static class KlantenRepository
    {
        public static DataBaseContext context { get; set; }
        static KlantenRepository()
        {
            context = new DataBaseContext();
        }

        public static List<Klant> GetKlanten()
        {
            return context.Klanten.ToList();
        }

        public static List<Appartement> GetAppartementen()
        {
            return context.Appartementen.ToList();
        }

        public static List<Huis> GetHuizen()
        {
           return context.Huizen.ToList();
        }

        #region Woning
        public static IWoning AddWoning(IWoning woning)
        {
            context.Woningen.Add(woning as Woning);
            context.SaveChanges();
            return woning;
        }

        public static void UpdateWoning(int id, Woning updatedWoning)
        {
            Woning woning = context.Woningen.Find(id);
            if(woning != null)
            {
                context.Entry(woning).CurrentValues.SetValues(updatedWoning);
                context.SaveChanges() ;
            }
        }
        public static void RemoveWoning(IWoning woning)
        {
            context.Woningen.Remove(woning as Woning);
            context.SaveChanges();
        }
        #endregion

        #region Klant
        public static IKlant AddKlant(IKlant klant)
        {
            context.Klanten.Add(klant as Klant);
            context.SaveChanges();
            if (klant.Eigendommen != null && klant.Eigendommen.Any())
            {
                List<Woning> woningenList = new List<Woning>();

                for (int i = 0; i < klant.Eigendommen.Count; i++)
                {
                    Woning e = (Woning)klant.Eigendommen[i];
                    woningenList.Add(e);
                }
                context.Woningen.AddRange(woningenList);
                context.SaveChanges();
            }

            return klant;
        }


        public static IKlant UpdateKlant(IKlant klant)
        {
            context.Klanten.AddOrUpdate(klant as Klant);
            context.SaveChanges();
            return klant;
        }

        public static void RemoveKlant(IKlant klant)
        {
            context.Klanten.Remove(klant as Klant);
            context.SaveChanges();
        }
        #endregion
    }

}


