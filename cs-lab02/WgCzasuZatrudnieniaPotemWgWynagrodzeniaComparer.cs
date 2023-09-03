using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class WgCzasuZatrudnieniaPotemWgWynagrodzeniaComparer : IComparer<Pracownik>
{
    public int Compare(Pracownik x, Pracownik y)
    {
        if (x is null && y is null) return 0; //the same
        if (x is null && !(y is null)) return -1; //x < y
        if (!(x is null) && y is null) return +1; //x > y

        //x and y are not null
        if (x.CzasZatrudnienia != y.CzasZatrudnienia)
            return (x.CzasZatrudnienia).CompareTo(y.CzasZatrudnienia);

        //dates are the same
        return x.Wynagrodzenie.CompareTo(y.Wynagrodzenie);
    }
}
