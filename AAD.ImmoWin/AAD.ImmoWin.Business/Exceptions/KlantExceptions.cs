using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Business.Exceptions
{
    public class KlantException : Exception
    {
        public KlantException(String message)
            :base(message)
        {}
    }

    public class NaamLeeg_KlantException : KlantException
    {
        public NaamLeeg_KlantException() 
            : base("Klantnaam mag niet leeg zijn")
        {
        }
    }
}
