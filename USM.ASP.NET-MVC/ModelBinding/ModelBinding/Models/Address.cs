using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelBinding.Models
{
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}