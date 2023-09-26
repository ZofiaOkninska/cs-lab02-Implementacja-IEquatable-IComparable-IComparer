using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

/// <summary>
/// Statyczna klasa pomocnicza, dostarczająca metody sortowania listy.
/// </summary>
/// <remarks>
/// Implementacja algorytmu sortowania bąbelkowego.
/// Pseudokod:
/// <code>
/// procedure bubbleSort( A : lista elementów do posortowania )
///   n = liczba_elementów(A)
///    do
///     for (i = 0; i < n-1; i++) do:
///       if A[i] > A[i+1] then
///         swap(A[i], A[i+1])
///       end if
///     end for
///     n = n-1
///   while n > 1
/// end procedure
/// </code>
/// </remarks>
public static class Sortowanie
{
    // metoda rozszerzająca IList<T>
    // zamienia miejscami elementy listy o wskazanych indeksach
    public static void SwapElements<T>(this IList<T> list, int firstIndex, int secondIndex)
    {
        Contract.Requires(list != null);
        Contract.Requires(firstIndex >= 0 && firstIndex < list.Count);
        Contract.Requires(secondIndex >= 0 && secondIndex < list.Count);
        if (firstIndex == secondIndex) return;

        T temp = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = temp;
    }

    /* Ta metoda wykorzystuje wewnętrzny porządek w zbiorze */
    public static void Sortuj<T>(this IList<T> list) where T : IComparable<T> 
    { 
        int n = list.Count;

        do {
            for (int i = 0; i < n - 1; i++) 
            {
                //for <Pracownik>, method CompareTo implemented in Pracownik is executed
                if (list[i].CompareTo(list[i + 1]) > 0) list.SwapElements(i, i+1);
            }
            n--;
        } while (n > 1);
    }

    /* Ta metoda wykorzystuje zewnętrzny porządek dostarczony w formie obiektu typu IComparer */
    public static void Sortuj<T>(this IList<T> list, IComparer<T> comparer)
    {
    }

    /* Ta metoda wykorzystuje zewnętrzny porządek dostarczony w formie delegata */
    public static void Sortuj<T>(this IList<T> list, Comparison<T> comparison)
    {
    }
}