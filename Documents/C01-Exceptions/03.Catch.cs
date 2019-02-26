//**************************************************************************************************
//If the try block has no catch stement, then the sistem is trying to find catch in upper caller.
//Let's analyze the example below
//**************************************************************************************************

class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TestClass.Method1();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Catch in main : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("finally in Main");
            }
            Console.WriteLine("The end of method main");
            Console.Read();
        }
    }
    class TestClass
    {
        public static void Method1()
        {
            try
            {
                Method2();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Catch in Method1 : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("finally in Method1");
            }
            Console.WriteLine("The end of Method1");
        }
        static void Method2()
        {
            try
            {
                int x = 8;
                int y = x / 0;
            }
            finally
            {
                Console.WriteLine("finally in Method2");
            }
            Console.WriteLine("The end of Method2");
        }
    }