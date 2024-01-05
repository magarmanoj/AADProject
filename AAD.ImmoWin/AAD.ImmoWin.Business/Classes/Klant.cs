using System;
using System.Linq;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Exceptions;
using System.Globalization;
using Odisee.Common.Observables;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AAD.ImmoWin.Business.Classes
{
    [Table("Klanten")]
    public class Klant : ObservableObject, IKlant
    {
        [Key]
        public int Id { get; set; }
        #region Fields
        private String _voornaam;
        private String _familienaam;
        private Woningen _eigendommen;


        #endregion

        #region Properties

        public String Voornaam
        {
            get { return _voornaam; }
            set
            {
                SetProperty(ref _voornaam, value);
            }
        }
        public String Familienaam
        {
            get { return _familienaam; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new NaamLeeg_KlantException();
                SetProperty(ref _familienaam, value);
            }
        }

        public Woningen Eigendommen
        {
            get { return _eigendommen; }
            private set { _eigendommen = value; }
        }
        #endregion

        #region Constructors

        public Klant(String familienaam)
             : this(null, familienaam)
        { }
        public Klant(String voornaam, String familienaam)
        {
            Voornaam = voornaam;
            Familienaam = familienaam;
            Eigendommen = new Woningen();
            Eigendommen.CollectionChanged += Eigendommen_CollectionChanged;
            Changed = false;
        }

        public Klant()
        {

        }

        private void Eigendommen_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Eigendommen");
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return ToString(null);
        }

        #endregion


        #region Interfaces

        #region Interfaces.IComparable

        public int CompareTo(object obj)
        {
            if (obj is IKlant other)
                return CompareTo(other);
            throw new ArgumentException("Iklant.CompareTo(object obj): obj moet een IKlant zijn.");
        }

        #endregion

        #region Interfaces.IComparable<IKlant>

        public int CompareTo(IKlant other)
        {
            int result;

            if ((result = Familienaam.CompareTo(other.Familienaam)) == 0)
                result = Voornaam.CompareTo(other.Voornaam);

            return result;
        }

        #endregion

        #region Interfaces.IFormattable

        public String ToString(String format)
        {
            return ToString(format, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            String result = null;

            if (formatProvider is null)
                formatProvider = CultureInfo.CurrentCulture;
            if (format == null)
                format = "T"; // typical
            switch (format)
            {
                default:
                case "T": // typical
                    result = $"{Familienaam} {Voornaam} #eigendommen: {Eigendommen}";
                    break;
                case "VF": // voornaam familienaam
                    result = $"{Voornaam} {Familienaam}".Trim();
                    break;
            }

            return result;
        }

        #endregion

        #region Interfaces.ICloneable

        public object Clone()
        {
            Klant clone = (Klant)MemberwiseClone();
            return clone;
        }

        #endregion

        #endregion
    }
}
