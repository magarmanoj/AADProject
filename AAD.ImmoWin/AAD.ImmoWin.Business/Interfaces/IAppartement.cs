using System;

namespace AAD.ImmoWin.Business.Interfaces
{
    public interface IAppartement : IWoning, IComparable<IAppartement>
    {
        int Verdieping { get; set; }
    }
}