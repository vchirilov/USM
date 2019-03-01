//*********************************************************************
//Using a Constraint to Establish a Relationship Between Two Type Parameters
//*********************************************************************

//How would you interpret this pice of code?
class Gen<T, V> where V : T {...}


//*********************************************************************
//Using Multiple Constraints
//There can be more than one constraint associated with a type parameter. When this is the case, use a comma-separated list of constraints.
//*********************************************************************

class Gen<T> where T : MyClass, IMyInterface, new() {...}

//When using two or more type parameters, you can specify a constraint for each parameter by using a separate where clause.

// Use multiple where clauses.
// Gen has two type arguments and both have a where clause.
class Gen<T, V> where T : class where V : struct
{
    T ob1;
    V ob2;
    public Gen(T t, V v)
    {
        ob1 = t;
        ob2 = v;
    }
}
class MultipleConstraintDemo
{
    static void Main()
    {
        // This is OK because string is a class and
        // int is a value type.
        Gen<string, int> obj = new Gen<string, int>("test", 11);
        // The next line is wrong because bool is not
        // a reference type.
        // Gen<bool, int> obj = new Gen<bool, int>(true, 11);
    }
}




//*********************************************************************
//Operator default()
//Sometimes you need to initialize with default value generic parameter. 
//How to do it ? Let's analyze this example
//*********************************************************************

class MyClass
{
    //...
}
// Construct a default value of T.
class Test<T>
{
    public T obj;
    public Test()
    {
        // The following statement would work only for reference types.
        // obj = null; // can’t use
        // The following statement will work only for numeric value types.
        // obj = 0; // can’t use
        // This statement works for both reference and value types.
        obj = default(T); // Works!
    }
    // ...
}
class DefaultDemo
{
    static void Main()
    {
        // Construct Test using a reference type.
        Test<MyClass> x = new Test<MyClass>();
        if (x.obj == null)
            Console.WriteLine("x.obj is null.");
        // Construct Test using a value type.
        Test<int> y = new Test<int>();
        if (y.obj == 0)
            Console.WriteLine("y.obj is 0.");
    }
}


//*********************************************************************
//Creating a Generic Method
//*********************************************************************