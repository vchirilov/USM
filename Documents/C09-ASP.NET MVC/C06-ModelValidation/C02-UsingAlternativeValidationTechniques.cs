/*******************************************************************************************************
The MVC Framework supports the use of metadata to express model validation rules. 
The advantage of using metadata is that our validation rules are enforced anywhere that the binding process 
is applied throughout the application, not just in a single action method.
*******************************************************************************************************/

//Specifying Validation Rules Using Metadata

//Update Appointment class as below
public class Appointment
{
	[Required]
	public string ClientName { get; set; }
	
	[DataType(DataType.Date)]
	[Required(ErrorMessage = "Please enter a date")]	
	public DateTime Date { get; set; }
	
	[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms")]
	public bool TermsAccepted { get; set; }
}

//Update action MakeBooking
[HttpPost]
public ViewResult MakeBooking(Appointment appt)
{
	if (ModelState.IsValid)
	{
		return View("Completed", appt);
	}
	else
	{
		return View();
	}
}

//Run the application, you'll see the same effect but much less code, just using attributes.

/* There are several predefined attributes in ASP.NET MVC

Compare 

[Compare("MyOtherProperty")] 

Two properties must have the same value. This is useful when you ask the user to provide the same information twice, such
as an e-mail address or a password.
=====================================================================================
Range 

[Range(10, 20)] 

A numeric value (or any property type that implement IComparable) must not lie beyond the specified minimum and
maximum values. To specify a boundary on only one side, use a MinValue or MaxValue constant—for example, [Range(int.MinValue, 50)].
=====================================================================================
RegularExpression 

[RegularExpression("pattern")] 

A string value must match the specified regular expression pattern. Note that the pattern has to match the entire usersupplied
value, not just a substring within it. 
=====================================================================================
Required 

[Required(ErrorMessage = "Please enter a date")]

The value must not be empty or be a string consisting only of spaces. If you want to treat whitespace as valid, use
[Required(AllowEmptyStrings = true)].
=====================================================================================
StringLength 

[StringLength(10)] 

A string value must not be longer than the specified maximum length. We can also specify a minimum length: [StringLength(10, MinimumLength=2)].
*/

//Creating a Custom Property Validation Attribute

//We aren’t limited to just the built-in attributes; we can also create our own by deriving from the ValidationAttribute class

//Let's create a custom validation attribute. Create Infrastructure folder and a new class
public class MustBeTrueAttribute : ValidationAttribute
{
	public override bool IsValid(object value)
	{
		return value is bool && (bool)value;
	}
}

//Apply this attribute as below
public class Appointment
{
	[Required]
	public string ClientName { get; set; }

	[DataType(DataType.Date)]
	[Required(ErrorMessage = "Please enter a date")]
	public DateTime Date { get; set; }

	//[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms")]
	[MustBeTrue(ErrorMessage = "Custom Validation Attribte. You must accept the terms")]
	public bool TermsAccepted { get; set; }
}

//Run the application