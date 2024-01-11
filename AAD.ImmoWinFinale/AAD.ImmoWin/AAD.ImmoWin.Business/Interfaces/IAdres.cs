using System;

namespace AAD.ImmoWin.Business.Interfaces
{
    public interface IAdres : IFormattable, IComparable, IComparable<IAdres>
    {
        string Gemeente { get; }
        int Nummer { get; }
        int Postnummer { get; }
        string Straat { get; }
    }
}