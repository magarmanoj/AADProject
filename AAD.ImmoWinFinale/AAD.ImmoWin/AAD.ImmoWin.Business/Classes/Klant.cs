using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Exceptions;
using System.Globalization;
using Odisee.Common.Observables;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using AAD.ImmoWin.Data.Data;

namespace AAD.ImmoWin.Business.Classes
{
    public class Klant : ObservableObject, IKlant
    {
        #region Fields
        private String _voornaam;
        private String _familienaam;
        private Woningen _eigendommen;
        #endregion
        public Data.Data.Klant DataObject { get; private set; }
        public Klant(Data.Data.Klant dataObject)
        {
            DataObject = dataObject;
            Lees();
        }

        public void Lees()
        {
            _voornaam = DataObject.Voornaam;
            _familienaam = DataObject.Familienaam;
            Woningen woningen = new Woningen();
            foreach (Data.Data.Woning woning in DataObject.Eigendommen)
            {
                if (woning is Data.Data.Huis h)
                {
                    woningen.Add(new Data.Data.Huis(h.Type, h.Adres,h.BouwDatum, h.Waarde) as IWoning);
                }
                else if (woning is Data.Data.Appartement a)
                {
                    woningen.Add(new Data.Data.Appartement(a.Verdieping, a.Adres, a.BouwDatum, a.Waarde) as IWoning);
                }
            }
            Changed = false;
        }

        public void Schrijf()
        {
            if (Changed)
            {
                DataObject.Voornaam = _voornaam;
                DataObject.Familienaam = _familienaam;
                foreach (IWoning woning in _eigendommen)
                {
                    if (woning is Data.Data.Huis h)
                    {
                        DataObject.Eigendommen.Add(new Data.Data.Huis(h.Type, h.Adres, h.BouwDatum, h.Waarde));
                    }
                    else if (woning is Data.Data.Appartement a)
                    {
                        DataObject.Eigendommen.Add(new Data.Data.Appartement(a.Verdieping, a.Adres, a.BouwDatum, a.Waarde));
                    }
                }
            }
        }
        #region Properties

        public String Voornaam
        {
            get { return _voornaam; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new NaamLeeg_KlantException();
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
            get
            {
                return _eigendommen;
            }
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
                    result = $"{Familienaam} {Voornaam} #eigendommen: {Eigendommen.Count}";
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
