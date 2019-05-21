using ModelValidation.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelValidation.Models
{
    public class Appointment
    {
        [Required]
        [Remote("ValidateClientName", "RemoteValidator")]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter a date")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms")]
        [MustBeTrue(ErrorMessage = "Custom Validation Attribte. You must accept the terms")]
        public bool TermsAccepted { get; set; }
    }
}