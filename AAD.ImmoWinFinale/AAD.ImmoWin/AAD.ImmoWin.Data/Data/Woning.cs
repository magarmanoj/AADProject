using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AAD.ImmoWin.Data.Data
{
    [Table("Woningen")]
    public class Woning
    {
        public int Id { get; set; }
        public Adres Adres { get; set; }
        public DateTime? BouwDatum { get; set; }
        public Decimal? Waarde { get; set; }

        [ForeignKey("Klant")]
        public int KlantId { get; set; }
        public Klant Klant { get; set; }

        public Woning() { }
        public Woning(Adres adres, DateTime? bouwdatum = null, Decimal? waarde = null)
        {
            Adres = adres;
            BouwDatum = bouwdatum;
            Waarde = waarde;
        }
    }
}
