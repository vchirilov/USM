//******************************************************************************************
//Attributes allow positional and named parameters:
//Positional are parameters that comes from constructor and must be listed firstly.
//Named parameters are optional and must come after positional parameters.
//Named parameter is supported by either a public field or property, which must be read-write and non-static
//Named attribute parameters are conceptually similar to named arguments in methods.
//******************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C05.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class MetadataAttribute : Attribute
    {
        private readonly string remark; // underlies Remark property
        
        //This can be used as a named parameter:
        public string Supplement { get; set; }

        public MetadataAttribute(string comment)
        {
            remark = comment;
            Supplement = "None";
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
