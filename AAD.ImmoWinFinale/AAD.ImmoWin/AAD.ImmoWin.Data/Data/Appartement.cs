using AAD.ImmoWin.Data.Data;
using Odisee.Common.Observables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Data.Data
{
    [Table("Appartementen")]
    public class Appartement : Woning
    {
        public int Verdieping { get; set; }
        public Appartement() { }
        public Appartement(int verdieping, Adres adres, DateTime? bouwdatum = null, decimal? waarde = null) : base(adres, bouwdatum, waarde)
        {
            Verdieping = verdieping;
        }
        public override string ToString()
        {
            if (Adres == null) return $"{GetType().Name}: verd. {Verdieping} - € {Waarde} - No address";
            return $"{GetType().Name}: verd. {Verdieping} - € {Waarde} - {Adres.Straat}, {Adres.Nummer}, {Adres.Postnummer}, {Adres.Gemeente}";
        }
    }
}
