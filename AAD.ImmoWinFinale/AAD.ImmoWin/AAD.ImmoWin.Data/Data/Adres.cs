using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Data.Data
{
    [Table("Adressen")]
    public class Adres
    {
        public int AdresId { get; set; }
        public string Straat { get; set; }
        public int Nummer { get; set; }
        public int Postnummer { get; set; }
        public string Gemeente { get; set; }

        public Adres() { }

        public Adres(string straat, int nummer, int postnummer, string gemeente)
        {
            Straat = straat;
            Nummer = nummer;
            Postnummer = postnummer;
            Gemeente = gemeente;
        }
    }
}
