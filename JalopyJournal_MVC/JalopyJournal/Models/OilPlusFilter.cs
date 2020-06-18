using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JalopyJournal.Models
{
    public enum OilGrade
    {
        _10W20,
        _10W30,
        _10W40,
    }

    public class OilPlusFilter : Part
    {
        [Display(Name = "Oil Grade")]
        public OilGrade OilType { get; set; }

        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [Display(Name = "Oil Filter")]
        public string OilFilter { get; set; }
    }
}