using System;
public class Pracownik : IEquatable<Pracownik> {

    #region private fields
    private string _nazwisko;
    private DateTime _dataZatrudnienia;
    private decimal _wynagrodzenie;
    #endregion

    #region public properties 
    public string Nazwisko 
    {
        get => _nazwisko; 
        set => _nazwisko = value.Trim(); //musi być w setterze przypisanie value do odp. zmiennej! 
    }

    public DateTime DataZatrudnienia
    {
        get => _dataZatrudnienia; 
        set 
        {
           try
            {
                if (value > DateTime.Today) throw new ArgumentException();
                
                _dataZatrudnienia = value;//if exception occurs value will be default as in constructior without args
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occurred: {e.Message}");
            }
       }
    }

    public decimal Wynagrodzenie 
     {
        get => _wynagrodzenie; 
        set //_wyn = (value < 0)? 0: value;  <-- short form
        {
            if (value < 0) {
                _wynagrodzenie = 0;
            } else {
                _wynagrodzenie = value;
            }
       }
    }

    /* NOTES:
    //queston for CzasZatrudnienia below: jak to jest property to znaczy że ma getter i setter, ale jak to jest readonly?
    //why below is readonly? because it has only getter
    //then why it is property? because it has getter and setter
    //where is setter? there is no setter
    //if there is no setter then why it is property? because it has getter
    //link for below: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties
    //is setter required to call a field a property? no
    //is getter required to call a field a property? no
    //what is required to call a field a property? get or set
    //if field has only access modifier then it is a field, not a property!
    //waht else could be applied to a property? access modifiers, forexample: public or private or protected or internal or protected internal or private protected or static or virtual or sealed or override or abstract or extern or new or unsafe or partial  or volatile or ref or out or in or params or this or value or nameof or get or set or add or remove or operator or implicit or explicit or explicit or extern or ext 
    //is it possible to have a property without getter and setter? no
    
    //is this property given a value on creation an object of this class? no
    //on creation an object of this class is this property given a default value? no
    //on creation an object of this class is this property given allocated memory? no
    //why is this property not given a value on creation an object of this class? because it is readonly
    //when is this property given a value? when it is called

    //In C# 6, get; only properties are only settable from the constructor. From everywhere else, it is read-only.  
    //why the get-only property is not called on object construction? TODO: check it
    //if property has only setter what happens with it on constructing an object of this class? it is not called
    */
    public int CzasZatrudnienia => (DateTime.Now - DataZatrudnienia).Days / 30;//important  - you can do it with dates
    #endregion

    #region constructors
    public Pracownik(){
        Nazwisko = "Anonim";
        DataZatrudnienia = DateTime.Today;
        Wynagrodzenie = 0;
    }

    public Pracownik (string nazwisko, DateTime dataZatrudnienia, decimal wynagrodzenie){
        Nazwisko =  nazwisko;
        DataZatrudnienia = dataZatrudnienia;
        Wynagrodzenie = wynagrodzenie;
    }
    #endregion


    public override string ToString() => $"({Nazwisko}, {DataZatrudnienia:d MMM yyyy} ({CzasZatrudnienia}), {Wynagrodzenie} PLN)";


    #region implementation of IEquatable<Pracownik> 

    /*--implementacja Equals wymagana przez implementację interfejsu IEquatable<Pracownik>
      --Equals nie może zgłaszać wyjątków !*/
    public bool Equals(Pracownik other) /* types (Pracownik?) can enter this method? yes; */
    {
        //Console.WriteLine($"it enters Equals(Pracownik other)");
        //Console.WriteLine($"...{other}");
        //Console.WriteLine($"...{this}");

        /*BELOW: executes when other is null [p1.Equals(null)] or if of type nullable Pracownik: Pracownik? */
        if (other is null) { 
            //Console.WriteLine("...other is null from Equals(Pracownik other))");
            return false;
            }
        if (Object.ReferenceEquals(this, other)) { /* --other i this są referencjami do tego samego obiektu */
            //Console.WriteLine("...other i this są referencjami do tego samego obiektu");
            return true;
        }

        /*BELOW: tu nie korystamy z przesłonięcia == napisanego poniżej; tu == porównuje inne typy niż Pracownik */
        return (Nazwisko == other.Nazwisko &&
                DataZatrudnienia == other.DataZatrudnienia &&
                Wynagrodzenie == other.Wynagrodzenie);
    }

    /*NOTES:
    //---formalnie wymagane przesłonięcie Equals i GetHashCode z klasy Object - równocześnie
    //--https://docs.microsoft.com/en-Us/dotnet/api/system.object.gethashcode?view=netstandard-2.1#System_Object_GetHashCode

    //The null keyword is a literal that represents a null reference, one that does not refer to any object.
    //is null a reference type or value type? reference
    //object is a base class for all types
    */
    public override bool Equals(object obj) 
    {   
        /*NOTES:
        //can obj here be equal to null? yes; why? because null is also object (value or reference? reference)
        //it could be checked like this: obj == null and result would be true; why? because null is object in a reference way
        //in obj == null both are checked for the same value or reference? reference
        //== compared two objects for equality (for objects it is reference equality, but for value types it is value equality) 
        //it could be called like this: Equals(null) and result would be false; why? because null is not Pracownik 

        //can obj be checked if it is null in a value way? no; why? because it is reference type
        //can obj be checked if it is null in a reference way? yes; why? because it is reference type

        //object? x means that x is a reference type but it can be equal null
        //object? a = new Praownik(); means that a is a reference type but it can be null 
        //object a = new Praownik(); means that a is a reference type and it can not be null
        //does reference types have a value? no; why? because they are reference types
        //so Pracownik? a = null means it is null in a reference way 

        //"is" operator checks if obj is of a given type 

        //what data type can enter this method? object - what means that any data type can enter this method eg. int, string, Pracownik, etc.
        //even null keyword can enter this method? yes; why? because it is object
        */

        if (obj is Pracownik) {/* what this line would return if obj is null? false; why? because null is not Pracownik */
            /*NOTES:
            //can obj here be in the type of object here? yes; why? because it is checked if obj is Pracownik and Pracownik is object
            //can obj here be in the type of Object? yes; why? because it is checked if obj is Pracownik and Pracownik is Object
            //the evaluation: if (null is Pracownik) will return false; why? because null is not Pracownik
            */
            
            //Console.WriteLine("...obj is Pracownik");
            //Console.WriteLine($"...obj: {obj}");
            return Equals((Pracownik)obj);
        }
        else {/* this line will execute if obj is not Pracownik or if obj is null */
            //Console.WriteLine("---obj is not Pracownik or obj is null form Equals(object obj)");
            return false;
        }
    }

    public override int GetHashCode() => (Nazwisko, DataZatrudnienia, Wynagrodzenie).GetHashCode();
    //---koniec przesłonięcia Equals i GetHashCode z klasy Object - równocześnie

    /*NOTES:
    //dodatkowo statyczny wariant Equals(Pracownik, Pracownik)
    //static method means that it can be called without creating an object of this class
    */
    public static bool Equals(Pracownik p1, Pracownik p2)
    {
        Console.WriteLine($"it enters Equals(Pracownik p1, Pracownik p2)");
        if ((p1 is null) && (p2 is null)) return true; /* w C#: null == null */
        if ((p1 is null)) return false;

        /* p1 nie jest `null`, nie będzie NullReferenceException */
        return p1.Equals(p2);
    }

    /* przeciążenie operatora `==` i `!=` */
    public static bool operator ==(Pracownik p1, Pracownik p2) => Equals(p1, p2);
    public static bool operator !=(Pracownik p1, Pracownik p2) => !(p1 == p2);

    #endregion
}








