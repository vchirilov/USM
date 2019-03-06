//*********************************************************************
//Since C# 2.0 a new feature called method group conversion has been introduced.
//It allows assigning the name of a method to a delegate, without using new.
//*********************************************************************

public static void Start2()
{
	// Construct a delegate using method group conversion.
	StrMod strOp = ReplaceSpaces; // use method group conversion
	string str;

	// Call methods through the delegate.
	str = strOp("This is a test.");
	Console.WriteLine("Resulting string: " + str);
	Console.WriteLine();

	strOp = RemoveSpaces; // use method group conversion
	str = strOp("This is a test.");
	Console.WriteLine("Resulting string: " + str);
	Console.WriteLine();

	strOp = Reverse; // use method group conversion
	str = strOp("This is a test.");
	Console.WriteLine("Resulting string: " + str);

}