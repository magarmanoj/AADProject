using Odisee.Common.Observables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AAD.ImmoWin.Data.Data
{
    [Table("Klanten")]
    public class Klant:ObservableObject
    {
        [Key]
        public int Id { get; set; }
        public String Voornaam { get; set; }
        public String Familienaam { get; set; }

        public List<Woning> Eigendommen { get; set; }

        public Klant()
        { }
        public Klant(String voornaam, String familienaam)
        {
            Voornaam = voornaam;
            Familienaam = familienaam;
        }

        public override string ToString()
        {

            return $"{Familienaam} {Voornaam} #eigendommen: {Eigendommen.Count}";
        }
    }
}
