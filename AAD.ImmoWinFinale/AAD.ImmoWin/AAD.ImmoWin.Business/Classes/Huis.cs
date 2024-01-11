using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAD.ImmoWin.Business.Enumerations;
using AAD.ImmoWin.Business.Interfaces;

namespace AAD.ImmoWin.Business.Classes
{
    public class Huis : Woning, IHuis
    {
        #region Fields

        private Huistype _huistype;

        #endregion

        #region Properties

        public Huistype Type
        {
            get { return _huistype; }
            set { SetProperty(ref _huistype, value); }
        }

        #endregion

        #region Constructors

        public Huis(Huistype huistype, Adres adres, DateTime? bouwdatum = null, decimal? waarde = null)
            : base(adres, bouwdatum, waarde)
        {
            Type = huistype;
        }



        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{GetType().Name}: type: {Type} - {base.ToString()}";
        }

        #endregion

        #region Interfaces

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
                    result = $"{GetType().Name} {Type} - {base.ToString(null, null)}";
                    break;
            }

            return result;
        }

        #endregion

        #endregion

    }
}
