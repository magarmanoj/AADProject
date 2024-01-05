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
        private static Klanten _klanten;
        private static Woningen _woningen;
        public static DataBaseContext context = new DataBaseContext();
        static KlantenRepository()
        {
            ConnectionRepository connectionRepository = new ConnectionRepository();
            connectionRepository.SeedData(context);
        }

        public static Klanten GetKlanten()
        {
            List<Klant> klantList = context.Klanten.ToList();
            _klanten = new Klanten(klantList);
            return _klanten;
        }

        public static Woningen GetAppartementen()
        {
            List<Appartement> appartementList = context.Appartementen.ToList();
            _woningen = new Woningen(appartementList);
            return _woningen;
        }

        public static Woningen GetHuizen()
        {
            List<Huis> appartementList = context.Huizen.ToList();
            _woningen = new Woningen(appartementList);
            return _woningen;
        }

        #region Woning
        public static IWoning AddWoning(IWoning woning)
        {
            context.Woningen.Add(woning as Woning);
            context.SaveChanges();
            return woning;
        }
        public static IWoning UpdateWoning(IWoning woning)
        {
            context.Woningen.AddOrUpdate(woning as Woning);
            context.SaveChanges();
            return woning;
        }
        public static void RemoveWoning(IWoning woning)
        {
            context.Woningen.Remove(woning as Woning);
            _woningen.Remove(woning);
            context.SaveChanges();
        }
        #endregion

        #region Klant
        public static IKlant AddKlant(IKlant klant)
        {
            context.Klanten.Add(klant as Klant);
            context.SaveChanges();
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
            _klanten.Remove(klant);
            context.SaveChanges();
        }
        #endregion
    }

}


