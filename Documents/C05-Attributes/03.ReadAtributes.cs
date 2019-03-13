using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C05.Attributes
{
    class ReadAttributes
    {
        public static void GetCustomAttribute()
        {
            Type calcType = typeof(Calculator);
            Type atribType = typeof(RemarkAttribute);

            RemarkAttribute ra = (RemarkAttribute)Attribute.GetCustomAttribute(calcType, atribType);

            Console.WriteLine(ra.Remark);
        }
    }
}
