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
