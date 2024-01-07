using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace AAD.ImmoWin.Business.Validatie
{
    public class WoningenAppValidatie
    {
        public static void ValidateAppartement(Woning appartement)
        {
            Appartement app = appartement as Appartement;
            if (appartement == null)
            {
                throw new ArgumentNullException(nameof(appartement));
            }

            if (String.IsNullOrEmpty(appartement.Adres.Straat) ||
                String.IsNullOrEmpty(appartement.Adres.Gemeente))
            {
                throw new WoningException("Invalid Woning data.");
            }

            if (app.Verdieping < 0 || appartement.Waarde < 0 || appartement.Adres.Nummer <= 0 ||
                appartement.Adres.Postnummer <= 0)
            {
                throw new WaardeTeKlein_WoningException();
            }
            if (appartement.BouwDatum > DateTime.Now)
            {
                throw new BouwdatumTeGroot_WoningException();
            }
        }

    }
}
