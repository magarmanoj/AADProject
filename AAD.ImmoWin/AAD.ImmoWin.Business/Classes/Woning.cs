using System;
using System.Globalization;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Exceptions;
using Odisee.Common.Observables;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AAD.ImmoWin.Business.Classes
{
    [Table("Woningen")]
    public abstract class Woning : ObservableObject, IWoning
    {
        #region Fields
        public int Id { get; set; }
        private Adres _adres;
        private DateTime? _bouwDatum;
        private Decimal? _waarde;

        [ForeignKey("Klant")]
        public int KlantId { get; set; } 

        public Klant Klant { get; set; }
        public Decimal? Waarde
        {
            get { return _waarde; }
            set
            {
                SetProperty(ref _waarde, value);
            }
        }
        public DateTime? BouwDatum
        {
            get { return _bouwDatum; }
            set
            {
                SetProperty(ref _bouwDatum, value);
            }
        }
        public Adres Adres
        {
            get { return _adres; }
            set
            {
                SetProperty(ref _adres, value);
            }
        }


        #endregion

        #region Constructors

        public Woning(Adres adres, DateTime? bouwdatum = null, Decimal? waarde = null)
        {
            Adres = adres;
            BouwDatum = bouwdatum;
            Waarde = waarde;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return ToString(null);
        }

        #endregion

        public Woning()
        {

        }

        #region Interfaces

        #region Interfaces.CompareTo

        public int CompareTo(object obj)
        {
            if (obj is IWoning other)
                return CompareTo(other);
            throw new ArgumentException("IWoning.CompareTo(object obj): obj moet IWoning zijn");
        }

        #endregion

        #region Interfaces.CompareTo<IWoning>

        public virtual int CompareTo(IWoning other)
        {
            return Adres.CompareTo(other.Adres);
        }

        #endregion

        #region Interfaces.IFormattable

        public virtual String ToString(String format)
        {
            return ToString(format, null);
        }

        public virtual string ToString(string format, IFormatProvider formatProvider)
        {
            String result = null;

            if (formatProvider is null)
                formatProvider = CultureInfo.CurrentCulture;
            if (format == null)
                format = "T"; // typical
            switch (format)
            {
                case "T":
                    result = $"€ {Waarde} - {Adres}";
                    break;
            }
            return result;

        }
        #endregion

        #endregion
    }
}
