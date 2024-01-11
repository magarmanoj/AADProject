using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Data.Data;
using AAD.ImmoWin.Business.Exceptions;
using System;

namespace AAD.ImmoWin.Business.Validatie
{
    public class WoningenAppValidatie
    {
        public static void ValidateAppartement(Data.Data.Woning appartement)
        {
            Data.Data.Appartement app = appartement as Data.Data.Appartement;
            if (appartement == null)
            {
                throw new ArgumentNullException(nameof(appartement));
            }
            if (String.IsNullOrEmpty(app.Adres.Straat))
            {
                throw new StraatLeeg_AdresException();
            }
            if (String.IsNullOrEmpty(app.Adres.Gemeente))
            {
                throw new GemeenteLeeg_AdresException();
            }
            if (app.Verdieping < 0 || appartement.Waarde < 0)
            {
                throw new WaardeTeKlein_WoningException();
            }
            if (appartement.Waarde <= 0 || appartement.Waarde == null)
            {
                throw new WaardeTeKlein_WoningException();
            }
            if (appartement.Adres.Nummer <= 0)
            {
                throw new NummerTeKlein_AdresException();
            }
            if (appartement.Adres.Postnummer <= 0)
            {
                throw new PostnummerTeKlein_AdresException();
            }
            if (appartement.BouwDatum > DateTime.Now)
            {
                throw new BouwdatumTeGroot_WoningException();
            }
        }


    }
}
