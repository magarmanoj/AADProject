using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Exceptions;
using Odisee.Common.Observables;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace AAD.ImmoWin.Business.Classes
{
    public abstract class Woning : ObservableObject, IWoning
    {
        #region Fields
        public int Id { get; set; }
        private IAdres _adres;
        private DateTime? _bouwDatum;
        private Decimal? _waarde;

        #endregion

        #region Properties
        public Decimal? Waarde
        {
            get { return _waarde; }
            set
            {
                if (value.HasValue && value < 0)
                    throw new WaardeTeKlein_WoningException();
                SetProperty(ref _waarde, value);
            }
        }
        public DateTime? BouwDatum
        {
            get { return _bouwDatum; }
            set
            {
                if (value.HasValue && value > DateTime.Now)
                    throw new BouwdatumTeGroot_WoningException();
                SetProperty(ref _bouwDatum, value);
            }
        }
        public IAdres Adres
        {
            get { return _adres; }
            set
            {
                SetProperty(ref _adres, value);
            }
        }
        #endregion

        public Data.Data.Woning DataObject { get; private set; }
        public Woning(Data.Data.Woning dataObject)
        {
            DataObject = dataObject;
            Lees();
        }

        public void Lees()
        {
            _adres = DataObject.Adres as IAdres;
            _bouwDatum = DataObject.BouwDatum;
            _waarde = DataObject.Waarde;
           
            Changed = false;
        }

        public void Schrijf()
        {
            if (Changed)
            {
                DataObject.Adres = _adres as Data.Data.Adres;
                DataObject.BouwDatum = _bouwDatum;
                DataObject.Waarde = _waarde;
            }
        }

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
