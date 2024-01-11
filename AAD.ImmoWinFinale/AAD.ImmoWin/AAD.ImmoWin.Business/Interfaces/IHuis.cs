using AAD.ImmoWin.Business.Enumerations;
using System;

namespace AAD.ImmoWin.Business.Interfaces
{
    public interface IHuis : IWoning, IFormattable
    {
        Huistype Type { get; set; }
    }
}