using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JalopyJournal.Models
{
    public class FuelAdditive : Part
    {
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [Display(Name = "Fuel Additive")]
        public string AdditiveType { get; set; }
    }
}