//******************************************************************************************
//C# allows you to add declarative information to a program in the form of an attribute
//An attribute defines additional information (metadata) that is associated with a class, structure, method, and so on.
//Attributes are not a members of a class.
//All attribute classes must be subclasses of System.Attribute.
//There is a convention: attribute classes often use the suffix Attribute, like CustomAttribute, ErrorAttribute,...
//When an attribute class is declared, it is preceded by an attribute called AttributeUsage which is a built-in attribute.
//AttributeUsage built-in attribute specifies the types of items to which the attribute can be applied.
//******************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C05.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class RemarkAttribute : Attribute
    {
        string remark;
        public RemarkAttribute(string comment)
        {
            remark = comment;
        }
        public string Remark
        {
            get
            {
                return remark;
            }
        }
    }
}
