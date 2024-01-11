using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Exceptions;
using AAD.ImmoWin.Data.Data;
using System;

namespace AAD.ImmoWin.Business.Validatie
{
    public class WoningenHuizenValidatie
    {
        public static void ValidateHuizen(Data.Data.Woning huis)
        {
            Data.Data.Huis h = huis as Data.Data.Huis;

            if (huis == null)
            {
                throw new ArgumentNullException(nameof(huis));
            }

            if (String.IsNullOrEmpty(h.Adres.Straat))
            {
                throw new StraatLeeg_AdresException();
            }

            if (String.IsNullOrEmpty(h.Adres.Gemeente))
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

