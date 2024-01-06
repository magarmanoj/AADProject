using System;
using System.Globalization;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Exceptions;

namespace AAD.ImmoWin.Business.Classes
{
    public class Adres : IAdres
    {
        #region Fields
        private String _straat;
        private int _nummer;
        private int _postnummer;
        private String _gemeente;

        #endregion

        #region Properties

        public String Straat
        {
            get { return _straat; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new StraatLeeg_AdresException();
                _straat = value;
            }
        }
        public int Nummer
        {
            get { return _nummer; }
            set
            {
                if (value <= 0)
                    throw new NummerTeKlein_AdresException();
                _nummer = value;
            }
        }
        public int Postnummer
        {
            get { return _postnummer; }
            set
            {
                if (value <= 0)
                    throw new PostnummerTeKlein_AdresException();
                _postnummer = value;
            }
        }
        public String Gemeente
        {
            get { return _gemeente; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new GemeenteLeeg_AdresException();
                _gemeente = value;
            }
        }

        #endregion

        #region Constructor

        public Adres(string straat, int nummer, int postnummer, string gemeente)
        {
            Straat = straat;
            Nummer = nummer;
            Postnummer = postnummer;
            Gemeente = gemeente;
        }

        #endregion, 

        #region Methods

        public override string ToString()
        {
            return ToString(null, null);
        }

        public Adres()
        {

        }

        #endregion

        #region Interfaces

        #region Interfaces.IComparable

        public int CompareTo(object obj)
        {
            if (obj is IAdres other)
                return CompareTo(other);
            throw new ArgumentException("IAdres.CompareTo(object obj): obj moet IAdres zijn.");
        }

        #endregion

        #region Interfaces.IComparable<IAdres>

        public int CompareTo(IAdres other)
        {
            int result;
            if ((result = Postnummer.CompareTo(other.Postnummer)) == 0)
                if ((result = Gemeente.CompareTo(other.Gemeente)) == 0)
                    if ((result = Straat.CompareTo(other.Straat)) == 0)
                        result = Nummer.CompareTo(other.Nummer);
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
                    result = $"{Straat} {Nummer}, {Postnummer} {Gemeente}";
                    break;
                case "S": // sort
                    result = $"{Postnummer} {Gemeente} {Straat} {Nummer}";
                    break;
                case "L": // lokaal
                    result = $"{Straat} {Nummer}";
                    break;
            }

            return result;
        }

        #endregion

        #endregion
    }
}
