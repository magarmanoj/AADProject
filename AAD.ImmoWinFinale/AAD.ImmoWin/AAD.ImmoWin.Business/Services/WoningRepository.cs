using AAD.ImmoWin.Business.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Business.Services
{
    public class WoningRepository
    {
        //public static List<Huis> GetHuizen()
        //{
        //    List<Huis> list = new List<Huis>();
        //    foreach (Data.Data.Huis h in Data.Services.WoningRepository.GetHuizen())
        //    {
        //        Adres businessAdres = new Adres(
        //            h.Adres.Straat,
        //            h.Adres.Nummer,
        //            h.Adres.Postnummer,
        //            h.Adres.Gemeente
        //    );
        //        list.Add(new Huis(h.Type, businessAdres, h.BouwDatum, h.Waarde));
        //    }
        //    return list;
        //}



        public static List<Appartement> GetAppartement()
        {
            List<Appartement> list = new List<Appartement>();
            foreach (Data.Data.Appartement a in Data.Services.WoningRepository.GetAppartementen())
            {
                Adres businessAdres = new Adres(
                    a.Adres.Straat,
                a.Adres.Nummer,
                a.Adres.Postnummer,
                a.Adres.Gemeente
            );
                list.Add(new Appartement(a.Verdieping, businessAdres, a.BouwDatum, a.Waarde));
            }
            return list;
        }
    }
}
