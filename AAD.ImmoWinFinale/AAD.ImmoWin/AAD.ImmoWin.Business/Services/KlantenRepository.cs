using System.Collections.Generic;
using AAD.ImmoWin.Business.Classes;



namespace AAD.ImmoWin.Business.Services
{
    public static class KlantenRepository
    {
        public static List<Klant> GetKlanten()
        {
            List<Klant> list = new List<Klant>();
            foreach (Data.Data.Klant p in Data.Services.KlantenRepository.GetKlanten())
            {
                list.Add(new Klant(p));
            }
            return list;
        }

        public static Klant UpdateKlant(Klant p)
        {
            Data.Services.KlantenRepository.UpdateKlant(p.DataObject);
            return p;
        }
    }
}


