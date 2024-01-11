using AAD.ImmoWin.Data.Enumerations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AAD.ImmoWin.Data.Data
{
    [Table("Huizen")]
    public class Huis : Woning
    {
        public Huistype Type { get; set; }
        public Huis() { }
        public Huis(Huistype huistype, Adres adres, DateTime? bouwdatum = null, decimal? waarde = null)
            : base(adres, bouwdatum, waarde)
        {
            Type = huistype;
        }
        public override string ToString()
        {
            if (Adres == null) return $"{GetType().Name}: {Type} - € {Waarde} - No address";
            return $"{GetType().Name}: {Type} - € {Waarde} - {Adres.Straat}, {Adres.Nummer}, {Adres.Postnummer}, {Adres.Gemeente}";
        }
    }

}
