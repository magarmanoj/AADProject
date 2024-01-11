using AAD.ImmoWin.Business.Classes;
using Odisee.Common.Observables;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AAD.ImmoWin.Business.Interfaces
{
    public interface IKlant : IFormattable, IComparable, IComparable<IKlant>, IObservableObject, ICloneable
    {
        Woningen Eigendommen { get; }
        string Familienaam { get; set; }
        string Voornaam { get; set; }
    }
}