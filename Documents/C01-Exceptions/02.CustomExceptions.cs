//**************************************************************************************************
//Developer can create its own exception classes and use these exceptions in application.
//The parent class for all custom exceptions must be Exception or any other exception classes.
//**************************************************************************************************

class PersonException : ArgumentException
{
    public int Value { get;}
    public PersonException(string message, int val): base(message)
    {
        Value = val;
    }
}


class Person
{
    public string Name { get; set; }
    private int age;
    public int Age
    {
        get { return age; }
        set
        {
            if (value < 18)
                throw new PersonException("Persons younger than 18 years cannot register", value);
            else
                age = value;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Person p = new Person { Name = "Tom", Age = 13 };
        }
        catch (PersonException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"Invalid value: {ex.Value}");
        }
        Console.Read();
    }
}
