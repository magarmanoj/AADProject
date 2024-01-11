using System;
using System.Globalization;
using AAD.ImmoWin.Business.Interfaces;

namespace AAD.ImmoWin.Business.Classes
{
    public class Appartement : Woning, IAppartement
    {
        #region Fields

        private int _verdieping;

        #endregion

        #region Properties
        public int Verdieping
        {
            get { return _verdieping; }
            set { SetProperty(ref _verdieping, value); }
        }

        #endregion

        #region Constructors

        public Appartement(int verdieping, Adres adres, DateTime? bouwdatum = null, decimal? waarde = null) : base(adres,  bouwdatum, waarde)
        {
            Verdieping = verdieping;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{GetType().Name}: verd. {Verdieping} - {base.ToString()}";
        }

        #endregion

        #region Interfaces

        #region Interfaces.CompareTo<IWoning>

        public override int CompareTo(IWoning other)
        {
            int result;
            if ((result = base.CompareTo(other)) == 0 && other is Appartement a)
                result = CompareTo(a);
            return result;
        }

        #endregion

        #region Interfaces.CompareTo<IAppartement>

        public int CompareTo(IAppartement other)
        {
            int result;
            if ((result = base.CompareTo(other)) == 0)
                result = Verdieping.CompareTo(other.Verdieping);
            return result;
        }


        #endregion 

        #region Interfaces.IFormattable

        public override String ToString(String format)
        {
            return ToString(format, null);
        }

        public override string ToString(string format, IFormatProvider formatProvider)
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
                    result = $"{GetType().Name} verd. {Verdieping} - {base.ToString(null, null)}";
                    break;
            }

            return result;
        }

        #endregion

        #endregion

    }
}
