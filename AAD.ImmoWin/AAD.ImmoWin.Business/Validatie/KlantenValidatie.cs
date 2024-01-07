using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Business.Validatie
{
    public class KlantenValidatie
    {
        public static void ValidateKlant(Klant klant)
        {
            if (klant == null)
            {
                throw new ArgumentNullException(nameof(klant));
            }

            if (String.IsNullOrEmpty(klant.Voornaam) || String.IsNullOrEmpty(klant.Familienaam))
            {
                throw new NaamLeeg_KlantException();
            }
        }
    }
}
