/*************************************************************************************************
In Web applications, users typically expect immediate validation feedback—without having to submit
anything to the server. This is known as client-side validation and is usually implemented using
JavaScript.

The MVC Framework supports unobtrusive client-side validation. The term unobtrusive means that
validation rules are expressed using attributes added to the HTML elements that we generate. 
These attributes are interpreted by a JavaScript library that is included as part of the MVC Framework that, in
turn, relies configures the jQuery Validation library, which does the actual validation work.
*************************************************************************************************/

//Enabling and Disabling Client-Side Validation

//Client-side validation is controlled by two settings in the Web.config file. These settings are responsible for setting field attributes

<appSettings>
	<add key="ClientValidationEnabled" value="true"/>
	<add key="UnobtrusiveJavaScriptEnabled" value="true"/>
</appSettings>

//Add one more validation to field ClientName of Appointment class and you'll see as it dynamically added attributes
//data-val-length="The field ClientName must be a string with a minimum length of 3 and a maximum length of 10." 
//data-val-length-max="10" 
//data-val-length-min="3"

[Required]
[StringLength(10, MinimumLength = 3)] //this piece of code
public string ClientName { get; set; }


//In order to download java script library that deal with client validation, add this bundle in _Layout.cshtml
...
@Scripts.Render("~/bundles/jquery")
@Scripts.Render("~/bundles/jqueryval")		//this piece of code
@RenderSection("scripts", required: false)
...