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
