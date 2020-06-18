using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JalopyJournal.Models
{
    public enum FuelGrade
    {
        Eth_85_Octane,
        Eth_86_Octane,
        Eth_87_Octane,
        Eth_88_Octane,
        Eth_89_Octane,
        Eth_90_Octane,
        Eth_91_Octane,
        Eth_92_Octane,
        Eth_93_Octane,
        Gas_86_Octane,
        Gas_87_Octane,
        Gas_88_Octane,
        Gas_89_Octane,
        Gas_90_Octane,
        Gas_91_Octane,
        Gas_92_Octane,
        Gas_93_Octane,
    }

    public class Fuel : Part
    {
        [Range(0, 999.999, ErrorMessage = "Invalid Fuel Quantity; Max 6 digits")]
        [RegularExpression(@"^\d+(\.\d{0,3})?$")] // max 999.999
        [Display(Name = "Quantity")]
        public float Quantity { get; set; }

        [Display(Name = "Fuel Type")]
        public FuelGrade FuelType { get; set; }
    }
}