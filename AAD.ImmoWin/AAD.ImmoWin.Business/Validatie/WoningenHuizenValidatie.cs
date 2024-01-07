using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Business.Validatie
{
    public class WoningenHuizenValidatie
    {
        public static void ValidateHuizen(Woning huis)
        {
            if (huis == null)
            {
                throw new ArgumentNullException(nameof(huis));
            }

            if (String.IsNullOrEmpty(huis.Adres.Straat) ||
                String.IsNullOrEmpty(huis.Adres.Gemeente))
            {
                throw new WoningException("Invalid Woning data.");
            }

            if (huis.Waarde < 0 || huis.Adres.Nummer <= 0 ||
                huis.Adres.Postnummer <= 0)
            {
                throw new WaardeTeKlein_WoningException();
            }
            if (huis.BouwDatum > DateTime.Now)
            {
                throw new BouwdatumTeGroot_WoningException();
            }
        }

    }
}

