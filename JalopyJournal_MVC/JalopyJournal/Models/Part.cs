using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JalopyJournal.Models
{
    public abstract class Part: IEntity
    {
        public int ID { get; set; }

        [Range(0, 9999999.9, ErrorMessage = "Invalid Miles; Max 8 digits")]
        [RegularExpression(@"^\d+(\.\d{0,1})?$")] // max 9,999,999.9
        [Display(Name = "Miles")]
        public float Miles { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Range(0, 999999.99, ErrorMessage = "Invalid Cost; Max 9 digits")]
        [RegularExpression(@"^\d+(\.\d{0,2})?$")] // max 999,999.99
        [Display(Name = "Cost")]
        public float Cost { get; set; }

        [StringLength(500, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [Display(Name = "Notes")]
        public string Notes { get; set; }

        public int CarID { get; set; } //foreign key
        // Car navigation property
        public virtual Car Car { get; set; }
    }
}