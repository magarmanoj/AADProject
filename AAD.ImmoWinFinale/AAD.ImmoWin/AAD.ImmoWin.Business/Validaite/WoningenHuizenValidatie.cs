using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Exceptions;
using System;

namespace AAD.ImmoWin.Business.Validatie
{
    public class WoningenHuizenValidatie
    {
        public static void ValidateHuizen(Data.Data.Woning huis)
        {
            if (huis == null)
            {
                throw new ArgumentNullException(nameof(huis));
            }

            if (String.IsNullOrEmpty(huis.Adres.Straat))
            {
                throw new StraatLeeg_AdresException();
            }

            if (String.IsNullOrEmpty(huis.Adres.Gemeente))
            {
                throw new GemeenteLeeg_AdresException();
            }

            if (huis.Waarde < 0)
            {
                throw new WaardeTeKlein_WoningException();
            }

            if (huis.Adres.Nummer <= 0)
            {
                throw new NummerTeKlein_AdresException();
            }

            if (huis.Adres.Postnummer <= 0)
            {
                throw new PostnummerTeKlein_AdresException();
            }

            if (huis.BouwDatum > DateTime.Now)
            {
                throw new BouwdatumTeGroot_WoningException();
            }
        }
    }
}

