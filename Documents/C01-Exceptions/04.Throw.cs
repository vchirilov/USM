//**************************************************************************************************
//You can use throw operator in order to throw exceptions
//**************************************************************************************************

static void Main(string[] args)
{
    try
    {
        Console.Write("Type text:");
        string message = Console.ReadLine();
        if (message.Length > 6)
        {
            throw new Exception("The lenght is more than 6 symbols");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error: {e.Message}");
    }
    Console.Read();
}


//**************************************************************************************************
//Throw can be used without an exception.It can be useful when you want to interrup execution of the 
//program. See example below...
//**************************************************************************************************

try
{
    try
    {
        Console.Write("Введите строку: ");
        string message = Console.ReadLine();
        if (message.Length > 6)
        {
            throw new Exception("Длина строки больше 6 символов");
        }
    }
    catch
    {
        Console.WriteLine("Возникло исключение");
        throw;
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}