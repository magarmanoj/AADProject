using AAD.ImmoWin.Data.Data;
using AAD.ImmoWin.Business.Exceptions;
using System;

namespace AAD.ImmoWin.Data.Validatie
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
