using AAD.ImmoWin.Business.Classes;
using Odisee.Common.Observables;
using System;
using System.ComponentModel;

namespace AAD.ImmoWin.Business.Interfaces
{
    public interface IWoning : IAdresseerbaar, IComparable, IComparable<IWoning>, IFormattable, IObservableObject
    {
        DateTime? BouwDatum { get; set; }
        decimal? Waarde { get; set; }
    }
}