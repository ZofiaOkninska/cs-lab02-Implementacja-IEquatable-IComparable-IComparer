class Program
{
    static void Main(string[] args)
    {
        Step1();
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
}