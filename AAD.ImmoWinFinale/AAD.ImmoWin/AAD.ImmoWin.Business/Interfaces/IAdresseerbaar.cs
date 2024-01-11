using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAD.ImmoWin.Business.Classes;

namespace AAD.ImmoWin.Business.Interfaces
{
    public interface IAdresseerbaar
    {
        IAdres Adres { get; set; }
    }
}
