using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //Step1();
        //Step2();
        //Step3();
        //Step4();
        Step5();
    }

    static void Step1()
    {
        Console.WriteLine("--- Sprawdzenie poprawności tworzenia obiektu ---");
        Pracownik p = new Pracownik("Kowalski", new DateTime(2010, 10, 1), 1_000);//1_000 means 1000 but it is easier to read and _ is ignored by compiler
        Console.WriteLine(p);

        Console.WriteLine("--- Sprawdzenie równości obiektów ---");
        Pracownik p1 = new Pracownik("Nowak", new DateTime(2010, 10, 1), 1_000);
        Pracownik p2 = new Pracownik("Nowak", new DateTime(2010, 10, 1), 1_000);
        Pracownik p3 = new Pracownik("Kowalski", new DateTime(2010, 10, 1), 1_000);
        Pracownik p4 = p1;//here p4 is not a copy of p1 but it is a reference to p1 !!!
        Console.WriteLine($"p1: {p1} hashCode: {p1.GetHashCode()}");
        Console.WriteLine($"p2: {p2} hashCode: {p2.GetHashCode()}");
        Console.WriteLine($"p3: {p3} hashCode: {p3.GetHashCode()}");
        Console.WriteLine($"p4: {p4} hashCode: {p4.GetHashCode()}");
        //getHashCode if is the same for 2 objects then it does not mean that thet have the same values in properties and fields
        Console.WriteLine();

        Console.WriteLine($"--- Równość dla p1 oraz p2 -");
        Console.WriteLine($"Object.ReferenceEquals(p1, p2): {Object.ReferenceEquals(p1, p2)}");
        Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
        Console.WriteLine($"p1 == p2: {p1 == p2}");//it enters Equals(Pracownik p1, Pracownik p2) for == and != operators
        Console.WriteLine();

        Console.WriteLine($"--- Równość dla p1 oraz p3 -");
        Console.WriteLine($"Object.ReferenceEquals(p1, p3): {Object.ReferenceEquals(p1, p3)}");
        Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}");
        Console.WriteLine($"p1 == p3: {p1 == p3}");
        Console.WriteLine();

        Console.WriteLine($"--- Równość dla p1 oraz p4 -");
        Console.WriteLine($"Object.ReferenceEquals(p1, p4): {Object.ReferenceEquals(p1, p4)}");
        Console.WriteLine($"p1.Equals(p3): {p1.Equals(p4)}");
        Console.WriteLine($"p1 == p4: {p1 == p4}");
        Console.WriteLine();

        Pracownik p6 = null;//gives warning: "The result of the expression is always 'null' of type 'Pracownik'"

        Console.WriteLine($"--- Równość dla p7 oraz p8 -");
        var p7 = new Pracownik("Nowak", new DateTime(2010, 10, 1), 1_000);
        var p8 = new Pracownik("Nowak", new DateTime(2010, 10, 1), 1_000);
        Console.WriteLine($"p7.Equals(p8): {p7.Equals(p8)}");
        Console.WriteLine();

        Console.WriteLine($"--- Równość dla p9 oraz p10 -");
        //this two lines below can be also in a combination of Object and object?, Object? and object? etc. for Equals(object obj) to be executed
        Pracownik? p9 = new Pracownik("Nowak", new DateTime(2010, 10, 1), 1_000);        
        object p10 = new Pracownik("Nowak", new DateTime(2010, 10, 1), 1_000);
        Console.WriteLine($"p9.Equals(p10): {p9.Equals(p10)}");//enters Equals(Praownik other) if p10 is Pracownik
        //how to check variable type? GetType() method
        Console.WriteLine($"p9.GetType(): {p9.GetType()}");
        Console.WriteLine($"p10.GetType(): {p10.GetType()}");
        Console.WriteLine();

        /*NOTES:
        //Equals(Pracownik other) is executed if p1 and p2 are of type Pracownik (both), Pracownik? (both) (those 2 mixed) or var (both or one is var and the other is Pracownik or Pracownik?)
        //if both are var, then Equals(Pracownik other) is executed too
        //Equals(object obj) is executed if obj is of type object, object?, Object or Object?
        */
    }

    static void Step2()
    {   
        var list = new List<Pracownik>();
        list.Add(new Pracownik("Nowak", new DateTime(2010, 10, 12), 1_600));
        list.Add(new Pracownik("Nowak", new DateTime(2011, 10, 11), 1_500));
        list.Add(new Pracownik("Kowalski", new DateTime(2012, 11, 1), 1_700));
        list.Add(new Pracownik("Dadacki", new DateTime(2010, 10, 1), 1_800));
        list.Add(new Pracownik("Cacacki", new DateTime(2013, 12, 1), 1_800));

        Console.WriteLine(list); //wypisze typ, a nie zawartość listy

        Console.WriteLine("-- Wariant 1 --");
        foreach(var pracownik in list)
            Console.WriteLine(pracownik);

        Console.WriteLine("-- Wariant 2 --");
        list.ForEach((p) => {Console.Write(p + ",");});//nie dodaje nowej linii na końcu, bo to Console.Write
        Console.WriteLine( );

        Console.WriteLine("-- Wariant 3 --");
        Console.WriteLine(string.Join('\n', list));//Join przyjmuje separator i kolekcję przez którą ma iterować

        list.Sort();//zadziała, jeśli klasa Pracownik implementuje IComparable<Pracownik>

        Console.WriteLine("Po posortowaniu:");
        foreach(var pracownik in list)
            Console.WriteLine(pracownik);
    }

    static void Step3()
    {
        var lista = new List<Pracownik>();
        lista.Add(new Pracownik("CCC", new DateTime(2010, 10, 02), 1050));
        lista.Add(new Pracownik("AAA", new DateTime(2010, 10, 01), 100));
        lista.Add(new Pracownik("DDD", new DateTime(2010, 10, 03), 2000));
        lista.Add(new Pracownik("AAA", new DateTime(2011, 10, 01), 1000));
        lista.Add(new Pracownik("BBB", new DateTime(2010, 10, 01), 1050));

        Console.WriteLine(lista); //wypisze typ, a nie zawartość listy
        foreach (var pracownik in lista)
            System.Console.WriteLine(pracownik);

        //Environment.NewLine - zwraca znaki nowej linii zależne od systemu operacyjnego
        Console.WriteLine("--- Zewnętrzny porządek - obiekt typu IComparer" + Environment.NewLine
                            + "najpierw według czasu zatrudnienia (w miesiącach), " + Environment.NewLine
                            + "a później według wynagrodzenia - wszystko rosnąco");

        /* Używamy przeciążonej metody Sort<T> zdefiniowanej w klasie List<T>, wymagającej dostarczenia obiektu typu IComparer */
        lista.Sort(new WgCzasuZatrudnieniaPotemWgWynagrodzeniaComparer());
        
        foreach (var pracownik in lista)
            System.Console.WriteLine(pracownik);

        
        Console.WriteLine("--- Zewnętrzny porządek - delegat typu Comparison" + Environment.NewLine
                        + "najpierw według czasu zatrudnienia (w miesiącach), " + Environment.NewLine
                        + "a później kolejno według nazwiska i wynagrodzenia - wszystko rosnąco");
        /*NOTES:
        // sklejamy odpowiednio napisy i je porównujemy
        // ToString("D3") - wyrównanie do 3 znaków, jeśli mniej, to uzupełniamy zerami z przodu
        // ToString("00000.00") - wyrównanie do 7 znaków, jeśli mniej, to uzupełniamy zerami z przodu
        // QUESTION: co jeśli dwa porównywane nazwiska będą miały różną długość? 
        // ANSWEAR: litera w porównaniu z cyfrą w ASCII jest mniejsza (np. 'A' < '0')
        // string a = "157AAA200";
        // string b = "157AAAA100";
        // w kolejności rosnącej: a < b, czyli na liście wyżej będzie a
         */
        /* Używamy przeciążonej metody Sort<T> zdefiniowanej w klasie List<T>, wymagającej dostarczenia delegata typu Comparison */
        lista.Sort((p1, p2) => (p1.CzasZatrudnienia.ToString("D3")
                                    + p1.Nazwisko + p1.Wynagrodzenie.ToString("00000.00")
                                )
                                .CompareTo
                                (p2.CzasZatrudnienia.ToString("D3")
                                    + p2.Nazwisko + p2.Wynagrodzenie.ToString("00000.00")
                                )
                    );

        foreach (var pracownik in lista)
            System.Console.WriteLine(pracownik);

        
        Console.WriteLine("--- Zewnętrzny porządek - delegat typu Comparison" + Environment.NewLine
                        + "kolejno: malejąco według wynagrodzenia, " + Environment.NewLine
                        + "później rosnąco według czasu zatrudnienia");

        //budujemy warunek wyrażeniem warunkowym ()?:
        lista.Sort((p1, p2) => (p1.Wynagrodzenie != p2.Wynagrodzenie) ?
                                    (-1) * (p1.Wynagrodzenie.CompareTo(p2.Wynagrodzenie)) :
                                    p1.CzasZatrudnienia.CompareTo(p2.CzasZatrudnienia)
                    );

        foreach (var pracownik in lista)
            System.Console.WriteLine(pracownik);
            
    }

    static void Step4()
    {
        var lista = new List<Pracownik>()//notice this type of notation for creating a list
        {
            new Pracownik("CCC", new DateTime(2010, 10, 02), 1050),
            new Pracownik("AAA", new DateTime(2010, 10, 01), 100),
            new Pracownik("DDD", new DateTime(2010, 10, 03), 2000),
            new Pracownik("AAA", new DateTime(2011, 10, 01), 1000),
            new Pracownik("BBB", new DateTime(2010, 10, 01), 1050)
        };

        Console.WriteLine(lista); //wypisze typ, a nie zawartość listy
        foreach (var pracownik in lista)
            System.Console.WriteLine(pracownik);

        Console.WriteLine("--- Porządkowanie za pomocą metod rozszerzających Linq" + Environment.NewLine
                        + "kolejno: rosnąco według wynagrodzenia, " + Environment.NewLine
                        + "później malejąco według nazwiska");
        
        var query = lista.OrderBy(p => p.Wynagrodzenie).ThenByDescending(p => p.Nazwisko);
        
        foreach (var pracownik in query)
            System.Console.WriteLine(pracownik);
    }

    static void Step5()
    {
        var lista = new List<Pracownik>()
        {
            new Pracownik("CCC", new DateTime(2010, 10, 02), 1050),
            new Pracownik("AAA", new DateTime(2010, 10, 01), 100),
            new Pracownik("DDD", new DateTime(2010, 10, 03), 2000),
            new Pracownik("AAA", new DateTime(2011, 10, 01), 1000),
            new Pracownik("BBB", new DateTime(2010, 10, 01), 1050)
        };
        var listaInt = new List<int> { 2, 5, 1, 2, 1, 7, 4, 5 };

        Console.WriteLine($"Lista pracowników:\n{string.Join('\n', lista)}");
        Console.WriteLine($"Lista liczb: {string.Join(',', listaInt)}");

        // wewnętrzny porządek w zbiorze
        Console.WriteLine("--- Porządkowanie za pomocą własnej metody sortującej" + Environment.NewLine
            + "zgodnie z naturalnym porządkiem zdefiniowanym w klasie Pracownik ---");
        
        Sortowanie.Sortuj(lista); // wywołanie metody "tradycyjnie"
        Console.WriteLine(string.Join('\n', lista));
        
        listaInt.Sortuj(); // wywołanie jako metody rozszerzajacej
        Console.WriteLine(string.Join(',', listaInt));
    }
}