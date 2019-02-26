//**************************************************************************************************
//Exception block
//**************************************************************************************************

try
{
     
}
catch
{
     
}
finally
{
     
}

//**************************************************************************************************
//1-st program. Lets have a program and simulate an exception of type System.DivideByZeroException
//**************************************************************************************************

class Program
{
    static void Main(string[] args)
    {
        int x = 5;
        int y = x / 0;
        Console.WriteLine($"Result: {y}");
        Console.WriteLine("The end of the program");
        Console.Read();
    }
}

//**************************************************************************************************
//Now, let's include this code in try-catch-finnaly block.
//Either catch or finally can be ommited...
//**************************************************************************************************
class Program
{
    static void Main(string[] args)
    {
        try
        {
            int x = 5;
            int y = x / 0;
            Console.WriteLine($"Result {y}");
        }
        catch
        {
            Console.WriteLine("An exception has occured");
        }
        finally
        {
            Console.WriteLine("Block finnaly");
        }
        Console.WriteLine("The end of the program");
        Console.Read();
    }
}

//**************************************************************************************************
//catch has form
//**************************************************************************************************

catch (exception_type)
{
    // code here...
}

try
{
    int x = 5;
    int y = x / 0;
    Console.WriteLine($"Результат: {y}");
}
catch(DivideByZeroException)
{
    Console.WriteLine("An exception has occured of type DivideByZeroException");
}


//**************************************************************************************************
//Filters, allows us to add additional login. Filters can be added with statement "when". 
//By the way it is permitted to have more catch statements in try-catch-finally statement.
//**************************************************************************************************

int x = 1;
int y = 0;
 
try
{
    int result = x / y;
}
catch(DivideByZeroException) when (y==0 && x == 0)
{
    Console.WriteLine("y must not be equal to 0");
}
catch(DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
}

//**************************************************************************************************
//Exception class is the main class for exceptions. This class is the base class for all exceptions.
//All exceptions inherits from Exception class, therefore construction of ...catch (Exception ex)...
//will handle all exceptions.
//The main properties are InnerException, Message, Source, StackTrace, TargetSite
//**************************************************************************************************

static void Main(string[] args)
{
    try
    {
        int x = 5;
        int y = x / 0;
        Console.WriteLine($"Результат: {y}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception {ex.Message}");
        Console.WriteLine($"Method {ex.TargetSite}");
        Console.WriteLine($"Trace: {ex.StackTrace}");
    }
 
    Console.Read();
}

//**************************************************************************************************
//There are a lot of predefined exceptions in .Net Framework, like 
//	DivideByZeroException
//	ArgumentOutOfRangeException
//	ArgumentException
//	IndexOutOfRangeException
//	NullReferenceException

//We can handle several exceptions in a try-catch-finnaly block like below
//**************************************************************************************************

static void Main(string[] args)
{
    try
    {
        object obj = "you";
        int num = (int)obj;     // InvalidCastException
        Console.WriteLine($"Результат: {num}");
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Exception DivideByZeroException");
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("Exception IndexOutOfRangeException");
    }
	
	catch (InvalidCastException)
    {
        Console.WriteLine("Exception IndexOutOfRangeException");
    }	
             
    Console.Read();
}